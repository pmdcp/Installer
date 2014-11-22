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
using Installer.Translations;
using Installer.Pages;

namespace Installer.Pages
{
    interface IInstallerPage
    {
        /// <summary>
        /// Called when the page is loaded
        /// </summary>
        void LoadPage();
        /// <summary>
        /// Called when the page is closed
        /// </summary>
        void ClosePage();
        /// <summary>
        /// Called when an update to the text of the controls on the page need to be updated to match with the active language
        /// </summary>
        /// <param name="stringTable"></param>
        void UpdateText(IStringTable stringTable);
        /// <summary>
        /// Gets the <see cref="Installer.Pages.InstallerPage"/> instance associated with this page
        /// </summary>
        InstallerPage InstallerPage { get; }
        void ParentClosing(System.Windows.Forms.FormClosingEventArgs e);
    }
}
