using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using ExiledRTS.Core;
using ExiledRTS.Components;

namespace ExiledRTS.Util
{
    class CollisionManager
    {

        internal static Vector2 CheckCollision(GameObject gameObject, Vector2 position)
        {
            
            foreach (GameObject other in GameObject.GameObjects)
            {

                if (other == gameObject){
                    continue;
                }

                Projectile projectile = gameObject.GetComponent<Projectile>();
                Projectile projectileOther = other.GetComponent<Projectile>();
                if ((projectile != null && projectile.Owner == other) || (projectileOther != null && projectileOther.Owner == gameObject))
                {
                    continue;
                }

                Collider otherCollider = other.GetComponent<Collider>();

                if (otherCollider == null)
                {
                    continue;
                }

                 // if inside
                CollisionPoint collisionPoint = FindCollisionPoint(gameObject, other, gameObject.Position, position);
                if (collisionPoint != null)
                {
                    position = collisionPoint.Point;
                    gameObject.OnCollision(other, position);
                }
            }

            return position;

        }

        private static CollisionPoint FindCollisionPoint(GameObject gameObject, GameObject other, Vector2 oldPosition, Vector2 newPosition)
        {
            
            if (gameObject.GetComponent<Collider>() is CircleCollider){

                if (other.GetComponent<Collider>() is CircleCollider)
                {
                    CircleCollider objCollider = (CircleCollider) gameObject.GetComponent<Collider>();
                    CircleCollider otherCollider = (CircleCollider) other.GetComponent<Collider>();

                    float distance = Vector2.Distance(newPosition, other.Position);

                    if (distance < objCollider.Radius + otherCollider.Radius)
                    {
                        return new CollisionPoint(oldPosition);
                    }
                }
                else if (other.GetComponent<Collider>() is SquareCollider)
                {
                    CircleCollider objCollider = (CircleCollider)gameObject.GetComponent<Collider>();
                    SquareCollider otherCollider = (SquareCollider)other.GetComponent<Collider>();

                    float distanceX = other.Position.X - newPosition.X;
                    float distanceY = other.Position.Y - newPosition.Y;

                    bool xCollision = Math.Abs(distanceX) < otherCollider.Width/2 + objCollider.Radius;
                    bool yCollision = Math.Abs(distanceY) < otherCollider.Height / 2 + objCollider.Radius;

                    if (xCollision && yCollision)
                    {
                        float xMove = newPosition.X - oldPosition.X;
                        float yMove = newPosition.Y - oldPosition.Y;
                        if (oldPosition.X + objCollider.Radius < other.Position.X - otherCollider.Width/2 ||
                                oldPosition.X - objCollider.Radius > other.Position.X + otherCollider.Width / 2)
                        {
                            oldPosition.Y += yMove;
                            //newPosition = new Vector2(0f, oldPosition.Y + yMove);
                            
                        }
                        if (oldPosition.Y + objCollider.Radius < other.Position.Y - otherCollider.Height / 2 ||
                                oldPosition.Y - objCollider.Radius > other.Position.Y + otherCollider.Height / 2)
                        {
                            oldPosition.X += xMove;
                            //newPosition.X += oldPosition.X + xMove;
                            //newPosition = new Vector2(oldPosition.X + xMove, 0f);
                        }
                        return new CollisionPoint(oldPosition);
                    }
                }

            }

            return null;
        }
    }
}
