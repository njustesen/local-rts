using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Util
{
    class CollisionPoint
    {
        Vector2 point;

        public CollisionPoint(Vector2 point)
        {
            this.point = point;
        }

        public Vector2 Point
        {
            get { return point; }
            set { point = value; }
        }

    }
}
