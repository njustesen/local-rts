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
        Vector2 lastPos;
        float MaxDistance;
        float elapsedDistance;

        public KillDistance(GameObject go, float distance)
            : base(go)
        {
            lastPos = go.Position;
            MaxDistance = distance; ;
        }

        public override void Update(float dtime)
        {
            elapsedDistance += Vector2.Distance(AttachedTo.Position, lastPos);
            if(elapsedDistance > MaxDistance)
                AttachedTo.MarkForDestruction();

            lastPos = AttachedTo.Position;
        }

        public override void Destroy()
        {
        }
    }
}
