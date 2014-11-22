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
using System.Windows.Forms;

namespace Installer
{
    class UninstallHelper
    {
        public void RunUninstall() {
            string component = null;
            int index = Globals.CommandLine.FindCommandArg("/Uninstall");
            if (index != -1) {
                component = Globals.CommandLine[index + 1];
            }
            // We are, so let's start uninstalling
            if (System.IO.Path.GetTempPath().StartsWith(Application.StartupPath)) {
                try {
                    //frmUninstallSetup setup = new frmUninstallSetup(param);
                    //setup.Show();
                    if (!string.IsNullOrEmpty(component)) {
                        switch (component) {
                            case "Client": {
                                    if (MessageBox.Show("Are you sure you wish to uninstall Pokémon Mystery Universe?", "Uninstall", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                                        Components.ClientInstaller client = new Components.ClientInstaller();
                                        client.Uninstall();
                                        MessageBox.Show("Uninstallation complete!");
                                        System.Environment.Exit(0);
                                    }
                                }
                                break;
                            case "MapEditor": {
                                    if (MessageBox.Show("Are you sure you wish to uninstall the PMU Map Editor?", "Uninstall", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes) {
                                        Components.MapEditorInstaller mapEditor = new Components.MapEditorInstaller();
                                        mapEditor.Uninstall();
                                        MessageBox.Show("Uninstallation complete!");
                                        System.Environment.Exit(0);
                                    }
                                }
                                break;
                        }
                    }
                } catch (Exception ex) {
                    System.Windows.Forms.MessageBox.Show(ex.ToString());
                }
            } else {
                System.IO.File.Copy(Application.ExecutablePath, System.IO.Path.GetTempPath() + "Uninstaller.exe", true);
                System.Diagnostics.Process.Start(System.IO.Path.GetTempPath() + "Uninstaller.exe", "/Uninstall " + component);
                System.Environment.Exit(0);
            }
        }
    }
}
