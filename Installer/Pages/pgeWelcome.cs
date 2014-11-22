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

    partial class pgeWelcome : InstallerPage, IInstallerPage
    {
        bool validClose = false;

        #region Constructors

        public pgeWelcome() {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public InstallerPage InstallerPage {
            get { return this; }
        }

        #endregion Properties

        #region Methods

        public void ClosePage() {

        }

        public void LoadPage() {
            base.SetBanner(Properties.Resources.Banner);
            //btnNext.Enabled = false;
            Version version = new Version(Application.ProductVersion);
            label1.Text = "Rev " + version.Revision;
        }

        public void UpdateText(Translations.IStringTable stringTable) {
            lblHeader.Text = stringTable.RetrieveTranslation(Translations.MessageType.WelcomeHeader);
            lblWelcome.Text = stringTable.RetrieveTranslation(Translations.MessageType.WelcomeMessage);
            //if (VistaSecurity.IsAdmin() == false) {
            //    chkPortableMode.Enabled = false;
            //    chkPortableMode.Checked = true;
            //    if (!VistaSecurity.IsVistaOrHigher()) {
            //        //btnNext.Enabled = false;
            //        lblError.Text = stringTable.RetrieveTranslation(Translations.MessageType.WelcomeNoAdmin);
            //        lblError.Show();
            //        exclamationImage.Show();
            //    } else {
            //        btnRestartAsAdmin.Show();
            //        VistaSecurity.AddShieldToButton(btnRestartAsAdmin);
            //        lblError.Text = "To fully install this program, you will need to run this installer as an Administrator. To do so, you may click the button below. However, you may still continue installing by installing PMU as a portable application.";
            //        lblError.Show();
            //        exclamationImage.Show();
            //    }
            //}
        }

        #endregion Methods

        private void btnNext_Click(object sender, EventArgs e) {
            //if (VistaSecurity.IsAdmin() == false) {
            //    if (VistaSecurity.IsVistaOrHigher()) {
            //        validClose = true;
            //        VistaSecurity.RestartElevated();
            //    }
            //} else {
            Globals.InPortableMode = chkPortableMode.Checked;
            validClose = true;
            PageManager.ActivePage = new Pages.pgeLicense();
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Application.Exit();
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

        private void btnRestartAsAdmin_Click(object sender, EventArgs e) {
            if (VistaSecurity.IsVistaOrHigher()) {
                validClose = true;
                VistaSecurity.RestartElevated();
            }
        }
    }
}