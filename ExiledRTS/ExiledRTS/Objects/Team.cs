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
        int teamNumber;
        List<GameObject> units = new List<GameObject>();
        float points = 0.0f;

        public float Points
        {
            get { return points; }
            set { points = value; }
        }

        internal List<GameObject> Units
        {
            get { return units; }
            set { units = value; }
        }

        internal int TeamNumber
        {
            get { return teamNumber; }
            set { teamNumber = value; }
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

        internal void SelectUnit(Unit unit)
        {
            if (selectedUnit == unit)
            {
                selectedUnit = null;
            }
            else
            {

                if (selectedUnit != null)
                {
                    selectedUnit.Velocity = new Vector2(0, 0);
                }

                selectedUnit = unit;
                
            }
        }
    }
}
