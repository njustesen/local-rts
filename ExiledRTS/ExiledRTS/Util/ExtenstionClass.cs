using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public static class ExtenstionClass
{
    public static Vector2 Get2D (this Vector3 v) 
    {
        return new Vector2(v.X, v.Y);
    }

    public static Vector3 GetNormalized(this Vector3 v)
    {
        v.Normalize();
        return v;
    }

    public static Vector2 GetNormalized(this Vector2 v)
    {
        v.Normalize();
        return v;
    }

    public static Point ToPoint(this Vector2 v)
    {
        return new Point((int)v.X, (int)v.Y);
    }

    public static Vector2 Size(this Rectangle rect)
    {
        return new Vector2(rect.Width, rect.Height);
    }

    public static void DrawHelper(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position, float depth)
    {
        spriteBatch.Draw(texture, position, texture.Bounds, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, depth);
    }

    public static void DrawAtCenter(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position, float depth)
    {
        var drawPos = position;
        position.X -= texture.Width / 2;
        position.Y -= texture.Height / 2;

        spriteBatch.Draw(texture, position, texture.Bounds, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, depth);
    }

    public static void DrawAtCenter(this SpriteBatch spriteBatch, Texture2D texture, Vector2 position, float depth, bool flipped)
    {
        var drawPos = position;
        position.X -= texture.Width / 2;
        position.Y -= texture.Height / 2;

        spriteBatch.Draw(texture, position, texture.Bounds, Color.White, 0.0f, Vector2.Zero, 1.0f, flipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None, depth);
    }

    public static void SetPosition(this GameWindow window, Point position)
    {
         OpenTK.GameWindow OTKWindow = GetForm(window);
         if (OTKWindow != null)
         {
             OTKWindow.X = position.X;
             OTKWindow.Y = position.Y;
         }

     }

    public static OpenTK.GameWindow GetForm(this GameWindow gameWindow)
    {
        Type type = typeof(OpenTKGameWindow);
        System.Reflection.FieldInfo field = type.GetField("window", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (field != null)
            return field.GetValue(gameWindow) as OpenTK.GameWindow;
        return null;
    }
}
