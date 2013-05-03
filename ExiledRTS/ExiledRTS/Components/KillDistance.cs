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
        float MaxDistance;
        public KillDistance(GameObject go, float distance)
            : base(go)
        {
            startPos = go.Position;
            MaxDistance = distance; ;
        }

        public override void Update(float dtime)
        {
            if (Vector2.DistanceSquared(AttachedTo.Position, startPos) > MaxDistance * MaxDistance)
                AttachedTo.MarkForDestruction();
        }

        public override void Destroy()
        {
        }
    }
}
