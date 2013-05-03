using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Core
{
    public abstract class Component
    {
        public GameObject AttachedTo
        {
            get;
            private set;
        }

        public Component(GameObject attachedTo)
        {
            AttachedTo = attachedTo;
        }

        public virtual void OnCollision(GameObject other, Vector2 position)
        {

        }

        public abstract void Update(float dtime);

        public abstract void Destroy();
    }
}
