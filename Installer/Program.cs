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
    using System.Windows.Forms;
    using PMU.Core;

    static class Program
    {
        #region Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            frmInstaller frmInstaller = new frmInstaller();

            // Read the command line arguments
            Globals.CommandLine = CommandProcessor.ParseCommand(System.Environment.CommandLine);
            // Set the language of the installer to English
            PageManager.ActiveStringTable = new Translations.EnglishStringTable();

            MaintenanceHelper.RunProperMode(Globals.CommandLine);

            Application.Run(frmInstaller);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) {
            if (!Globals.IsSilentInstall) {
                MessageBox.Show(((Exception)e.ExceptionObject).ToString());
            } else {
                Globals.SilentInstallCommunicationPipeStream.WriteString("[Error]" + e.ToString());
                Globals.SilentInstallCommunicationPipe.WaitForPipeDrain();
                Globals.SilentInstallCommunicationPipe.Close();
                System.Environment.Exit(0);
            }
        }

        #endregion Methods
    }
}