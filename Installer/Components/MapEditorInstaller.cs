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

namespace Installer.Components
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using Core;

    using MSjogren.Samples.ShellLink;

    using PMU.Compression.Zip;
    using PMU.Core;
    using Net = PMU.Net;

    class MapEditorInstaller : IComponentInstaller
    {
        #region Fields

        Pages.pgeMapEditorInstallOptions configPage;
        MapEditorInstallOptions installOptions;

        #endregion Fields

        #region Constructors

        public MapEditorInstaller() {
            configPage = new Pages.pgeMapEditorInstallOptions();
            installOptions = new MapEditorInstallOptions();
        }

        #endregion Constructors

        #region Events

        public event EventHandler InstallComplete;

        public event EventHandler<ProgressUpdateEventArgs> ProgressUpdate;

        public event EventHandler<StatusUpdateEventArgs> StatusUpdate;

        #endregion Events

        #region Properties

        public ComponentInstallOptions InstallOptions {
            get { return installOptions; }
        }

        public string Name {
            get { return "Map Editor"; }
        }

        #endregion Properties

        #region Methods

        public void Install() {
            if (!Globals.InPortableMode) {
                Uninstall();
            }
            UpdateStatus("Updating folder permissions...");
            // Create the folder
            if (Directory.Exists(installOptions.DestinationDirectory) == false) {
                Directory.CreateDirectory(installOptions.DestinationDirectory);
            }
            if (!Globals.InPortableMode) {
                // Set the folder permissions
                AclManager Acl = new AclManager(installOptions.DestinationDirectory, AclManager.GetNormalUsersGroupName(), "F");
                Acl.SetAcl();
            }
            // Time to download the installation file...
            Net.FileDownloader downloader = new Net.FileDownloader();
            // First let's subscribe to the events
            downloader.DownloadUpdate += delegate(object sender, Net.FileDownloadingEventArgs e)
            {
                // Display the progress of the download
                UpdateStatus("Downloading latest installation files... [" + e.Percent + "% complete]");
                UpdateProgress(e.Percent);
            };
            downloader.DownloadComplete += delegate(object sender, Net.FileDownloadingEventArgs e)
            {
                // The installation files have been downloaded, so we can continue installing them
                InstallationFilesDownloaded();
            };
            downloader.DownloadFailed += delegate(object sender, Net.FileDownloadErrorEventArgs e)
            {
                // Uh oh! The download failed!
            };
            // Now we actually download the file
            if (File.Exists(installOptions.DestinationDirectory + "\\InstallationFiles-MapEditor.zip")) {
                InstallationFilesDownloaded();
            } else {
                downloader.DownloadFile(installOptions.DownloadURL, installOptions.DestinationDirectory + "\\InstallationFiles-MapEditor.zip");
            }
            //if (InstallComplete != null)
            //    InstallComplete(this, EventArgs.Empty);
        }

        public void Uninstall() {
            RegistryEditor reg = new RegistryEditor();
            string regPath = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\Pokemon Mystery Universe Map Editor";
            reg.SetPath(regPath);
            if (reg.SubKeyExists()) {//if (reg.Read("Installed") == "1") {
                UpdateStatus("Found previous installed version, uninstalling...");
                string path = reg.Read("InstallPath");
                if (System.IO.Directory.Exists(path)) {
                    System.IO.Directory.Delete(path, true);
                }

                bool installAllUsers;
                if (reg.Read("AllUsers") == "1") {
                    installAllUsers = true;
                } else {
                    installAllUsers = false;
                }
                string desktopPath;
                string startMenuPath;

                if (installAllUsers) {
                    desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonDesktopDirectory);
                    startMenuPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonStartMenu);
                } else {
                    desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                    startMenuPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Startup);
                }

                if (System.IO.File.Exists(desktopPath + "\\PMU Map Editor.lnk")) {
                    System.IO.File.Delete(desktopPath + "\\PMU Map Editor.lnk");
                }

                if (System.IO.File.Exists(startMenuPath + "\\PMU Map Editor.lnk")) {
                    System.IO.File.Delete(startMenuPath + "\\PMU Map Editor.lnk");
                }

                reg.DeleteSubKey();
            }
        }

        public static bool IsInstalled() {
            RegistryEditor reg = new RegistryEditor();
            string regPath = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\Pokemon Mystery Universe Map Editor";
            reg.SetPath(regPath);
            if (reg.SubKeyExists()) {//if (reg.Read("Installed") == "1") {
                string path = reg.Read("InstallPath");
                if (System.IO.Directory.Exists(path)) {
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }

        public static string GetInstallPath() {
            RegistryEditor reg = new RegistryEditor();
            string regPath = @"Software\Microsoft\Windows\CurrentVersion\Uninstall\Pokemon Mystery Universe Map Editor";
            reg.SetPath(regPath);
            if (reg.SubKeyExists()) {//if (reg.Read("Installed") == "1") {
                string path = reg.Read("InstallPath");
                if (System.IO.Directory.Exists(path)) {
                    return path;
                } else {
                    return null;
                }
            }
            return null;
        }

        public void UpdateConfig() {
            installOptions.InstallAllUsers = configPage.optAll.Checked;
            installOptions.DestinationDirectory = Globals.Installer.DestinationDirectory.TrimEnd('\\') + "\\Map Editor";
        }

        public string GetInstallerType() {
            return "MapEditor";
        }

        public string CreateConfigString() {
            StringBuilder configString = new StringBuilder();
            // Install all users
            configString.Append("-[mapeditor]installallusers ");
            configString.Append(installOptions.InstallAllUsers.ToIntString());
            configString.Append(" ");
            // Destination directory
            configString.Append("-[mapeditor]destinationdirectory \"");
            configString.Append(installOptions.DestinationDirectory);
            configString.Append("\"");

            return configString.ToString();
        }

        public void ParseConfigString(Command configString) {
            installOptions.InstallAllUsers = configString["-[mapeditor]installallusers"].ToBool();
            installOptions.DestinationDirectory = configString["-[mapeditor]destinationdirectory"];
        }

        private void AddInstallInfoToRegistry() {
            UpdateStatus("Updating component registration...");
            File.Copy(System.Windows.Forms.Application.ExecutablePath, installOptions.DestinationDirectory.Remove(installOptions.DestinationDirectory.Length - "\\Map Editor".Length) + "\\Installer.exe", true);
            RegistryEditor reg = new RegistryEditor();
            reg.SetPath(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\Pokemon Mystery Universe Map Editor");
            reg.Write("DisplayName", "Pokemon Mystery Universe Map Editor");
            reg.Write("UninstallString", installOptions.DestinationDirectory.Remove(installOptions.DestinationDirectory.Length - "\\Map Editor".Length) + "\\Installer.exe" + " /Uninstall MapEditor");
            reg.Write("HasRepair", "0");
            reg.Write("NoModify", "1");
            reg.Write("Publisher", "PMU Team");
            reg.Write("DisplayIcon", installOptions.DestinationDirectory + "\\Graphics\\pmuicon.ico");

            reg.Write("InstallPath", installOptions.DestinationDirectory);
            reg.Write("Installed", "1");

            if (installOptions.InstallAllUsers) {
                reg.Write("AllUsers", "1");
            } else {
                reg.Write("AllUsers", "0");
            }
        }

        private void CreateShortcuts() {
            UpdateStatus("Creating shortcuts...");
            UpdateProgress(99);

            string desktopPath;
            string startMenuPath;

            if (installOptions.InstallAllUsers) {
                desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonDesktopDirectory);
                startMenuPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonStartMenu);
            } else {
                desktopPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory);
                startMenuPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Startup);
            }

            ShellShortcut shortcutDesktop = new ShellShortcut(desktopPath + "\\PMU Map Editor.lnk");
            shortcutDesktop.Description = "Start the Pokémon Mystery Universe Map Editor!";
            shortcutDesktop.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            shortcutDesktop.IconPath = installOptions.DestinationDirectory + "\\Graphics\\pmuicon.ico";
            shortcutDesktop.Path = installOptions.DestinationDirectory + "\\MapEditor.exe";
            shortcutDesktop.WorkingDirectory = installOptions.DestinationDirectory;
            shortcutDesktop.Save();

            ShellShortcut shortcutStartMenu = new ShellShortcut(startMenuPath + "\\PMU Map Editor.lnk");
            shortcutStartMenu.Description = "Start the Pokémon Mystery Universe Map Editor!";
            shortcutStartMenu.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
            shortcutStartMenu.IconPath = installOptions.DestinationDirectory + "\\Graphics\\pmuicon.ico";
            shortcutStartMenu.Path = installOptions.DestinationDirectory + "\\MapEditor.exe";
            shortcutStartMenu.WorkingDirectory = installOptions.DestinationDirectory;
            shortcutStartMenu.Save();
        }

        private void InstallationFilesDownloaded() {
            string zipToUnpack = installOptions.DestinationDirectory + "\\InstallationFiles-MapEditor.zip";
            string unpackDirectory = installOptions.DestinationDirectory;
            using (ZipFile zip1 = ZipFile.Read(zipToUnpack)) {
                // here, we extract every entry, but we could extract conditionally
                // based on entry name, size, date, checkbox status, etc.
                zip1.ExtractProgress += new EventHandler<ExtractProgressEventArgs>(zip1_ExtractProgress);
                for (int i = 0; i < zip1.Count; i++) {
                    zip1[i].Extract(unpackDirectory, ExtractExistingFileAction.OverwriteSilently);
                    UpdateProgress(i, zip1.Count);
                }
            }

            File.Delete(installOptions.DestinationDirectory + "\\InstallationFiles-MapEditor.zip");

            if (!Globals.InPortableMode) {
                // Create shortcuts
                CreateShortcuts();

                AddInstallInfoToRegistry();
            }
            // Installation complete!
            if (InstallComplete != null)
                InstallComplete(this, EventArgs.Empty);
        }

        private void UpdateProgress(int value, int maxValue) {
            if (ProgressUpdate != null)
                ProgressUpdate(this, new ProgressUpdateEventArgs(value, maxValue));
        }

        private void UpdateProgress(int percent) {
            if (ProgressUpdate != null)
                ProgressUpdate(this, new ProgressUpdateEventArgs(percent));
        }

        private void UpdateStatus(string status) {
            if (StatusUpdate != null)
                StatusUpdate(this, new StatusUpdateEventArgs(status));
        }

        void zip1_ExtractProgress(object sender, ExtractProgressEventArgs e) {
            if (e.EventType == ZipProgressEventType.Extracting_BeforeExtractEntry || e.EventType == ZipProgressEventType.Extracting_EntryBytesWritten) {
                UpdateStatus("Extracting: " + e.CurrentEntry.FileName + " [" + MathFunctions.CalculatePercent(e.BytesTransferred, e.TotalBytesToTransfer) + "% complete]");
            }
        }

        #endregion Methods

        public void Repair(string rootDirectory) {
            string mapEditorFolder = rootDirectory + "/Map Editor/";

            // Repair complete!
            if (InstallComplete != null)
                InstallComplete(this, EventArgs.Empty);
        }

        public Pages.IInstallerPage GetConfigurationPage(InstallMode mode) {
            switch (mode) {
                case InstallMode.Install: {
                        if (Globals.InPortableMode == false) {
                            return configPage;
                        } else {
                            return null;
                        }
                    }
                case InstallMode.Repair: {
                        return null;
                    }
            }
            return null;
        }
    }
}