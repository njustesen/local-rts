using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExiledRTS.Core;

namespace ExiledRTS.Components
{
    class Health : Component
    {
        public float CurrentHealth;

        public bool IsDead
        {
            get { return CurrentHealth <= 0.0f; }
        }

        public Health (GameObject go, float startHealth) : base(go)
        {
            CurrentHealth = startHealth;
        }

        public override void Update(float dtime)
        {
        }

        public override void Destroy()
        {
        }
    }
}
