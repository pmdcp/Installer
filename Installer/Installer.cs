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
    using System.Threading;

    using Components.Core;
    using PMU.Core;
    using System.IO.Pipes;

    class Installer
    {
        #region Fields

        List<IComponentInstaller> components;
        int currentConfigPage;
        string destinationDirectory;

        #endregion Fields

        #region Constructors

        public Installer(string destinationDirectory) {
            components = new List<IComponentInstaller>();
            currentConfigPage = -1;
            this.destinationDirectory = destinationDirectory;
        }

        public Installer(Command command) {
            components = new List<IComponentInstaller>();
            currentConfigPage = -1;
            ImportFromArgumentString(command);
        }

        #endregion Constructors

        #region Events

        public event EventHandler InstallComplete;

        #endregion Events

        #region Properties

        public int CurrentConfigPage {
            get { return currentConfigPage; }
        }

        public string DestinationDirectory {
            get { return destinationDirectory; }
        }

        public InstallMode Mode { get; set; }

        #endregion Properties

        #region Methods

        public string CreateInstallationArgumentString() {
            StringBuilder argumentString = new StringBuilder();
            argumentString.Append("-components \"");
            for (int i = 0; i < components.Count; i++) {
                if (i != 0) {
                    argumentString.Append(",");
                }
                argumentString.Append(components[i].GetInstallerType());
            }
            argumentString.Append("\" ");
            for (int i = 0; i < components.Count; i++) {
                if (i != 0) {
                    argumentString.Append(" ");
                }
                argumentString.Append(components[i].CreateConfigString());
            }
            return argumentString.ToString();
        }

        public void ImportFromArgumentString(Command command) {
            string[] components = command["-components"].Split(',');

            foreach (string component in components) {
                IComponentInstaller installer = null;
                switch (component) {
                    case "Client": {
                            installer = new Components.ClientInstaller();
                        }
                        break;
                    case "MapEditor": {
                            installer = new Components.MapEditorInstaller();
                        }
                        break;
                }
                if (installer != null) {
                    installer.ParseConfigString(command);
                    this.components.Add(installer);
                }
            }
        }


        public void AddComponent(IComponentInstaller componentInstaller) {
            components.Add(componentInstaller);
        }

        public IComponentInstaller GetComponent(int index) {
            if (index > -1 && index < components.Count) {
                return components[index];
            } else {
                return null;
            }
        }

        public void Install(Pipes.StreamString pipeStream) {
            Thread installThread = new Thread(new ParameterizedThreadStart(InstallCallback));
            installThread.Name = "Installation Thread";
            installThread.IsBackground = true;
            installThread.Priority = ThreadPriority.Normal;
            installThread.Start(pipeStream);
        }

        public void ShowNextConfigPage() {
            if (currentConfigPage > -1) {
                components[currentConfigPage].UpdateConfig();
            }
            currentConfigPage++;
            if (currentConfigPage < components.Count) {
                if (components[currentConfigPage].GetConfigurationPage(Mode) != null) {
                    PageManager.ActivePage = components[currentConfigPage].GetConfigurationPage(Mode);
                } else {
                    ShowNextConfigPage();
                }
            } else {
                // All configuration pages have been shown, now let's show the "Ready to Install" screen
                PageManager.ActivePage = new Pages.pgeInstallReady();
            }
        }

        public void ShowPreviousConfigPage() {
            if (currentConfigPage - 1 >= 0) {
                currentConfigPage--;
                if (components[currentConfigPage].GetConfigurationPage(Mode) != null) {
                    PageManager.ActivePage = components[currentConfigPage].GetConfigurationPage(Mode);
                } else {
                    ShowPreviousConfigPage();
                }
            } else {
                switch (Mode) {
                    case InstallMode.Install: {
                            PageManager.ActivePage = new Pages.pgeComponentSelection();
                        }
                        break;
                    case InstallMode.Repair: {
                            PageManager.ActivePage = new Pages.pgeRepairComponentSelection();
                        }
                        break;
                }
            }
        }

        private void InstallCallback(Object parameter) {
            InstallComponent(0, parameter as Pipes.StreamString);
        }

        private void InstallComponent(int index, Pipes.StreamString pipeStream) {
            pipeStream.WriteString("[Component]" + components[index].Name);
            // Subscribe to the ProgressUpdate event, and update the installer pages' progress bar
            components[index].ProgressUpdate += delegate(object sender, ProgressUpdateEventArgs e)
            {
                pipeStream.WriteString("[Progress]" + e.Percent);
            };
            components[index].StatusUpdate += delegate(object sender, StatusUpdateEventArgs e)
            {
                pipeStream.WriteString("[Status]" + e.Status);
            };
            components[index].InstallComplete += delegate(object sender, EventArgs e)
            {
                if (index + 1 < components.Count) {
                    InstallComponent(index + 1, pipeStream);
                } else {
                    if (InstallComplete != null)
                        InstallComplete(this, EventArgs.Empty);
                }
            };
            switch (Mode) {
                case InstallMode.Install: {
                        components[index].Install();
                    }
                    break;
                case InstallMode.Repair: {
                        components[index].Repair(destinationDirectory);
                    }
                    break;
            }
        }

        #endregion Methods
    }
}