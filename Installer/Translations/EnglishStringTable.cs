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

namespace Installer.Translations
{
    class EnglishStringTable : IStringTable
    {
        const string WELCOME_HEADER = "Welcome to the Pokémon Mystery Universe installer!";
        const string WELCOME_MESSAGE = "Welcome to the Pokémon Mystery Universe installer! This program will help you to install Pokémon Mystery Universe on your computer." +
            "\n\nIt is strongly recommended that before proceeding, you ensure that no other Windows programs are running." +
            "\n\nIf you do not wish to install Pokémon Mystery Universe, click 'Exit' now; otherwise, click 'Next' to continue.";
        const string WELCOME_NOADMIN = "You are not running this installer as an Administrator. Setup is unable to continue. Please run this installer as an Administrator to install the game.";
        const string ATTEMPT_EXIT = "Installation is not yet complete. Are you sure you wish to cancel?";
        const string LICENSE_HEADER = "License Agreement";
        const string LICENSE_LOADING = "Loading license...";
        const string LICENSE_LOADING_ERROR = "Unable to load most up-to-date license. The most up-to-date license may be viewed on the PMU website.";

        const string RULES_HEADER = "Rules";
        const string RULES_LOADING = "Loading rules...";
        const string RULES_LOADING_ERROR = "Unable to load most up-to-date rules. The most up-to-date rules may be viewed on the PMU website.";

        const string UNINSTALL_HEADER = "Welcome to the Pokémon Mystery Universe uninstaller!";
        const string UNINSTALL_MESSAGE = "Welcome to the Pokémon Mystery Universe uninstaller! This program will help you to uninstall Pokémon Mystery Universe on your computer." +
            "\n\nIt is strongly recommended that before proceeding, you ensure that no other Windows programs are running." +
            "\n\nIf you do not wish to uninstall Pokémon Mystery Universe, click 'Exit' now; otherwise, click 'Next' to continue.";


        public string RetrieveTranslation(MessageType messageType) {
            switch (messageType) {
                case MessageType.AttemptExit:
                    return ATTEMPT_EXIT;
                case MessageType.WelcomeHeader:
                    return WELCOME_HEADER;
                case MessageType.WelcomeMessage:
                    return WELCOME_MESSAGE;
                case MessageType.WelcomeNoAdmin:
                    return WELCOME_NOADMIN;
                case MessageType.ExitBoxTitle:
                    return "Exit?";
                case MessageType.LicenseHeader:
                    return LICENSE_HEADER;
                case MessageType.LicenseLoading:
                    return LICENSE_LOADING;
                case MessageType.LicenseLoadingError:
                    return LICENSE_LOADING_ERROR;
                case MessageType.RulesHeader:
                    return RULES_HEADER;
                case MessageType.RulesLoading:
                    return RULES_LOADING;
                case MessageType.RulesLoadingError:
                    return RULES_LOADING_ERROR;
                case MessageType.InstallCompleteHeader:
                    return "Installation Complete!";
                case MessageType.InstallCompleteMessage:
                    return "Installation is complete!";
                case MessageType.UninstallWelcomeHeader:
                    return UNINSTALL_HEADER;
                case MessageType.UninstallMessage:
                    return UNINSTALL_MESSAGE;
                default:
                    return null;
            }
        }
    }
}
