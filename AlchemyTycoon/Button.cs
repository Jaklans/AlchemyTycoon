using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Written by John Shull
namespace AlchemyTycoon
{
    class newButton : DrawableObject
    {
        private Texture2D highlightTexture;

        private bool mouseover;
        private bool clicked;

        public bool Mouseover { get { return mouseover; } }
        public bool Clicked { get { return clicked; } }

        public newButton(Texture2D texture, Texture2D highlightTexture)
            : base(texture, new Rectangle(0, 0, texture.Width, texture.Height))
        {
            this.highlightTexture = highlightTexture;
        }
        public newButton(Texture2D texture, Texture2D highlightTexture, Vector2 position)
            : base(texture, new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height))
        {
            this.highlightTexture = highlightTexture;
        }

        public override void Update(MouseState mouse)
        {
            if (position.Contains(mouse.Position))
            {
                mouseover = true;
                if (mouse.LeftButton.Equals(ButtonState.Pressed))
                {
                    clicked = true;
                }
                else
                {
                    clicked = false;
                }
            }
            else
            {
                mouseover = false;
                clicked = false;
            }
        }
        public override void Draw(SpriteBatch spritebatch)
        {
            if (true)
            {
                if (mouseover)
                {
                    if (highlightTexture.Equals(texture))
                    {
                        spritebatch.Draw(highlightTexture, position, Color.Green);
                    }
                    else
                    {
                        spritebatch.Draw(highlightTexture, position, Color.White);
                    }
                }
                else
                {
                    spritebatch.Draw(texture, position, Color.White);
                }
            }
        }
    }
}