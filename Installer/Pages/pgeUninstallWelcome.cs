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

namespace Installer.Pages
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    partial class pgeUninstallWelcome : InstallerPage, IInstallerPage
    {
        #region Fields

        bool validClose = false;

        #endregion Fields

        #region Constructors

        public pgeUninstallWelcome() {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public new InstallerPage InstallerPage {
            get { return this; }
        }

        #endregion Properties

        #region Methods

        public void ClosePage() {
        }

        public void LoadPage() {
            base.SetBanner(Properties.Resources.Banner);
            btnNext.Enabled = false;
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

        public void UpdateText(Translations.IStringTable stringTable) {
            lblHeader.Text = stringTable.RetrieveTranslation(Translations.MessageType.UninstallWelcomeHeader);
            lblWelcome.Text = stringTable.RetrieveTranslation(Translations.MessageType.UninstallMessage);
            if (VistaSecurity.IsAdmin() == false) {
                if (!VistaSecurity.IsVistaOrHigher()) {
                    btnNext.Enabled = false;
                    lblError.Text = stringTable.RetrieveTranslation(Translations.MessageType.WelcomeNoAdmin);
                    lblError.Show();
                } else {
                    VistaSecurity.AddShieldToButton(btnNext);
                    btnNext.Enabled = true;
                }
            } else {
                btnNext.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e) {
            if (VistaSecurity.IsAdmin() == false) {
                if (VistaSecurity.IsVistaOrHigher()) {
                    validClose = true;
                    VistaSecurity.RestartElevated();
                }
            } else {
                validClose = true;
                PageManager.ActivePage = new Pages.pgeLicense();
            }
        }

        #endregion Methods
    }
}