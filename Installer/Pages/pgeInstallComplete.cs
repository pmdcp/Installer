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

    partial class pgeInstallComplete : InstallerPage, IInstallerPage
    {
        #region Constructors

        public pgeInstallComplete() {
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
        }

        public void UpdateText(Translations.IStringTable stringTable) {
            lblHeader.Text = stringTable.RetrieveTranslation(Translations.MessageType.InstallCompleteHeader);
            lblMessage.Text = stringTable.RetrieveTranslation(Translations.MessageType.InstallCompleteMessage);
            
        }

        #endregion Methods

        private void btnExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        public void ParentClosing(FormClosingEventArgs e) {
          
        }
    }
}