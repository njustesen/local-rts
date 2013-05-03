using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExiledRTS.Core;
using Microsoft.Xna.Framework;
using ExiledRTS.Util;

namespace ExiledRTS.Components
{
    class Projectile : Component
    {
        public float Damage;
        private GameObject owner;

        public Projectile(GameObject go, float damage, GameObject owner) : base(go)
        {
            Damage = damage;
            Owner = owner;
        }

        public GameObject Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public override void Update(float dtime)
        {
            CollisionManager.CheckCollision(AttachedTo, AttachedTo.Position);
            
        }

        public override void OnCollision(GameObject other, Vector2 position)
        {
            var health = other.GetComponent<Health>();
            AttachedTo.MarkForDestruction();
            if (health == null)
                return;
            health.CurrentHealth -= Damage;
            Console.WriteLine(health.CurrentHealth);
            
            //other.MarkForDestruction();
        }

        public override void Destroy()
        {
            
        }
    }
}
