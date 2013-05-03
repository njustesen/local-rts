using ExiledRTS.Core;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Components
{
    class KillOutside : Component
    {
        public KillOutside(GameObject go ) :base(go){}

        public override void Update(float dtime)
        {
            Rectangle gameArea = new Rectangle(-100,-100,1400,800);
            if (!gameArea.Contains(AttachedTo.Position.ToPoint()))
            {
                AttachedTo.MarkForDestruction();
            }
        }

        public override void Destroy()
        {
        }
    }
}
