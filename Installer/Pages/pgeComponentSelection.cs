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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Installer.Pages
{
    partial class pgeComponentSelection : InstallerPage, IInstallerPage
    {
        bool validClose = false;

        public pgeComponentSelection() {
            InitializeComponent();
        }

        public void LoadPage() {
            base.SetBanner(Properties.Resources.Banner);
            btnNext.Enabled = CanContinue();
            if (Globals.InPortableMode == false) {
                txtInstallDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + "\\Pokemon Mystery Universe";
            } else {
                txtInstallDir.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Pokemon Mystery Universe";
            }
#if DEBUG1
            txtInstallDir.Text = "C:\\InstallerTest";
#endif
        }

        public void ClosePage() {
        }

        public void UpdateText(Translations.IStringTable stringTable) {
        }

        public InstallerPage InstallerPage {
            get { return this; }
        }

        public void ParentClosing(FormClosingEventArgs e) {
            if (validClose == false) {
                if (MessageBox.Show(PageManager.ActiveStringTable.RetrieveTranslation(Translations.MessageType.AttemptExit), PageManager.ActiveStringTable.RetrieveTranslation(Translations.MessageType.ExitBoxTitle), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Environment.Exit(0);
                } else {
                    e.Cancel = true;
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.SelectedPath = txtInstallDir.Text;
            fbd.Description = "Select the folder where Pokémon Mystery Universe will be installed to.";
            if (fbd.ShowDialog() == DialogResult.OK) {
                txtInstallDir.Text = fbd.SelectedPath;
            }
        }

        private void btnNext_Click(object sender, EventArgs e) {
            Globals.Installer = new Installer(txtInstallDir.Text);
            Globals.Installer.Mode = InstallMode.Install;

            if (chkClient.Checked) {
                Globals.Installer.AddComponent(new Components.ClientInstaller());
            }
            if (chkMapEditor.Checked) {
                Globals.Installer.AddComponent(new Components.MapEditorInstaller());
            }

            Globals.Installer.ShowNextConfigPage();
        }

        private bool CanContinue() {
            if (chkClient.Checked)
                return true;
            else if (chkMapEditor.Checked)
                return true;
            else
                return false;
        }

        private void chkClient_CheckedChanged(object sender, EventArgs e) {
            btnNext.Enabled = CanContinue();
        }

        private void chkMapEditor_CheckedChanged(object sender, EventArgs e) {
            btnNext.Enabled = CanContinue();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            PageManager.ActivePage = new pgeModeSelect();
        }
    }
}
