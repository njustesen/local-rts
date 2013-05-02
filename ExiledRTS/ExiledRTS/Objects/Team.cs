using ExiledRTS.Components;
using ExiledRTS.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Objects
{
    class Team
    {
        Unit selectedUnit;
        List<GameObject> units = new List<GameObject>();

        internal List<GameObject> Units
        {
            get { return units; }
            set { units = value; }
        }

        public void AddUnit(GameObject u)
        {
            units.Add(u);
        }

        internal Unit SelectedUnit
        {
            get { return selectedUnit; }
            set { selectedUnit = value; }
        }


        internal Unit UnitWithColor(Color color)
        {
            foreach(GameObject go in units){
                if (go.GetComponent<Unit>().Color == color)
                    return go.GetComponent<Unit>();
            }
            return null;
        }
    }
}
