#region Using Statements
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
using ExiledRTS.Util;
#endregion

namespace ExiledRTS
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Team teamA;
        Team teamB;
        Texture2D yellowTank;
        Texture2D redTank;
        Texture2D blueTank;
        Texture2D greenTank;
        Texture2D selection;
        Texture2D checkpoint;
        Texture2D level;
        
        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            //ExiledRTS.Util.User32.SetWindowPos((uint)this.Window.Handle, 0, 0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight, 0);
        }

        protected override void Initialize()
        {

            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            yellowTank = Content.Load<Texture2D>("yellow");
            redTank = Content.Load<Texture2D>("red");
            greenTank = Content.Load<Texture2D>("green");
            blueTank = Content.Load<Texture2D>("blue");
            selection = Content.Load<Texture2D>("selection");
            checkpoint = Content.Load<Texture2D>("checkpoint");
            level = Content.Load<Texture2D>("level");

            StartGame();
        }

        public void StartGame()
        {
            teamA = new Team();
            GameObject unit = new GameObject(new Vector2(200, 150), yellowTank);
            unit.Components.Add(new Unit(unit, Color.Yellow));
            teamA.AddUnit(unit);

            unit = new GameObject(new Vector2(200, 250), redTank);
            unit.Components.Add(new Unit(unit, Color.Red));
            teamA.AddUnit(unit);

            unit = new GameObject(new Vector2(200, 350), greenTank);
            unit.Components.Add(new Unit(unit, Color.Green));
            teamA.AddUnit(unit);

            unit = new GameObject(new Vector2(200, 450), blueTank);
            unit.Components.Add(new Unit(unit, Color.Blue));
            teamA.AddUnit(unit);

            teamB = new Team();
            unit = new GameObject(new Vector2(924, 150), yellowTank);
            unit.Components.Add(new Unit(unit, Color.Yellow));
            teamB.AddUnit(unit);

            unit = new GameObject(new Vector2(924, 250), redTank);
            unit.Components.Add(new Unit(unit, Color.Red));
            teamB.AddUnit(unit);

            unit = new GameObject(new Vector2(924, 350), greenTank);
            unit.Components.Add(new Unit(unit, Color.Green));
            teamB.AddUnit(unit);

            unit = new GameObject(new Vector2(924, 450), blueTank);
            unit.Components.Add(new Unit(unit, Color.Blue));
            teamB.AddUnit(unit);

            GameObject checkpointA = new GameObject(new Vector2(612, 150), checkpoint);
            checkpointA.Depth = 0;
            GameObject checkpointB = new GameObject(new Vector2(350, 550), checkpoint);
            checkpointA.Depth = 0;
            GameObject checkpointC = new GameObject(new Vector2(725, 550), checkpoint);
            checkpointA.Depth = 0;

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
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
                GameObject.GameObjects[i].Update(gameTime.ElapsedGameTime.Milliseconds);
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
                move(teamA.SelectedUnit, new Vector2(xa, ya), gameTime);
            }

            float xb = GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.X;
            float yb = GamePad.GetState(PlayerIndex.Two).ThumbSticks.Left.Y;
            if (teamB.SelectedUnit != null)
            {
                move(teamB.SelectedUnit, new Vector2(xb, yb), gameTime);
            }

            InputManager.playerOneState = GamePad.GetState(PlayerIndex.One);
            InputManager.playerTwoState = GamePad.GetState(PlayerIndex.Two);

            base.Update(gameTime);
        }

        private void move(Unit unit, Vector2 direction, GameTime gameTime)
        {

            direction = fixStickInput(direction);

            float x = direction.X * gameTime.ElapsedGameTime.Milliseconds / 20;
            float y = -direction.Y * gameTime.ElapsedGameTime.Milliseconds / 20;
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

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            spriteBatch.Draw(level, new Vector2(0, 0), Color.White);

            spriteBatch.End();

            spriteBatch.Begin();
            foreach (Renderable render in Renderable.AllRenderable)
            {
                render.Render(spriteBatch);
            }
            spriteBatch.End();

            spriteBatch.Begin();

            DrawSelection(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void DrawSelection(SpriteBatch spriteBatch)
        {
            
            if (teamA.SelectedUnit != null){
                spriteBatch.Draw(selection, teamA.SelectedUnit.AttachedTo.Position, Color.White);
            }

            if (teamB.SelectedUnit != null)
            {
                spriteBatch.Draw(selection, teamB.SelectedUnit.AttachedTo.Position, Color.White);
            }

        }
    }
}
