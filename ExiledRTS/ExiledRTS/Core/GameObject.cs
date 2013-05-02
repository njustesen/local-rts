using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExiledRTS.Core
{
    public class GameObject
    {
        public static List<GameObject> GameObjects = new List<GameObject>();

        public Vector2 Position; // Z is the depth in the scene
        public float Depth;

        public Renderable Renderer; //May be null

        public List<Component> Components = new List<Component>();

        public GameObject(Vector2 Position)
        {
            this.Position = Position;
            GameObjects.Add(this);
        }

        public GameObject(Vector2 Position, Texture2D texture)
        {
            this.Position = Position;
            Renderer = new Renderable(this, texture);
        }

        public T GetComponent<T>() where T: Component
        {
            for (int i = 0; i < Components.Count; ++i)
            {
                if (Components[i].GetType() == typeof(T))
                    return Components[i] as T;
            }
            return null;
        }

        public List<T> GetComponents<T>() where T:Component 
        {
            List<T> found = new List<T>();
            for (int i = 0; i < Components.Count; ++i)
            {
                if (Components[i].GetType() == typeof(T))
                    found.Add(Components[i] as T);
            }
            return found;
        }

        public void Update(float dtime)
        {
            for (int i = 0; i < Components.Count; ++i)
            {
                Components[i].Update(dtime);
            }
        }

        public void Render(SpriteBatch batch)
        {
            if (Renderer != null)
                Renderer.Render(batch);
        }

        public void Destroy()
        {
            for (int i = 0; i < Components.Count; ++i )
            {
                Components[i].Destroy();
            }
            if (Renderer != null)
                Renderer.Destroy();

            GameObjects.Remove(this);
        }
    }
}
