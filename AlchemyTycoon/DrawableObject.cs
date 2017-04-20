using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlchemyTycoon
{
    class DrawableObject
    {
        protected Texture2D texture;
        protected Rectangle position;
        public bool visible;

        public DrawableObject(Texture2D texture, int x, int y)
        {
            this.texture = texture;
            position = new Rectangle(x, y, texture.Width, texture.Height);
        }
        public DrawableObject(Texture2D texture, Rectangle position)
        {
            this.texture = texture;
            this.position = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (visible)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }

        public virtual void Update(MouseState mouse)
        {

        }
    }
}
