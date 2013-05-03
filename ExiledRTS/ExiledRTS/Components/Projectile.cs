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

        public Vector2 Velocity
        {
            get;
            set;
        }

        public Projectile(GameObject go, float damage, Vector2 velocity) : base(go)
        {
            Damage = damage;
            Velocity = velocity;
        }

        public override void Update(float dtime)
        {
            Vector2 newPosition = new Vector2(AttachedTo.Position.X + Velocity.X, AttachedTo.Position.Y + Velocity.Y);

            CollisionManager.CheckCollision(AttachedTo, newPosition);
            
        }

        public override void OnCollision(GameObject other, Vector2 position)
        {
            var health = other.GetComponent<Health>();
            health.CurrentHealth -= Damage;
            other.MarkForDestruction();
        }

        public override void Destroy()
        {
            
        }
    }
}
