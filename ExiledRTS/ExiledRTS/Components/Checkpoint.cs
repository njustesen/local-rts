using ExiledRTS.Core;
using ExiledRTS.Objects;
using ExiledRTS.Util;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Components
{
    class Checkpoint : Component
    {

        public Checkpoint(GameObject GO, float controlDistance)
            : base(GO)
        {
            this.controlDistance = controlDistance;
        }

        float controlDistance;
        internal float ControlDistance
        {
            get { return controlDistance; }
            set { controlDistance = value; }
        }

        Team controller;
        internal Team Controller
        {
            get { return controller; }
            set { controller = value; }
        }

        public override void Update(float dtime)
        {

            //AttachedTo.Renderer.SetTexture(Textures.checkpoint);
            bool teamAInRange = false;
            bool teamBInRange = false;
            Team controlTeam = null;
            foreach (GameObject obj in GameObject.GameObjects)
            {

                

                Unit unit = obj.GetComponent<Unit>();

                if (unit != null && Vector2.Distance(AttachedTo.Position, obj.Position) <= controlDistance){

                    if (unit.Team.TeamNumber == 1){
                        teamAInRange = true;
                        controlTeam = unit.Team;
                    }
                    else if (unit.Team.TeamNumber == 2)
                    {
                        teamBInRange = true;
                        controlTeam = unit.Team;
                    }

                }
            }

            if ((teamAInRange && !teamBInRange) || (teamBInRange && !teamAInRange))
                {
                    controller = controlTeam;

                    if (controlTeam.TeamNumber == 1)
                    {
                        AttachedTo.Renderer.SetTexture(Textures.checkpointA);
                    }
                    else if (controlTeam.TeamNumber == 2)
                    {
                        AttachedTo.Renderer.SetTexture(Textures.checkpointB);
                    }

                } else if (teamAInRange && teamBInRange) {
                controller = null;
                AttachedTo.Renderer.SetTexture(Textures.checkpoint);
            }

        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
