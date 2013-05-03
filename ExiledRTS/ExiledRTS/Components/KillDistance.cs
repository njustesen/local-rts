using ExiledRTS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExiledRTS.Components
{
    class KillDistance : Component 
    {
        Vector2 startPos;
        public KillDistance(GameObject go, float distance)
            : base(go)
        {
            startPos = go.Position;
        }

        public override void Update(float dtime)
        {

        }

        public override void Destroy()
        {
        }
    }
}
