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

        ControlTimer controlTimer;
        internal ControlTimer ControlTimer
        {
            get { return controlTimer; }
            set { controlTimer = value; }
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

            // Find nearby units
            foreach (GameObject obj in GameObject.GameObjects)
            {
                Unit unit = obj.GetComponent<Unit>();

                if (unit != null && Vector2.Distance(AttachedTo.Position, obj.Position) <= controlDistance)
                {

                    if (unit.Team.TeamNumber == 1)
                    {
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

            // ..
            if ((teamAInRange && !teamBInRange) || (teamBInRange && !teamAInRange))
            {

                //if (controller == null)
                //{
                if (controlTimer == null && controlTeam != controller)
                {
                    controlTimer = new ControlTimer(controlTeam);
                }
                else if (controlTimer != null && controlTimer.Conquerer == controlTeam)
                {
                    controlTimer.Time += dtime;
                    if (controlTimer.Time >= ControlTimer.maxTime)
                    {
                        controller = controlTeam;
                        controlTimer = null;
                    }
                }
                else if (controlTimer != null && controlTimer.Conquerer != controlTeam)
                {
                    controlTimer = new ControlTimer(controlTeam);
                }
                //}
            }

            if (controller != null)
            {
                if (controller.TeamNumber == 1)
                {
                    AttachedTo.Renderer.SetTexture(Textures.checkpointA);
                }
                else if (controller.TeamNumber == 2)
                {
                    AttachedTo.Renderer.SetTexture(Textures.checkpointB);
                }

            }
            else
            {
                AttachedTo.Renderer.SetTexture(Textures.checkpoint);
            }

        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
