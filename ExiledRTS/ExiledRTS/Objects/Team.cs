using ExiledRTS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Objects
{
    class Team
    {
        Unit selectedUnit;
        List<Unit> units;

        internal List<Unit> Units
        {
            get { return units; }
            set { units = value; }
        }

        internal Unit SelectedUnit
        {
            get { return selectedUnit; }
            set { selectedUnit = value; }
        }

    }
}
