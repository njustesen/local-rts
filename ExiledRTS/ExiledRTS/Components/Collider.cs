using ExiledRTS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Components
{
    class Collider : Component
    {
        public bool IsTrigger = false;

        public Collider(GameObject GO) : base(GO){
        }

        public Collider(GameObject GO, bool trigger)
            : base(GO)
        {
            IsTrigger = trigger;
        }

        public override void Update(float dtime)
        {
            
        }

        public override void Destroy()
        {
            
        }
    }
}
