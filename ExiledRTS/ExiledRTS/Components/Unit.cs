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

        public Unit(GameObject GO, Team team, SoundEffect sound, Color color, float movespeed, float attackSpeed, float projectileDistance, UnitTextures textures)
            : base(GO)
        {
            Speed = movespeed;
            this.color = color;
            CooldownToAttack = attackSpeed;
            AttackSpeed = attackSpeed;
            Team = team;
            ProjectileDistance = projectileDistance;
            Sound = sound;
            UnitTexture = textures;
        }

        public UnitTextures UnitTexture;

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

            var moveDir = oldPosition - AttachedTo.Position;
            if (moveDir != Vector2.Zero)
            {
                if (Math.Abs(moveDir.X) > Math.Abs((moveDir.Y)))
                {
                    if(moveDir.X > 0.0f) //Move left
                        AttachedTo.Renderer.SetTexture(UnitTexture.Left);
                    else if (moveDir.X < 0.0f) //Move right
                        AttachedTo.Renderer.SetTexture(UnitTexture.Right);
                }
                else if(Math.Abs(moveDir.X) < Math.Abs((moveDir.Y)))
                {
                    if (moveDir.Y < 0.0f) //Move up
                        AttachedTo.Renderer.SetTexture(UnitTexture.Up);
                    else if (moveDir.Y > 0.0f) //Move down
                        AttachedTo.Renderer.SetTexture(UnitTexture.Down);
                }
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
            if (team.TeamNumber == 1)
            {
                Random r = new Random();
                if (r.Next(2) == 0)
                    Sounds.robotDieA.Play();
                else
                    Sounds.robotDieB.Play();
            }
            else
            {
                Random r = new Random();
                if (r.Next(2) == 0)
                    Sounds.alienDieA.Play();
                else
                    Sounds.alienDieB.Play();
            }
        }
    }
}
