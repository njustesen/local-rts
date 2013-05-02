using ExiledRTS.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Components
{
    class Checkpoint
    {
        Team controller;
        internal Team Controller
        {
            get { return controller; }
            set { controller = value; }
        }

    }
}
