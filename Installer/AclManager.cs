// This file is part of Mystery Dungeon eXtended.

// Mystery Dungeon eXtended is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Mystery Dungeon eXtended is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Mystery Dungeon eXtended.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Security.AccessControl;
using System.IO;
using System.Runtime.InteropServices;

namespace Installer
{
    class AclManager
    {
        public AclManager() {
        }

        public AclManager(string Path, string Username, string UserRights) {
            this.Pathname = Path;
            this.Username = Username;
            this.UserRights = UserRights;
        }

        ///
        /// Directory Resource to assign ACL to. This is a physical disk path
        /// like d:\temp\test.
        ///
        public string Pathname = "";

        ///
        /// Username or group name to assign to this resource
        ///
        public string Username = "";

        ///
        /// Rights to assign for the given user or group.
        /// N - None
        /// R - Read
        /// C - Change
        /// F - Full
        ///
        public string UserRights = "R";

        ///
        /// Determines whether the permissions walk down all child
        /// directories.
        ///
        public bool InheritSubDirectories = true;

        ///
        /// When set overrides the existing ACLs and only attaches this
        /// ACL effectively deleting all other ACLs. Generally you won't
        /// want to do this and only change/add the current ACL.
        ///
        public bool OverrideExistingRights = false;

        ///
        /// Error Message set by SetAcl
        ///

        [XmlIgnore()]
        public string ErrorMessage = "";

        ///
        /// Sets the actual ACL based on the property settings of this class
        ///
        ///
        public bool SetAcl() {
            if (this.Pathname == null || string.IsNullOrEmpty(this.Pathname)) {
                ErrorMessage += "Path cannot be empty.";
                return false;
            }

            // *** Strip off trailing backslash which isn't supported

            this.Pathname = this.Pathname.TrimEnd('\\');
            FileSystemRights Rights = (FileSystemRights)0;

            if (this.UserRights == "R") {
                Rights = FileSystemRights.ReadAndExecute;
            } else if (this.UserRights == "C") {
                Rights = FileSystemRights.ChangePermissions;
            } else if (this.UserRights == "F") {
                Rights = FileSystemRights.FullControl;
            }

            // *** Add Access Rule to the actual directory itself

            FileSystemAccessRule AccessRule = new FileSystemAccessRule(this.Username, Rights, InheritanceFlags.None, PropagationFlags.NoPropagateInherit, AccessControlType.Allow);

            DirectoryInfo Info = new DirectoryInfo(this.Pathname);
            DirectorySecurity Security = Info.GetAccessControl(AccessControlSections.Access);

            bool Result = false;
            Security.ModifyAccessRule(AccessControlModification.Set, AccessRule, out Result);

            if (!Result) {
                return false;
            }

            // *** Always allow objects to inherit on a directory

            InheritanceFlags iFlags = InheritanceFlags.ObjectInherit;
            if (this.InheritSubDirectories) {
                iFlags = InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit;
            }

            // *** Add Access rule for the inheritance

            AccessRule = new FileSystemAccessRule(this.Username, Rights, iFlags, PropagationFlags.InheritOnly, AccessControlType.Allow);
            Result = false;
            Security.ModifyAccessRule(AccessControlModification.Add, AccessRule, out Result);

            if (!Result) {
                return false;
            }

            Info.SetAccessControl(Security);
            return true;
        }

        const int NO_ERROR = 0;
        const int ERROR_INSUFFICIENT_BUFFER = 122;

        private enum SID_NAME_USE
        {
            SidTypeUser = 1,
            SidTypeGroup,
            SidTypeDomain,
            SidTypeAlias,
            SidTypeWellKnownGroup,
            SidTypeDeletedAccount,
            SidTypeInvalid,
            SidTypeUnknown,
            SidTypeComputer
        }

        [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern bool LookupAccountSid(
            string lpSystemName,
            [MarshalAs(UnmanagedType.LPArray)] byte[] Sid,
            System.Text.StringBuilder lpName,
            ref uint cchName,
            System.Text.StringBuilder ReferencedDomainName,
            ref uint cchReferencedDomainName,
            out SID_NAME_USE peUse);


        /// <summary>
        /// Obtains the localized name for the "BUILTIN\Users" group in this machine
        /// </summary>
        /// <returns></returns>
        public static string GetNormalUsersGroupName() {

            StringBuilder name = new StringBuilder();
            uint cchName = (uint)name.Capacity;
            StringBuilder referencedDomainName = new StringBuilder();
            uint cchReferencedDomainName = (uint)referencedDomainName.Capacity;
            SID_NAME_USE sidUse = default(SID_NAME_USE);

            // Sid for BUILTIN\Users
            byte[] Sid = new byte[] { 1, 2, 0, 0, 0, 0, 0, 5, 32, 0, 0, 0, 33, 2 };

            int err = NO_ERROR;
            if (!LookupAccountSid(null, Sid, name, ref cchName, referencedDomainName, ref cchReferencedDomainName, out sidUse)) {
                err = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                if (err == ERROR_INSUFFICIENT_BUFFER) {
                    name.EnsureCapacity((int)cchName);
                    referencedDomainName.EnsureCapacity((int)cchReferencedDomainName);
                    err = NO_ERROR;
                    if (!LookupAccountSid(null, Sid, name, ref cchName, referencedDomainName, ref cchReferencedDomainName, out sidUse)) {
                        err = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                    }
                }
            }

            if (err == 0) {
                return name.ToString();
            } else {
                throw new InvalidOperationException(string.Format("Error when obtaining BUILTIN\\Users localized name: {0}", err));

            }

        }
    }
}
