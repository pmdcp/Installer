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
    partial class pgeMapEditorInstallOptions : InstallerPage, IInstallerPage
    {
        bool validClose = false;
        public pgeMapEditorInstallOptions() {
            InitializeComponent();
        }

        public void LoadPage() {
            base.SetBanner(Properties.Resources.Banner);
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

        private void btnBack_Click(object sender, EventArgs e) {
            Globals.Installer.ShowPreviousConfigPage();
        }

        private void btnNext_Click(object sender, EventArgs e) {
            Globals.Installer.ShowNextConfigPage();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
