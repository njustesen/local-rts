using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public static Texture2D level;
        public static Texture2D box;

        public static void Load(ContentManager Content)
        {
            yellowTank = Content.Load<Texture2D>("yellow");
            redTank = Content.Load<Texture2D>("red");
            greenTank = Content.Load<Texture2D>("green");
            blueTank = Content.Load<Texture2D>("blue");
            selection = Content.Load<Texture2D>("selection");
            checkpoint = Content.Load<Texture2D>("checkpoint");
            level = Content.Load<Texture2D>("level");
            box = Content.Load<Texture2D>("box");

        }
    }
}
