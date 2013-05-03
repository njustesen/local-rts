using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
using ExiledRTS.Objects;
using ExiledRTS.Core;
using ExiledRTS.Components;
using ExiledRTS.GameScreen;
using ExiledRTS.Util;

namespace ExiledRTS.GameScreen
{
    /// <summary>
    /// A screen where you can see who made the game.
    /// </summary>
    class GameScreen : IGameScreen
    {
        public GameScreenManager ScreenManager { get; set; }
        Team teamA;
        Team teamB;

        /// <summary>
        /// Initializes and gets all assets for this screen
        /// </summary>
        public void Initialize()
        {
            // TODO: use this.Content to load your game content here
            StartGame();
        }

        public void StartGame()
        {
            teamA = new Team();
            GameObject unit = new GameObject(new Vector2(200, 150), Textures.yellowTank);
            unit.Depth = 0.5f;
            unit.Components.Add(new Unit(unit, Color.Yellow, 4.0f));
            unit.Components.Add(new CircleCollider(unit, 16));
            teamA.AddUnit(unit);

            unit = new GameObject(new Vector2(200, 250), Textures.redTank);
            unit.Depth = 0.5f;
            unit.Components.Add(new Unit(unit, Color.Red, 4.0f));
            unit.Components.Add(new CircleCollider(unit, 16));
            teamA.AddUnit(unit);

            unit = new GameObject(new Vector2(200, 350), Textures.greenTank);
            unit.Depth = 0.5f;
            unit.Components.Add(new Unit(unit, Color.Green, 4.0f));
            unit.Components.Add(new CircleCollider(unit, 16));
            teamA.AddUnit(unit);

            unit = new GameObject(new Vector2(200, 450), Textures.blueTank);
            unit.Depth = 0.5f;
            unit.Components.Add(new Unit(unit, Color.Blue, 4.0f));
            unit.Components.Add(new CircleCollider(unit, 16));
            teamA.AddUnit(unit);

            teamB = new Team();
            unit = new GameObject(new Vector2(924, 150), Textures.yellowTank);
            unit.Depth = 0.5f;
            unit.Components.Add(new Unit(unit, Color.Yellow, 4.0f));
            unit.Components.Add(new CircleCollider(unit, 16));
            teamB.AddUnit(unit);

            unit = new GameObject(new Vector2(924, 250), Textures.redTank);
            unit.Depth = 0.5f;
            unit.Components.Add(new Unit(unit, Color.Red, 4.0f));
            unit.Components.Add(new CircleCollider(unit, 16));
            teamB.AddUnit(unit);

            unit = new GameObject(new Vector2(924, 350), Textures.greenTank);
            unit.Depth = 0.5f;
            unit.Components.Add(new Unit(unit, Color.Green, 4.0f));
            unit.Components.Add(new CircleCollider(unit, 16));
            teamB.AddUnit(unit);

            unit = new GameObject(new Vector2(924, 450), Textures.blueTank);
            unit.Depth = 0.5f;
            unit.Components.Add(new Unit(unit, Color.Blue, 4.0f));
            unit.Components.Add(new CircleCollider(unit, 16));
            teamB.AddUnit(unit);

            GameObject checkpointA = new GameObject(new Vector2(612, 150), Textures.checkpoint);
            GameObject checkpointB = new GameObject(new Vector2(350, 550), Textures.checkpoint);
            GameObject checkpointC = new GameObject(new Vector2(725, 550), Textures.checkpoint);

            // Obstacles
            GameObject box = new GameObject(new Vector2(0, 0), Textures.box);
            box.Components.Add(new SquareCollider(box, 128, 64));

        }

