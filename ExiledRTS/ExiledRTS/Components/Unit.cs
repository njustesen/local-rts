using ExiledRTS.Core;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using ExiledRTS.Util;
using ExiledRTS.Objects;

namespace ExiledRTS.Components
{
    class Unit : Component
    {

        public Unit(GameObject GO, Team team, Color color, float movespeed, float attackSpeed, float projectileDistance) : base(GO)
        {
            Speed = movespeed;
            this.color = color;
            CooldownToAttack = attackSpeed;
            AttackSpeed = attackSpeed;
            Team = team;
            ProjectileDistance = projectileDistance;
        }

        public float ProjectileDistance
        { get; set; }

        public float AttackSpeed
        {
            get;
            set;
        }

        public Vector2 AttackDir
        {get; set;}

        public bool ShouldFire;

        public float CooldownToAttack
        { get; set; }

        public float Speed
        {
            get;
            set;
        }

        Team team;
        public Team Team
        {
            get { return team; }
            set { team = value; }
        }

        Vector2 velocity;
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        Vector2 oldPosition;

        public override void Update(float dtime)
        {
            CooldownToAttack -= dtime;

            oldPosition = AttachedTo.Position;

            AttachedTo.Position = new Vector2(AttachedTo.Position.X + Velocity.X, AttachedTo.Position.Y + Velocity.Y);


            if (velocity != Vector2.Zero){
                CollisionManager.CheckCollision(AttachedTo, AttachedTo.Position);
            }

            if (ShouldFire && CooldownToAttack <= 0.0f)
            {
                CooldownToAttack = AttackSpeed;
                var GO = new GameObject(AttachedTo.Position,Textures.projectile);
                GO.Components.Add(new Mover(GO, 450.0f, AttackDir));
                GO.Components.Add(new KillOutside(GO));
                GO.Components.Add(new KillDistance(GO, ProjectileDistance));
                GO.Components.Add(new Projectile(GO, 50.0f));
                GO.Components.Add(new CircleCollider(GO,3.0f,true));
                GO.Renderer.Flipped = AttachedTo.Renderer.Flipped;
                GO.Depth = AttachedTo.Depth - 0.2f;
            }
        }

        public override void OnCollision(GameObject other, Vector2 position)
        {
            if(!other.GetComponent<Collider>().IsTrigger)
                AttachedTo.Position = position;
        }

        public override void Destroy()
        {
        }
    }
}
