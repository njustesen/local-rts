using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExiledRTS.Util
{
    class InputManager
    {
        public static GamePadState playerOneState;
        public static GamePadState playerTwoState;

        public static Vector2 ThumbMovement(Vector2 state)
        {
            float xb = state.X;
            float yb = state.Y;

            Vector2 direction = new Vector2(xb, yb);

            float deadZone = 0.3f;
            if (direction.Length() < deadZone)
            {
                direction = Vector2.Zero;
            }
            else
            {
                float magnitude = ((direction.Length() - deadZone) / (1 - deadZone));
                direction.Normalize();
                direction.X = direction.X * magnitude;
                direction.Y = direction.Y * magnitude;
            }

            if (direction.Length() > 0.95f)
            {
                float magnitude = 0.95f;
                direction.Normalize();
                direction.X = direction.X * magnitude;
                direction.Y = direction.Y * magnitude;
            }
            return direction;
        }
    }
}
