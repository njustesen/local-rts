using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExiledRTS.Util
{
    public class UnitTextures
    {
        public Texture2D Up;
        public Texture2D Down;
        public Texture2D Left;
        public Texture2D Right;
    };

    public static class Textures
    {
        public static Texture2D yellowTank;
        public static Texture2D redTank ;
        public static Texture2D greenTank;
        public static Texture2D blueTank;
        public static Texture2D yellowAlien;
        public static Texture2D redAlien;
        public static Texture2D greenAlien;
        public static Texture2D blueAlien;
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
        public static Texture2D pressAnyToStart;
        public static Texture2D pause;
        public static Texture2D barAlien;
        public static Texture2D barRobot;
        public static Texture2D scoreBars;
        public static Texture2D logo;

        public static UnitTextures RobotRed     = new UnitTextures();
        public static UnitTextures RobotBlue    = new UnitTextures();
        public static UnitTextures RobotGreen   = new UnitTextures();
        public static UnitTextures RobotYellow  = new UnitTextures();
                      
        public static UnitTextures AlienRed     = new UnitTextures();
        public static UnitTextures AlienBlue    = new UnitTextures();
        public static UnitTextures AlienGreen   = new UnitTextures();
        public static UnitTextures AlienYellow  = new UnitTextures();


        

        public static void Load(ContentManager Content)
        {
            yellowTank = Content.Load<Texture2D>("robot_yellow.png");
            redTank = Content.Load<Texture2D>("redrobot_2");
            greenTank = Content.Load<Texture2D>("greenrobot_2");
            blueTank = Content.Load<Texture2D>("bluerobot_2");

            yellowAlien = Content.Load<Texture2D>("yellowalien.png");
            redAlien = Content.Load<Texture2D>("redalien");
            greenAlien = Content.Load<Texture2D>("greenalien");
            blueAlien = Content.Load<Texture2D>("bluealien");
            
            selectionAlien = Content.Load<Texture2D>("ring");
            selectionRobot = Content.Load<Texture2D>("ring");
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
            logo = Content.Load<Texture2D>("grouplogo_cookiecrunchers_01");

            startScreen = Content.Load<Texture2D>("The_frontpage_no_text");
            startScreenWithText = Content.Load<Texture2D>("The_frontpage_text_02");
            player1Ready = Content.Load<Texture2D>("player_1_ready");
            player2Ready = Content.Load<Texture2D>("player_2_ready");
            credits = Content.Load<Texture2D>("credits_01");
            buttonAToStart = Content.Load<Texture2D>("button_hold_a_to_start");
            splash = Content.Load<Texture2D>("splash_screen_01");
            pressAnyToStart = Content.Load<Texture2D>("press_button_to_start_01");
            pause = Content.Load<Texture2D>("pause_01");
            barAlien = Content.Load<Texture2D>("bar_aliens");
            barRobot = Content.Load<Texture2D>("bar_robot");

            scoreBars = Content.Load<Texture2D>("bar_overlay_03");

            RobotRed.Up         = Content.Load<Texture2D>("Robots\\robot_red_front");
            RobotRed.Down       = Content.Load<Texture2D>("Robots\\robot_red_back");
            RobotRed.Left       = Content.Load<Texture2D>("Robots\\robot_red_left");
            RobotRed.Right      = Content.Load<Texture2D>("Robots\\robot_red_right");
                                                           
            RobotBlue.Up        = Content.Load<Texture2D>("Robots\\robot_blue_front");
            RobotBlue.Down      = Content.Load<Texture2D>("Robots\\robot_blue_back");
            RobotBlue.Left      = Content.Load<Texture2D>("Robots\\robot_blue_left");
            RobotBlue.Right     = Content.Load<Texture2D>("Robots\\robot_blue_right");
                                                           
            RobotGreen.Up       = Content.Load<Texture2D>("Robots\\robot_green_front");
            RobotGreen.Down     = Content.Load<Texture2D>("Robots\\robot_green_back");
            RobotGreen.Left     = Content.Load<Texture2D>("Robots\\robot_green_left");
            RobotGreen.Right    = Content.Load<Texture2D>("Robots\\robot_green_right");
                                                           
            RobotYellow.Up      = Content.Load<Texture2D>("Robots\\robot_yellow_front");
            RobotYellow.Down    = Content.Load<Texture2D>("Robots\\robot_yellow_back");
            RobotYellow.Left    = Content.Load<Texture2D>("Robots\\robot_yellow_left");
            RobotYellow.Right   = Content.Load<Texture2D>("Robots\\robot_yellow_right");

            AlienRed.Up         = Content.Load<Texture2D>("Aliens\\alien_red_front");
            AlienRed.Down       = Content.Load<Texture2D>("Aliens\\alien_red_back");
            AlienRed.Left       = Content.Load<Texture2D>("Aliens\\alien_red_left");
            AlienRed.Right      = Content.Load<Texture2D>("Aliens\\alien_red_right");
                                                           
            AlienBlue.Up        = Content.Load<Texture2D>("Aliens\\alien_blue_front");
            AlienBlue.Down      = Content.Load<Texture2D>("Aliens\\alien_blue_back");
            AlienBlue.Left      = Content.Load<Texture2D>("Aliens\\alien_blue_left");
            AlienBlue.Right     = Content.Load<Texture2D>("Aliens\\alien_blue_right");
                                                           
            AlienGreen.Up       = Content.Load<Texture2D>("Aliens\\alien_green_front");
            AlienGreen.Down     = Content.Load<Texture2D>("Aliens\\alien_green_back");
            AlienGreen.Left     = Content.Load<Texture2D>("Aliens\\alien_green_left");
            AlienGreen.Right    = Content.Load<Texture2D>("Aliens\\alien_green_right");
                                                           
            AlienYellow.Up      = Content.Load<Texture2D>("Aliens\\alien_yellow_front");
            AlienYellow.Down    = Content.Load<Texture2D>("Aliens\\alien_yellow_back");
            AlienYellow.Left    = Content.Load<Texture2D>("Aliens\\alien_yellow_left");
            AlienYellow.Right   = Content.Load<Texture2D>("Aliens\\alien_yellow_right");

        }

        public static Vector2 GetOrigin(Texture2D text)
        {
            return new Vector2(text.Height / 2.0f, text.Width / 2.0f);
        }
    }
}
