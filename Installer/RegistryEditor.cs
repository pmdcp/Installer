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

namespace Installer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Microsoft.Win32;

    class RegistryEditor
    {
        #region Fields

        string path;

        #endregion Fields

        #region Methods

        public void DeleteSubKey() {
            Registry.LocalMachine.DeleteSubKey(path, false);
        }

        public string Read(string key) {
            return (string)Registry.LocalMachine.OpenSubKey(path + "\\").GetValue(key);
        }

        public bool SubKeyExists() {
            return (Registry.LocalMachine.OpenSubKey(path + "\\") == null ? false : true);
        }

        public void SetPath(string path) {
            this.path = path;
        }

        public void Write(string key, string value) {
            Registry.LocalMachine.CreateSubKey(path + "\\").SetValue(key, value);
        }

        #endregion Methods
    }
}