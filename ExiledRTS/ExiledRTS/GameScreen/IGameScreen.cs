using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics.Contracts;

namespace ExiledRTS.GameScreen
{
    /// <summary>
    /// Each screen in the game is an implementation of this interface.
    /// A screen is what you can see in various parts of the program, such as the main menu or the game.
    /// </summary>
    public interface IGameScreen
    {
        /// <summary>
        /// The manager of this game screen
        /// </summary>
        GameScreenManager ScreenManager { get; set; }

        /// <summary>
        /// Initialize and get all assets used for this game screen
        /// </summary>
        void Initialize();

        /// <summary>
        /// Update all objects contained in this game screen
        /// </summary>
        /// <param name="dtime"></param>
        void Update(float dtime);

        /// <summary>
        /// Render all objects contained in this game screen
        /// </summary>
        /// <param name="sb">Spritebatch for drawing the objects</param>
        /// <param name="dtime">The time passed since last frame</param>
        void Render(SpriteBatch sb);

        void RenderLate(SpriteBatch sb);

        /// <summary>
        /// Lets a game screen clean up itself and choose the next game screen
        /// </summary>
        void Exit();
    }
}