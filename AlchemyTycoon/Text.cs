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
    class Text
    {
        SpriteFont font;
        string text;
        Vector2 pos;
        Color color;

        public Text(string words, SpriteFont sfont, Color colour)
        {
            text = words;
            font = sfont;
            color = colour;
        }
        public void setPos(Vector2 newPos)
        {
            pos = newPos;
        }
        public void Update()
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, pos, color);
        }

        public void changeFont(SpriteBatch spriteBatch, Vector2 theScale)
        {
            Vector2 forZero = new Vector2(0);
            spriteBatch.DrawString(font, text, pos, color, 0, forZero, theScale, SpriteEffects.None, 0);
        }

    }
}
