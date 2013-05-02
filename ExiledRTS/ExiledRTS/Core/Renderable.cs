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

        Texture2D Texture;
        Rectangle Area;
        public bool Flipped;
        GameObject AttachedTo;
        public Color Color = Color.White;

        public Renderable(GameObject go, Texture2D text) 
        {
            AttachedTo = go;
            SetTexture(text);
            AllRenderable.Add(this);
        }

        public void SetTexture(Texture2D texture)
        {
            Texture = texture;
            Area = texture.Bounds;
        }

        public void Render(SpriteBatch batch)
        {
            //batch.Draw(Texture, AttachedTo.Position, Color.White);
            batch.Draw(Texture, AttachedTo.Position, Area, Color, 0.0f, new Vector2(0, 0), 1.0f, Flipped ? SpriteEffects.None : SpriteEffects.FlipVertically, AttachedTo.Depth);
        }

        public void Destroy()
        {
            AllRenderable.Remove(this);
        }
    }
}
