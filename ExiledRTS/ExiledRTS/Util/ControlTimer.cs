using ExiledRTS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Components
{
    class ControlTimer
    {

        public static float maxTime = 8f;

        public ControlTimer(Team conquerer)
        {
            this.conquerer = conquerer;
        }

        float time;
        public float Time
        {
            get { return time; }
            set { time = value; }
        }

        Team conquerer;
        public Team Conquerer
        {
            get { return conquerer; }
            set { conquerer = value; }
        }

    }
}
