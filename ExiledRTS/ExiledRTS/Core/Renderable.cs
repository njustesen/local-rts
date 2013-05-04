using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace ExiledRTS.Core
{
    public class Renderable
    {
        public static List<Renderable> AllRenderable = new List<Renderable>();

        public Texture2D Texture {get; private set;}

        Rectangle Area;
        public bool Flipped;
        GameObject AttachedTo;
        public Color Color = Color.White;

        public Renderable(GameObject go, Texture2D text) 
        {
            AttachedTo = go;
            if (text != null)
                SetTexture(text);
            AllRenderable.Add(this);
        }

        public void SetTexture(Texture2D texture)
        {
            Texture = texture;
            Area = texture.Bounds;
        }

        public Vector2 CenterPoint()
        {
            return new Vector2(Area.Width / 2.0f, Area.Height / 2.0f);
        }

        public void Render(SpriteBatch batch)
        {
            //batch.Draw(Texture, AttachedTo.Position, Color.White);
            if (Texture != null)
                batch.Draw(Texture, AttachedTo.Position, Area, Color, 0.0f, CenterPoint(), 1.0f, Flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None, AttachedTo.Depth);
        }

        public void Destroy()
        {
            AllRenderable.Remove(this);
        }
    }
}
