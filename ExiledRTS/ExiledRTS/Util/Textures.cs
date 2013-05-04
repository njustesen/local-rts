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
        public static Texture2D selectionAlien;
        public static Texture2D selectionRobot;
        public static Texture2D checkpoint;
        public static Texture2D checkpointA;
        public static Texture2D checkpointB;
        public static Texture2D level;
        public static Texture2D projectile;
        public static Texture2D box;
        public static Texture2D checkpointBar;
        public static Texture2D checkpointProgress;
        public static Texture2D healthBar;
        public static Texture2D healthProgress;
        public static Texture2D scoreBar;
        public static Texture2D scoreProgress;
        public static Texture2D levelBackground;
        public static Texture2D squareBlock;
        public static Texture2D horizontalBlock;
        public static Texture2D verticalBlock;
        public static Texture2D startScreen;
        public static Texture2D startScreenWithText;
        public static Texture2D player1Ready;
        public static Texture2D player2Ready;
        public static Texture2D credits;
        public static Texture2D buttonAToStart;
        public static Texture2D splash;

        public static void Load(ContentManager Content)
        {
            yellowTank = Content.Load<Texture2D>("robot_yellow.png");
            redTank = Content.Load<Texture2D>("redrobot_2");
            greenTank = Content.Load<Texture2D>("greenrobot_2");
            blueTank = Content.Load<Texture2D>("bluerobot_2");
            
            selectionAlien = Content.Load<Texture2D>("selection_alien_2");
            selectionRobot = Content.Load<Texture2D>("selection_robot_2");
            /*
            selectionAlien = Content.Load<Texture2D>("robot_blue");
            selectionRobot = Content.Load<Texture2D>("robot_blue");
            */
            checkpoint = Content.Load<Texture2D>("cookie_01_basic_small");
            level = Content.Load<Texture2D>("level");
            projectile = Content.Load<Texture2D>("projectile");
            box = Content.Load<Texture2D>("box");
            checkpointA = Content.Load<Texture2D>("cookie_01_robot_small");
            checkpointB = Content.Load<Texture2D>("cookie_01_alien_small");
            checkpointBar = Content.Load<Texture2D>("checkbar");
            checkpointProgress = Content.Load<Texture2D>("checkprogress");
            scoreBar = Content.Load<Texture2D>("scoreBar");
            scoreProgress = Content.Load<Texture2D>("scoreprogress");
            healthBar = Content.Load<Texture2D>("bar");
            healthProgress = Content.Load<Texture2D>("progress");
            levelBackground = Content.Load<Texture2D>("level_background_02");
            squareBlock = Content.Load<Texture2D>("level_block_01_small");
            horizontalBlock = Content.Load<Texture2D>("level_block_02_small");
            verticalBlock = Content.Load<Texture2D>("level_block_03_small");

            startScreen = Content.Load<Texture2D>("The_frontpage_no_text");
            startScreenWithText = Content.Load<Texture2D>("The_frontpage_text_02");
            player1Ready = Content.Load<Texture2D>("player_1_ready");
            player2Ready = Content.Load<Texture2D>("player_2_ready");
            credits = Content.Load<Texture2D>("credits_01");
            buttonAToStart = Content.Load<Texture2D>("button_hold_a_to_start");
            splash = Content.Load<Texture2D>("splash_screen_01");
        }

        public static Vector2 GetOrigin(Texture2D text)
        {
            return new Vector2(text.Height / 2.0f, text.Width / 2.0f);
        }
    }
}
