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
using Microsoft.Xna.Framework.Audio;

namespace ExiledRTS.Components
{
    class Unit : Component
    {

        public Unit(GameObject GO, Team team, SoundEffect sound, Color color, float movespeed, float attackSpeed, float projectileDistance)
            : base(GO)
        {
            Speed = movespeed;
            this.color = color;
            CooldownToAttack = attackSpeed;
            AttackSpeed = attackSpeed;
            Team = team;
            ProjectileDistance = projectileDistance;
            Sound = sound;
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
        public bool AutoFire;
        public bool JustFired;
        public SoundEffect Sound;

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

            var newPos = new Vector2(AttachedTo.Position.X + Velocity.X, AttachedTo.Position.Y + Velocity.Y);

            if (velocity != Vector2.Zero){

                var pos = CollisionManager.CheckCollision(AttachedTo, newPos);
                if (pos == newPos)
                {
                    AttachedTo.Position = pos;
                }
            }

            if ((ShouldFire || AutoFire) && CooldownToAttack <= 0.0f)
            {
                CooldownToAttack = AttackSpeed;
                var GO = new GameObject(AttachedTo.Position, Textures.projectile);
                GO.Components.Add(new Mover(GO, 650.0f, AttackDir));
                //GO.Components.Add(new KillOutside(GO));
                GO.Components.Add(new KillDistance(GO, ProjectileDistance));
                GO.Components.Add(new Projectile(GO, 3f, AttachedTo));
                GO.Components.Add(new CircleCollider(GO, 3.0f, true));
                GO.Renderer.Flipped = AttachedTo.Renderer.Flipped;
                GO.Depth = AttachedTo.Depth - 0.2f;
                JustFired = true;
                ShouldFire = false;
                if (team.SelectedUnit == this)
                    Sound.Play();
            }
            else
            {
                JustFired = false;
            }

            
        }

        public override void OnCollision(GameObject other, Vector2 position)
        {

            bool move = true;
            if (!other.GetComponent<Collider>().IsTrigger)
            {
                if (position.X < 150f || position.X > (1280 - 150))
                {
                    if (position.Y < 55f || position.Y > (720 - 55)){
                        move = false;
                    }
                    
                }

                if (move)
                    AttachedTo.Position = position;
                
            }
        }

        public override void Destroy()
        {
        }
    }
}
