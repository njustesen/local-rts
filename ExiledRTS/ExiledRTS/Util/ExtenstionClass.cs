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
}
