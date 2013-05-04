using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Util
{
    class Sounds
    {
        public static SoundEffect shootA;
        public static SoundEffect shootB;
        public static SoundEffect shootC;
        public static SoundEffect shootD;

        public static SoundEffect alienDieA;
        public static SoundEffect alienDieB;
        public static SoundEffect robotDieA;
        public static SoundEffect robotDieB;

        public static SoundEffect conquerA;
        public static SoundEffect conquerB;

        public static void Load(ContentManager Content)
        {
            shootA = Content.Load<SoundEffect>("shoot_01_canon");
            shootB = Content.Load<SoundEffect>("shoot_02_laser");
            shootC = Content.Load<SoundEffect>("shoot_03_laser");
            shootD = Content.Load<SoundEffect>("shoot_05_pistol");

            conquerA = Content.Load<SoundEffect>("Fanfar_robot_01");
            conquerB = Content.Load<SoundEffect>("Fanfar_alien_02");

            alienDieA = Content.Load<SoundEffect>("Die_alien_01");
            alienDieB = Content.Load<SoundEffect>("Die_alien_02");

            robotDieA = Content.Load<SoundEffect>("Die_robot_01");
            robotDieB = Content.Load<SoundEffect>("Die_robot_02");
        }

    }
}
