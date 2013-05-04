using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExiledRTS.Util
{
    public static class Textures
    {
        public static Texture2D yellowTank;
        public static Texture2D redTank ;
        public static Texture2D greenTank;
        public static Texture2D blueTank;
        public static Texture2D selection;
        public static Texture2D checkpoint;
        public static Texture2D checkpointA;
        public static Texture2D checkpointB;
        public static Texture2D level;
        public static Texture2D projectile;
        public static Texture2D box;
        public static Texture2D checkpointBar;
        public static Texture2D checkpointProgress;
        public static Texture2D scoreBar;
        public static Texture2D scoreProgress;
        public static Texture2D levelBackground;
        public static Texture2D squareBlock;
        public static Texture2D horizontalBlock;
        public static Texture2D verticalBlock;

        public static void Load(ContentManager Content)
        {
            yellowTank = Content.Load<Texture2D>("robot_yellow.png");
            redTank = Content.Load<Texture2D>("robot_red");
            greenTank = Content.Load<Texture2D>("robot_green");
            blueTank = Content.Load<Texture2D>("robot_blue");
            selection = Content.Load<Texture2D>("selection");
            checkpoint = Content.Load<Texture2D>("cookie_01_basic_small");
            level = Content.Load<Texture2D>("level");
            projectile = Content.Load<Texture2D>("projectile");
            box = Content.Load<Texture2D>("box");
            checkpointA = Content.Load<Texture2D>("checkpointA");
            checkpointB = Content.Load<Texture2D>("checkpointB");
            checkpointBar = Content.Load<Texture2D>("bar");
            checkpointProgress = Content.Load<Texture2D>("progress");
            scoreBar = Content.Load<Texture2D>("scoreBar");
            scoreProgress = Content.Load<Texture2D>("scoreprogress");
            levelBackground = Content.Load<Texture2D>("level_background_02");
            squareBlock = Content.Load<Texture2D>("level_block_01_small");
            horizontalBlock = Content.Load<Texture2D>("level_block_02_small");
            verticalBlock = Content.Load<Texture2D>("level_block_03_small");
        }

        public static Vector2 GetOrigin(Texture2D text)
        {
            return new Vector2(text.Height / 2.0f, text.Width / 2.0f);
        }
    }
}
