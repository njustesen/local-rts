using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.GameScreen
{
    public enum RenderLayer {Early, Normal, Late};

    /// <summary>
    /// The manager that keeps track of and lets you change the active screen.
    /// </summary>
    public class GameScreenManager
    {
        public static GameScreenManager ScreenManager = new GameScreenManager();
        public static class Screens
        {
            public static IGameScreen ScreenGame = new GameScreen();
            //public static IGameScreen ScreenGame = new GameScreen();
        }
        
        //public static IGameScreen MainMenuScreen;

        /// <summary>
        /// The active game screen to run update and render on
        /// </summary>
        private IGameScreen activeScreen;

        /// <summary>
        /// The active game screen. The old screen will be removed
        /// </summary>
        public IGameScreen ActiveScreen
        {
            get { return activeScreen; }
            set
            {
                if (activeScreen != value)
                {
                    NewScreenActivated(value);
                }
            }
        }

        /// <summary>
        /// Initilize all necesary data for the new screen
        /// That includes removing all game objects and initizeing the new screen
        /// </summary>
        /// <param name="value"></param>
        private void NewScreenActivated(IGameScreen value)
        {
            activeScreen = value;
            activeScreen.ScreenManager = this;
            activeScreen.Initialize();
        }

        /// <summary>
        /// Construct a GameScreenManager
        /// </summary>
        public GameScreenManager()
        {
        }


        /// <summary>
        /// Run update on the currently active game scren
        /// </summary>
        /// <param name="dtime">The time passed since last frame</param>
        public void Update(float dtime)
        {
            activeScreen.Update(dtime);
        }

        /// <summary>
        /// Run render on the currently active game screen
        /// </summary>
        /// <param name="sb">The spritebatch used for drawing</param>
        /// <param name="dtime">The time passed since last frame</param>
        public void Render(Microsoft.Xna.Framework.Graphics.SpriteBatch sb, RenderLayer layer)
        {
            activeScreen.Render(sb, layer);
        }
    }
}