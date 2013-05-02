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

            // TODO: Add your update logic here

            base.Update(gameTime);
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
