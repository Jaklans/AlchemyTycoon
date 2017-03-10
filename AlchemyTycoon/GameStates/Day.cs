using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace AlchemyTycoon.GameStates
{
    class Day
    {
        Texture2D image;
        Rectangle imageRec;

        KeyboardState kbState;

        public Day(Texture2D img, Rectangle imgr)
        {
            image = img;
            imageRec = imgr;
        }

        protected void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, imageRec, Color.White);
        }

        protected void LoadContent(ContentManager content)
        {

        }

        protected void Update()
        {

        }
    }
}
