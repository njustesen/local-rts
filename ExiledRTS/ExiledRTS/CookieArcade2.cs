﻿#region Using Statements
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
#endregion

namespace ExiledRTS
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class CookieArcade2 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public CookieArcade2()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;

            var ScreenHeight = GraphicsDevice.DisplayMode.Height;
            var ScreenWidth = GraphicsDevice.DisplayMode.Width;

            Window.SetPosition(new Point(100, 100));
            //Window.SetPosition(new Point((int)(ScreenWidth / 2.0f - 1280.0f / 2.0f), (int)(ScreenHeight / 2.0f - 720 / 2.0f - 50)));
            graphics.IsFullScreen = true;
        }


        protected override void Initialize()
        {
            Textures.Load(Content);
            Sounds.Load(Content);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);



            GameScreenManager.ScreenManager.ActiveScreen = GameScreenManager.Screens.ScreenGame;
        }

        

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        KeyboardState lastState;
        protected override void Update(GameTime gameTime)
        {
            var currentState = Keyboard.GetState();   
            for (int i = 0; i < GameObject.GameObjects.Count; ++i)
            {
                if (GameObject.GameObjects[i].Destroy)
                {
                    GameObject.GameObjects[i].DoDestroy();
                }
            }

            GameScreenManager.ScreenManager.Update(gameTime.ElapsedGameTime.Milliseconds/1000.0f);

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            base.Update(gameTime);
        }

        
        Array renderEnum = Enum.GetValues(typeof(RenderLayer));
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            
            foreach(RenderLayer layer in renderEnum)
            {
                spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

                GameScreenManager.ScreenManager.Render(spriteBatch, layer);
            
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }

    }
}
