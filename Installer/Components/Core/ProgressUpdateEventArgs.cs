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

using PMU.Core;
namespace Installer.Components.Core
{
    class ProgressUpdateEventArgs : System.EventArgs
    {
        #region Fields

        int maxValue;
        int percent;
        int value;

        #endregion Fields

        #region Constructors

        public ProgressUpdateEventArgs(int value, int maxValue) {
            this.value = value;
            this.maxValue = maxValue;
            this.percent = MathFunctions.CalculatePercent(value, maxValue);
        }

        public ProgressUpdateEventArgs(int percent) {
            this.value = percent;
            this.maxValue = 100;
            this.percent = percent;
        }

        #endregion Constructors

        #region Properties

        public int MaxValue {
            get { return maxValue; }
        }

        public int Percent {
            get { return percent; }
        }

        public int Value {
            get { return value; }
        }

        #endregion Properties
    }
}