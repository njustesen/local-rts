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
                direction = direction.GetNormalized() * ((direction.Length() - deadZone) / (1 - deadZone));             
            }

            //if (direction.Length() > 0.95f)
            //{
            //    float magnitude = 0.95f;
            //    direction.Normalize();
            //    direction.X = direction.X * magnitude;
            //    direction.Y = direction.Y * magnitude;
            //}
            return direction;
        }

        public static bool AnyButtonPressed(GamePadState state)
        {
            bool anyPressed = false;
            var buttons = state.Buttons;
            anyPressed |= buttons.A == ButtonState.Pressed;
            anyPressed |= buttons.B == ButtonState.Pressed;
            anyPressed |= buttons.Y == ButtonState.Pressed;
            anyPressed |= buttons.X == ButtonState.Pressed;
            anyPressed |= buttons.LeftShoulder == ButtonState.Pressed;
            anyPressed |= buttons.RightShoulder == ButtonState.Pressed;
            anyPressed |= buttons.Start == ButtonState.Pressed;
            anyPressed |= state.Triggers.Left > 0.5f;
            anyPressed |= state.Triggers.Right > 0.5f;
            return anyPressed;
        }
    }
}
