using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AlchemyTycoon.GameItems
{
    abstract class GameItem
    {
        //Feilds
        protected int hashValue;
        protected string name;
        protected int value;
        protected string flavorText;
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
        public Texture2D Texture
        {
            get { return texture; }
        }

        //Constructor
        public GameItem(int hashValue, string name, int value, string flavorText, Texture2D texture)
        {
            this.hashValue = hashValue;
            this.name = name;
            this.value = value;
            this.flavorText = flavorText;
            this.texture = texture;
        }

        //Draw
        public void Draw(Vector2 position, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
