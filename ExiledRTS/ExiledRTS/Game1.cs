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

            StartGame();
        }

        public void StartGame()
        {
            teamA = new Team();
            GameObject unit = new GameObject(new Vector2(50, 150), yellowTank);
            unit.Components.Add(new Unit(unit, Color.Yellow));
            teamA.AddUnit(unit);

            unit = new GameObject(new Vector2(50, 250), redTank);
            unit.Components.Add(new Unit(unit, Color.Red));
            teamA.AddUnit(unit);

            unit = new GameObject(new Vector2(50, 350), greenTank);
            unit.Components.Add(new Unit(unit, Color.Green));
            teamA.AddUnit(unit);

            unit = new GameObject(new Vector2(50, 450), blueTank);
            unit.Components.Add(new Unit(unit, Color.Blue));
            teamA.AddUnit(unit);

            teamB = new Team();
            unit = new GameObject(new Vector2(550, 150), yellowTank);
            unit.Components.Add(new Unit(unit, Color.Yellow));
            teamB.AddUnit(unit);

            unit = new GameObject(new Vector2(550, 250), redTank);
            unit.Components.Add(new Unit(unit, Color.Red));
            teamB.AddUnit(unit);

            unit = new GameObject(new Vector2(550, 350), greenTank);
            unit.Components.Add(new Unit(unit, Color.Green));
            teamB.AddUnit(unit);

            unit = new GameObject(new Vector2(550, 450), blueTank);
            unit.Components.Add(new Unit(unit, Color.Blue));
            teamB.AddUnit(unit);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Selection player A
            if (GamePad.GetState(PlayerIndex.One).Buttons.Y == ButtonState.Pressed)
            {
                teamA.SelectedUnit = teamA.UnitWithColor(Color.Yellow);
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.B == ButtonState.Pressed)
            {
                teamA.SelectedUnit = teamA.UnitWithColor(Color.Red);
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                teamA.SelectedUnit = teamA.UnitWithColor(Color.Green);
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed)
            {
                teamA.SelectedUnit = teamA.UnitWithColor(Color.Blue);
            }

            // Selection player B
            if (GamePad.GetState(PlayerIndex.Two).Buttons.Y == ButtonState.Pressed)
            {
                teamB.SelectedUnit = teamB.UnitWithColor(Color.Yellow);
            }
            else if (GamePad.GetState(PlayerIndex.Two).Buttons.B == ButtonState.Pressed)
            {
                teamB.SelectedUnit = teamB.UnitWithColor(Color.Red);
            }
            else if (GamePad.GetState(PlayerIndex.Two).Buttons.A == ButtonState.Pressed)
            {
                teamB.SelectedUnit = teamB.UnitWithColor(Color.Green);
            }
            else if (GamePad.GetState(PlayerIndex.Two).Buttons.X == ButtonState.Pressed)
            {
                teamB.SelectedUnit = teamB.UnitWithColor(Color.Blue);
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
            foreach (Renderable render in Renderable.AllRenderable)
            {
                render.Render(spriteBatch);
            }
            spriteBatch.End();

            spriteBatch.Begin();

            //Insert GUI code here

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
