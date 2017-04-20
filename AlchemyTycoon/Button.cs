using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

//Written by Simeon Chang
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
            :base(texture, new Rectangle(0, 0, texture.Width, texture.Height))
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
            if (visible)
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
    class Button
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rec;
        Color color = new Color(255, 255, 255, 255);

        public Vector2 size;
        public Button(Texture2D nTexture, GraphicsDevice graphics)
        {
            //get the size of the button and image
            texture = nTexture;
            //size = new Vector2(graphics.Viewport.Width / 10, graphics.Viewport.Height / 20);
            size = new Vector2(nTexture.Width, nTexture.Height);
        }
        public void setPos(Vector2 newPos)
        {
            position = newPos;
        }
        bool colortest;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
            if (isClicked)
            {
                isClicked = false;
            }

            //set data for the button and mouse
            rec = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRec = new Rectangle(mouse.X, mouse.Y, 1, 1);
            if (mouseRec.Intersects(rec))
            {
                //this will make the button highlight and blink red when hovered
                if (color.R >= 0) colortest = false;
                if (color.R <= 255) colortest = true;
                if (colortest) color.R += 5;
                else color.R -= 5;
                //if clicked will turn isClicked true
                if (mouse.LeftButton == ButtonState.Pressed)
                {
                    isClicked = true;
                }
                //while it is not clicked it will blink
                else if (color.R > 0)
                {
                    color.R += 5;
                    isClicked = false;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, color);
        }

    }
}
