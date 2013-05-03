using ExiledRTS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExiledRTS.Components
{
    class Mover : Component
    {
        public float Speed
        {
            get;
            set;
        }

        public Vector2 Direction { get; set; }

       

        public Mover(GameObject go, float speed, Vector2 direction) : base(go)
        {
            Speed = speed;
            Direction = direction;
        }

        public override void Update(float dtime)
        {
            Direction.Normalize();
            AttachedTo.Position += Direction * Speed * dtime;
        }

        public override void Destroy()
        {
        }
    }
}
