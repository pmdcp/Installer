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
using System.Linq;
using System.Text;
using Installer.Pages;
using System.Diagnostics;
using System.IO.Pipes;

using PMU.Core;
using System.Threading;

namespace Installer
{
    class InstallerProcessHelper
    {
        pgeInstalling installPage;
        NamedPipeServerStream pipeServer;

        public InstallerProcessHelper(pgeInstalling installPage) {
            this.installPage = installPage;
        }

        public void LaunchInstaller() {
            // Start the pipe server before launching the process
            Thread pipeServerThread = new Thread(new ThreadStart(CreatePipeServer));
            pipeServerThread.IsBackground = true;
            pipeServerThread.Start();

            LaunchProcess();
        }

        private void LaunchProcess() {
            ProcessStartInfo processStartInfo = new ProcessStartInfo(PMU.Core.Environment.StartupPath, "-silentinstall -portable " + Globals.InPortableMode.ToIntString() + " " + Globals.Installer.CreateInstallationArgumentString());
            processStartInfo.UseShellExecute = true;
            if (VistaSecurity.IsAdmin() == false && Globals.InPortableMode == false) {
                // Start the process as an administrator
                processStartInfo.Verb = "runas";
            }

            try {
                Process process = Process.Start(processStartInfo);
            } catch (System.ComponentModel.Win32Exception) {
                System.Windows.Forms.MessageBox.Show("You have chosen to cancel the installation.");
                System.Environment.Exit(0);
            }
        }

        private void CreatePipeServer() {
            pipeServer = new NamedPipeServerStream("www.pmuniverse.net-installer", PipeDirection.InOut, 1, (PipeTransmissionMode)0, PipeOptions.Asynchronous);

            pipeServer.WaitForConnection();
            //pipeServer.BeginWaitForConnection(new AsyncCallback(PipeConnected), pipeServer);

            Pipes.StreamString streamString = new Pipes.StreamString(pipeServer);

            while (pipeServer.IsConnected) {
                string line = streamString.ReadString();

                if (!string.IsNullOrEmpty(line)) {

                    if (line.StartsWith("[Status]")) {
                        installPage.UpdateStatus(line.Substring("[Status]".Length));
                    } else if (line.StartsWith("[Progress]")) {
                        installPage.UpdateProgress(line.Substring("[Progress]".Length).ToInt());
                    } else if (line.StartsWith("[Component]")) {
                        installPage.UpdateCurrentComponent(line.Substring("[Component]".Length));
                    } else if (line == "[Error]") {
                        throw new Exception(line.Substring("[Error]".Length));                    
                    } else if (line == "[InstallComplete]") {
                        installPage.InstallComplete();
                        break;
                    }

                }
            }

            pipeServer.Close();
        }

        private void PipeConnected(IAsyncResult asyncResult) {
            NamedPipeServerStream pipeServer = asyncResult.AsyncState as NamedPipeServerStream;
            pipeServer.EndWaitForConnection(asyncResult);

            Pipes.StreamString streamString = new Pipes.StreamString(pipeServer);

            while (pipeServer.IsConnected) {
                string line = streamString.ReadString();

                if (!string.IsNullOrEmpty(line)) {

                    if (line.StartsWith("[Status]")) {
                        installPage.UpdateStatus(line.Substring("[Status]".Length));
                    } else if (line.StartsWith("[Progress]")) {
                        installPage.UpdateProgress(line.Substring("[Progress]".Length).ToInt());
                    } else if (line.StartsWith("[Component]")) {
                        installPage.UpdateCurrentComponent(line.Substring("[Component]".Length));
                    } else if (line == "[InstallComplete]") {
                        installPage.InstallComplete();
                        break;
                    }

                }
            }

            pipeServer.Close();
        }
    }
}
