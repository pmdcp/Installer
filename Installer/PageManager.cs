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
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    using Pages;
    using Translations;

    class PageManager
    {
        #region Fields

        static IInstallerPage activePage;
        static IStringTable activeStringTable;
        static Panel pageContainer;

        #endregion Fields

        #region Properties

        public static IInstallerPage ActivePage {
            get { return activePage; }
            set {
                // Close the current active page
                if (activePage != null) {
                    pageContainer.Controls.Remove(activePage.InstallerPage);
                    activePage.ClosePage();
                }
                activePage = value;
                value.LoadPage();
                activePage.UpdateText(activeStringTable);
                pageContainer.Controls.Add(activePage.InstallerPage);
            }
        }

        public static IStringTable ActiveStringTable {
            get { return activeStringTable; }
            set {
                activeStringTable = value;
                if (activePage != null)
                    activePage.UpdateText(activeStringTable);
            }
        }

        public static Panel PageContainer {
            get { return pageContainer; }
        }

        #endregion Properties

        #region Methods

        public static void Initialize(Size containerSize) {
            pageContainer = new Panel();
            pageContainer.Name = "pageContainer";
            pageContainer.Location = new Point(0, 0);
            pageContainer.Size = containerSize;
        }

        #endregion Methods
    }
}