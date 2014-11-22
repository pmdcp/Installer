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

using PMU.Core;
using System.Diagnostics;
using System.IO.Pipes;
using System.Threading;

namespace Installer
{
    class MaintenanceHelper
    {
        static ManualResetEvent installWaitEvent;

        public static void RunProperMode(Command command) {
            if (command.ContainsCommandArg("/Uninstall")) { // Are we in uninstall-mode?
                UninstallHelper uninstallHelper = new UninstallHelper();
                uninstallHelper.RunUninstall();
            } else if (command.ContainsCommandArg("-silentinstall")) {
                Globals.InPortableMode = command["-portable"].ToBool();
                Globals.IsSilentInstall = true;
                NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "www.pmuniverse.net-installer", PipeDirection.InOut, PipeOptions.None, System.Security.Principal.TokenImpersonationLevel.Impersonation);
                pipeClient.Connect();
                Pipes.StreamString clientStream = new Pipes.StreamString(pipeClient);
                Globals.SilentInstallCommunicationPipeStream = clientStream;
                Globals.SilentInstallCommunicationPipe = pipeClient;
                installWaitEvent = new ManualResetEvent(false);
                Installer installer = new Installer(command);
                installer.InstallComplete += new EventHandler(installer_InstallComplete);
                installer.Install(clientStream);

                installWaitEvent.WaitOne();

                clientStream.WriteString("[InstallComplete]");

                pipeClient.WaitForPipeDrain();
                pipeClient.Close();

                System.Environment.Exit(0);
            } else {
                // There are no special command line arguments, run the installer in install mode
                // Let's check if we elevated ourselves
                if (!Globals.CommandLine.ContainsCommandArg("/skipwelcome") || !VistaSecurity.IsAdmin()) {
                    // Show the welcome page
                    PageManager.ActivePage = new Pages.pgeWelcome();
                } else {
                    // Show the license page
                    PageManager.ActivePage = new Pages.pgeLicense();
                }
            }
        }

        static void installer_InstallComplete(object sender, EventArgs e) {
            installWaitEvent.Set();
        }

    }
}
