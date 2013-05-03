﻿using System;
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
                        return new CollisionPoint(oldPosition);
                    }
                }
                else if (other.GetComponent<Collider>() is SquareCollider)
                {
                    CircleCollider objCollider = (CircleCollider)gameObject.GetComponent<Collider>();
                    SquareCollider otherCollider = (SquareCollider)other.GetComponent<Collider>();

                    float distanceX = other.Position.X - newPosition.X;
                    float distanceY = other.Position.Y - newPosition.Y;

                    bool xCollision = Math.Abs(distanceX) < otherCollider.Width;
                    bool yCollision = Math.Abs(distanceY) < otherCollider.Height;

                    if (xCollision && yCollision)
                    {
                        float xMove = newPosition.X - oldPosition.X;
                        float yMove = newPosition.Y - oldPosition.Y;
                        if (oldPosition.X + objCollider.Radius < other.Position.X - otherCollider.Width/2 ||
                                oldPosition.X - objCollider.Radius > other.Position.X + otherCollider.Width / 2)
                        {
                            oldPosition.Y += yMove;
                        }
                        if (oldPosition.Y + objCollider.Radius < other.Position.Y - otherCollider.Height / 2 ||
                                oldPosition.Y - objCollider.Radius > other.Position.Y + otherCollider.Height / 2)
                        {
                            oldPosition.X += xMove;
                        }
                        return new CollisionPoint(oldPosition);
                    }
                }

            }

            return null;
        }
    }
}