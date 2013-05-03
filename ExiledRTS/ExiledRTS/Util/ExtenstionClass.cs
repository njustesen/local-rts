using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

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
}
