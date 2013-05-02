using ExiledRTS.Core;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using ExiledRTS.Util;

namespace ExiledRTS.Components
{
    class Unit : Component
    {

        public Unit(GameObject GO, Color color, float speed) : base(GO)
        {
            this.color = color;
        }

        Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public override void Update(float dtime)
        {

            Vector2 newPosition = new Vector2(AttachedTo.Position.X + velocity.X, AttachedTo.Position.Y + velocity.Y);

            if (velocity != Vector2.Zero){
                AttachedTo.Position = CollisionManager.CheckCollision(AttachedTo, newPosition);
            }
        }

        public override void Destroy()
        {
            throw new NotImplementedException();
        }
    }
}
