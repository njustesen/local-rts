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

                Collider collider = other.GetComponent<Collider>();

                if (collider == null)
                {
                    continue;
                }

                 // if inside
                CollisionPoint collisionPoint = FindCollisionPoint(gameObject, other, gameObject.Position, position);
                if (collisionPoint != null)
                {
                    position = collisionPoint.Point;
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
                    CircleCollider otherCollider = (CircleCollider) gameObject.GetComponent<Collider>();

                    float distance = Vector2.Distance(newPosition, other.Position);

                    if (distance < objCollider.Radius + otherCollider.Radius)
                    {
                        /*
                        distance -= (objCollider.Radius + otherCollider.Radius);
                        distance = distance * -1;
                        Vector2 move = newPosition - oldPosition;
                        move.Normalize();
                        move = new Vector2(move.X * distance, move.Y * distance);
                        return new CollisionPoint(new Vector2(oldPosition.X + move.X, oldPosition.Y + move.Y));
                        */
                        return new CollisionPoint(oldPosition);

                    }
                    
                }

            }

            return null;
        }
    }
}
