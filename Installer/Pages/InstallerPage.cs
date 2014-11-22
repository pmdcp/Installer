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

    public partial class InstallerPage : UserControl
    {
        #region Constructors

        public InstallerPage()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Gets or sets whether or not the banner is visible on this page
        /// </summary>
        public bool BannerVisible
        {
            get { return pnlBanner.Visible; }
            set { pnlBanner.Visible = value; }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Changes the banners image to the one specified
        /// </summary>
        /// <param name="bannerImage">The new banner image</param>
        public void SetBanner(Image bannerImage)
        {
            pnlBanner.BackgroundImageLayout = ImageLayout.Stretch;
            pnlBanner.BackgroundImage = bannerImage;
        }

        #endregion Methods
    }
}