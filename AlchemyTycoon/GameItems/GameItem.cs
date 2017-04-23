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

        public virtual void DrawInfo()
        {

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
    }
}
