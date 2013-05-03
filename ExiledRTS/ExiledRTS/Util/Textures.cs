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

        public static void Load(ContentManager Content)
        {
            //yellowTank = Content.Load<Texture2D>("yellow");
            yellowTank = Content.Load<Texture2D>("robot_gul.png");
            redTank = Content.Load<Texture2D>("red");
            greenTank = Content.Load<Texture2D>("green");
            blueTank = Content.Load<Texture2D>("blue");
            selection = Content.Load<Texture2D>("selection");
            checkpoint = Content.Load<Texture2D>("checkpoint");
            level = Content.Load<Texture2D>("level");
            projectile = Content.Load<Texture2D>("projectile");
            box = Content.Load<Texture2D>("box");
            checkpointA = Content.Load<Texture2D>("checkpointA");
            checkpointB = Content.Load<Texture2D>("checkpointB");
        }

        public static Vector2 GetOrigin(Texture2D text)
        {
            return new Vector2(text.Height / 2.0f, text.Width / 2.0f);
        }
    }
}
