using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//Written by John Shull
namespace AlchemyTycoon.GameItems
{
    abstract class GameItem
    {
        //Feilds
        protected int hashValue;
        protected string name;
        protected int value;
        protected string flavorText;
        protected string textureName;
        protected Texture2D texture;

        //Properties
        public int HashValue
        {
            get { return hashValue; }
        }
        public string Name
        {
            get { return name; }
        }
        public int Value
        {
            get { return value; }
        }
        public string FlavorText
        {
            get { return flavorText; }
        }
        public string TextureName
        {
            get { return textureName; }
        }
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }

        //Constructor
        public GameItem(int hashValue, string name, int value, string flavorText, string textureName)
        {
            this.hashValue = hashValue;
            this.name = name;
            this.value = value;
            this.flavorText = flavorText;
            this.textureName = textureName;
        }

        //Draw
        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public virtual void DrawInfo(SpriteBatch spriteBatch, Rectangle infoBox, SpriteFont font)
        {
            //Image
            spriteBatch.Draw(texture, new Vector2(
                (float)(infoBox.X + .5 * (infoBox.Width - texture.Width)), 
                (float)(infoBox.Y + .1 * infoBox.Height)), 
                Color.White);
            //Name
            spriteBatch.DrawString(font, name, new Vector2(
                infoBox.X,
                (float)(infoBox.Y + texture.Height + .1 * infoBox.Height)),
                Color.Black);
            //FlavorText
            this.CustomDrawString(spriteBatch, font, flavorText, new Vector2(
                infoBox.X,
                (float)(infoBox.Y + texture.Height + .2 * infoBox.Height)),
                500);
            //Value
            spriteBatch.DrawString(font, "Expected Value: " + value.ToString() + " Gold", new Vector2(
                infoBox.X,
                (float)(infoBox.Y + texture.Height + .8 * infoBox.Height)),
                Color.Black);
        }

        public virtual void DrawInfoReduced(SpriteBatch spriteBatch, Rectangle infoBox, SpriteFont font)
        {
            //Image
            spriteBatch.Draw(texture, new Vector2(
                (float)(infoBox.X + .5 * (infoBox.Width - texture.Width)),
                (float)(infoBox.Y + .1 * infoBox.Height)),
                Color.White);
            //Name
            spriteBatch.DrawString(font, name, new Vector2(
                infoBox.X,
                (float)(infoBox.Y + texture.Height + .1 * infoBox.Height)),
                Color.Black);
            //Value
            spriteBatch.DrawString(font, "Expected Value: " + value.ToString() + " Gold", new Vector2(
                infoBox.X,
                (float)(infoBox.Y + texture.Height + .2 * infoBox.Height)),
                Color.Black);
        }

        //Compairer (for sorting)
        public int CompareTo(GameItem compareItem)
        {
            if(compareItem == null)
            {
                return 1;
            }
            else
            {
                return this.hashValue.CompareTo(compareItem.hashValue);
            }
        }

        public void CustomDrawString(SpriteBatch spriteBatch, SpriteFont font, string text, Vector2 fontPosition, int maxLineWidth)
        {
            string[] words = text.Split(' ');
            StringBuilder sb = new StringBuilder();
            float lineWidth = 0f;
            float spaceWidth = font.MeasureString(" ").X;

            foreach (string word in words)
            {
                Vector2 size = font.MeasureString(word);

                if (lineWidth + size.X < maxLineWidth)
                {
                    sb.Append(word + " ");
                    lineWidth += size.X + spaceWidth;
                }
                else
                {
                    sb.Append("\n" + word + " ");
                    lineWidth = size.X + spaceWidth;
                }
            }

            spriteBatch.DrawString(font, sb.ToString(),fontPosition, Color.Black);
            

        //spriteBatch.DrawString()

        //string temp = text;
        //List<string> lines = new List<string>();
        //while(temp.Length > 40)
        //{
        //}
        //
        //foreach (string s in lines)
        //{
        //    Vector2 fontOrigin = font.MeasureString(s) / 2;
        //    spriteBatch.DrawString(font, s, fontPosition, Color.White, 0, fontOrigin, 1f, SpriteEffects.None, .5f);
        //}
    }
    }
}
