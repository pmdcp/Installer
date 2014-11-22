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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Installer
{
    public partial class frmInstaller : Form
    {
        public frmInstaller() {
            InitializeComponent();

            this.Icon = Properties.Resources.PMUInstaller;

            PageManager.Initialize(this.Size);
            this.Controls.Add(PageManager.PageContainer);

            this.FormClosing += new FormClosingEventHandler(frmInstaller_FormClosing);
        }

        void frmInstaller_FormClosing(object sender, FormClosingEventArgs e) {
            if (PageManager.ActivePage != null) {
                PageManager.ActivePage.ParentClosing(e);
            }
        }
    }
}