        /// <summary>
        /// Logic for every update (frame)
        /// </summary>
        /// <param name="dtime"></param>
        public void Update(float dtime)
        {
            if (InputManager.playerOneState == null || InputManager.playerTwoState == null)
            {
                InputManager.playerOneState = GamePad.GetState(PlayerIndex.One);
                InputManager.playerTwoState = GamePad.GetState(PlayerIndex.Two);
                return;
            }


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            for (int i = 0; i < GameObject.GameObjects.Count; ++i)
            {
                GameObject.GameObjects[i].Update(dtime);
            }


            // Selection player A
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed &&
                InputManager.playerOneState.Buttons.Y != ButtonState.Pressed)
            {
                teamA.SelectUnit(teamA.UnitWithColor(Color.Yellow));
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed &&
                InputManager.playerOneState.Buttons.B != ButtonState.Pressed)
            {
                teamA.SelectUnit(teamA.UnitWithColor(Color.Red));
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed &&
                InputManager.playerOneState.Buttons.A != ButtonState.Pressed)
            {
                teamA.SelectUnit(teamA.UnitWithColor(Color.Green));
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed &&
                InputManager.playerOneState.Buttons.X != ButtonState.Pressed)
            {
                teamA.SelectUnit(teamA.UnitWithColor(Color.Blue));
            }

            // Selection player B
            if (GamePad.GetState(PlayerIndex.Two).Buttons.Y == ButtonState.Pressed &&
                InputManager.playerTwoState.Buttons.Y != ButtonState.Pressed)
            {
                teamB.SelectUnit(teamB.UnitWithColor(Color.Yellow));
            }
            else if (GamePad.GetState(PlayerIndex.Two).Buttons.B == ButtonState.Pressed &&
                InputManager.playerTwoState.Buttons.B != ButtonState.Pressed)
            {
                teamB.SelectUnit(teamB.UnitWithColor(Color.Red));
            }
            else if (GamePad.GetState(PlayerIndex.Two).Buttons.A == ButtonState.Pressed &&
                InputManager.playerTwoState.Buttons.A != ButtonState.Pressed)
            {
                teamB.SelectUnit(teamB.UnitWithColor(Color.Green));
            }
            else if (GamePad.GetState(PlayerIndex.Two).Buttons.X == ButtonState.Pressed &&
                InputManager.playerTwoState.Buttons.X != ButtonState.Pressed)
            {
                teamB.SelectUnit(teamB.UnitWithColor(Color.Blue));
            }

            // Move units
            float xa = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            float ya = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;
            if (teamA.SelectedUnit != null)
            {
                move(teamA.SelectedUnit, new Vector2(xa, ya), dtime);
            }

            float xb = GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.X;
            float yb = GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.Y;
            if (teamB.SelectedUnit != null)
            {
                move(teamB.SelectedUnit, new Vector2(xb, yb), dtime);
            }

            InputManager.playerOneState = GamePad.GetState(PlayerIndex.One);
            InputManager.playerTwoState = GamePad.GetState(PlayerIndex.Two);
        }

        private void move(Unit unit, Vector2 direction, float dtime)
        {

            direction = fixStickInput(direction);

            float x = direction.X * dtime / 20;
            float y = -direction.Y * dtime / 20;
            unit.Velocity = new Vector2(x, y);

        }

        private Vector2 fixStickInput(Vector2 direction)
        {
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

        /// <summary>
        /// Drawing pictures for every frame.
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="dtime"></param>
        public void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch, RenderLayer layer)
        {
            if (layer == RenderLayer.Early)
            {
                
            }
            else if (layer == RenderLayer.Normal)
            {
                foreach (Renderable render in Renderable.AllRenderable)
                {
                    render.Render(spriteBatch);
                }
            }
            else
            {
                DrawSelection(spriteBatch);
            }
        }

        private void DrawSelection(SpriteBatch spriteBatch)
        {

            if (teamA.SelectedUnit != null)
            {
                spriteBatch.Draw(Textures.selection, teamA.SelectedUnit.AttachedTo.Position, Color.White);
            }

            if (teamB.SelectedUnit != null)
            {
                spriteBatch.Draw(Textures.selection, teamB.SelectedUnit.AttachedTo.Position, Color.White);
            }

        }


        //Go back to the main menu
        public void Exit()
        {
            
        }
    }
}
