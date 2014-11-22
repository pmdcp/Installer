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
using System.Diagnostics;
using System.Threading;

namespace Installer.Pages
{
    partial class pgeInstalling : InstallerPage, IInstallerPage
    {
        bool validClose = false;

        public pgeInstalling() {
            InitializeComponent();
        }

        public void LoadPage() {
            base.SetBanner(Properties.Resources.Banner);
            btnNext.Enabled = false;

            UpdateStatus("Starting installation...");

            Thread installerLaunchThread = new Thread(new ThreadStart(StartInstallation));
            installerLaunchThread.IsBackground = true;
            installerLaunchThread.Start();
            //Globals.Installer.InstallComplete += new EventHandler(Installer_InstallComplete);
            //Globals.Installer.Install(this);
        }

        private void StartInstallation() {
            InstallerProcessHelper processHelper = new InstallerProcessHelper(this);
            processHelper.LaunchInstaller();
        }

        void Installer_InstallComplete(object sender, EventArgs e) {
            if (InvokeRequired) {
                Invoke(new InstallCompleteDelegate(InstallComplete));
            } else {
                InstallComplete();
            }
        }

        private delegate void InstallCompleteDelegate();
        public void InstallComplete() {
            if (InvokeRequired) {
                Invoke(new InstallCompleteDelegate(InstallComplete));
            } else {
                UpdateStatus("Installation complete!");
                UpdateProgress(100);
                btnNext.Enabled = true;
            }
        }

        public void ClosePage() {
        }

        public void UpdateText(Translations.IStringTable stringTable) {
        }

        public InstallerPage InstallerPage {
            get { return this; }
        }

        private delegate void UpdateStatusDelegate(string status);
        public void UpdateStatus(string status) {
            if (InvokeRequired) {
                Invoke(new UpdateStatusDelegate(UpdateStatus), status);
            } else {
                this.lblStatus.Text = "Status: " + status;
            }
        }

        private delegate void UpdateProgressDelegate(int percent);
        public void UpdateProgress(int percent) {
            if (InvokeRequired) {
                Invoke(new UpdateProgressDelegate(UpdateProgress), percent);
            } else {
                if (this.pbProgress.Maximum != 100) {
                    this.pbProgress.Maximum = 100;
                }
                this.pbProgress.Value = percent;
            }
        }

        private delegate void UpdateCurrentComponentDelegate(string componentName);
        public void UpdateCurrentComponent(string componentName) {
            if (InvokeRequired) {
                Invoke(new UpdateCurrentComponentDelegate(UpdateCurrentComponent), componentName);
            } else {
                lblProgress.Text = "Currently Installing: " + componentName;
            }
        }

        public void ParentClosing(FormClosingEventArgs e) {
            if (validClose == false) {
                e.Cancel = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e) {
            PageManager.ActivePage = new Pages.pgeInstallComplete();
        }
    }
}
