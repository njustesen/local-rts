using ExiledRTS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Components
{
    class CircleCollider : Collider
    {

        public CircleCollider(GameObject GO, float radius) : base(GO){
            this.radius = radius;
        }

        public CircleCollider(GameObject GO, float radius, bool isTrigger)
            : base(GO, isTrigger)
        {
            this.radius = radius;
        }

        private float radius;
        public float Radius
        {
            get { return radius; }
            set { radius = value; }
        }

    }
}
