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

namespace Installer.Components.Core
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PMU.Core;

    interface IComponentInstaller
    {
        #region Events

        event EventHandler InstallComplete;

        event EventHandler<ProgressUpdateEventArgs> ProgressUpdate;

        event EventHandler<StatusUpdateEventArgs> StatusUpdate;

        #endregion Events

        #region Properties

        ComponentInstallOptions InstallOptions {
            get;
        }

        string Name {
            get;
        }

        #endregion Properties

        #region Methods

        void Install();

        void UpdateConfig();

        string CreateConfigString();

        string GetInstallerType();

        void ParseConfigString(Command configString);

        void Uninstall();

        void Repair(string rootDirectory);

        Pages.IInstallerPage GetConfigurationPage(InstallMode mode);

        #endregion Methods
    }
}