using ExiledRTS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Components
{
    class SquareCollider : Collider
    {
        public SquareCollider(GameObject GO, float width, float height)
            : base(GO)
        {
            this.height = height;
            this.width = width;
        }

        private float height;
        public float Height
        {
            get { return height; }
            set { height = value; }
        }

        private float width;
        public float Width
        {
            get { return width; }
            set { width = value; }
        }
    }
}
