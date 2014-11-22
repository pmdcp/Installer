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
using Net = PMU.Net;
using System.IO;

namespace Installer.Pages
{
    partial class pgeRules : InstallerPage, IInstallerPage
    {
        public pgeRules() {
            InitializeComponent();
        }

        MemoryStream rulesMemoryStream;
        public void LoadPage() {
            base.SetBanner(Properties.Resources.Banner);
            Net.FileDownloader downloader = new Net.FileDownloader();
            downloader.DownloadFailed += new EventHandler<Net.FileDownloadErrorEventArgs>(downloader_DownloadFailed);
            downloader.DownloadComplete += new EventHandler<Net.FileDownloadingEventArgs>(downloader_DownloadComplete);
            //,downloader.DownloadFile(@"http://www.pmuniverse.net/Installer/rules.rtf", System.IO.Path.GetTempFileName());
            downloader.DownloadFile(@"http://www.pmuniverse.net/Installer/rules.rtf", rulesMemoryStream = new MemoryStream());
        }

        void downloader_DownloadComplete(object sender, Net.FileDownloadingEventArgs e) {
            rtbRules.Rtf = System.Text.UnicodeEncoding.Default.GetString(rulesMemoryStream.ToArray());
            //System.IO.File.Delete(e.FilePath);
            optAgree.Enabled = true;
        }

        void downloader_DownloadFailed(object sender, Net.FileDownloadErrorEventArgs e) {
            rtbRules.Rtf = Properties.Resources.rules;
            optAgree.Enabled = true;
        }
        
        public void ClosePage() {

        }

        public void UpdateText(Translations.IStringTable stringTable) {
            lblHeader.Text = stringTable.RetrieveTranslation(Translations.MessageType.RulesHeader);
            rtbRules.Text = stringTable.RetrieveTranslation(Translations.MessageType.RulesLoading);
        }

        public InstallerPage InstallerPage {
            get { return this; }
        }

        bool validClose = false;
        public void ParentClosing(FormClosingEventArgs e) {
            if (validClose == false) {
                if (MessageBox.Show(PageManager.ActiveStringTable.RetrieveTranslation(Translations.MessageType.AttemptExit), PageManager.ActiveStringTable.RetrieveTranslation(Translations.MessageType.ExitBoxTitle), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Environment.Exit(0);
                } else {
                    e.Cancel = true;
                }
            }
        }

        private void optDisagree_CheckedChanged(object sender, EventArgs e) {
            if (optDisagree.Checked) {
                btnNext.Enabled = false;
            }
        }

        private void optAgree_CheckedChanged(object sender, EventArgs e) {
            if (optAgree.Checked) {
                btnNext.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            validClose = true;
            PageManager.ActivePage = new Pages.pgeLicense();
        }

        private void btnNext_Click(object sender, EventArgs e) {
            if (optAgree.Checked) {
                PageManager.ActivePage = new Pages.pgeModeSelect();
            }
        }

        private void rtbRules_LinkClicked(object sender, LinkClickedEventArgs e) {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
