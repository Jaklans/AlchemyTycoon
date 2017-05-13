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
    class BasePotion : GameItem
    {
        //Feilds
        protected string effect;
        protected int[] potionHashValue;

        //Properties
        public string Effect
        {
            get { return effect; }
        }
        public int[] PotionHashValue
        {
            get { return potionHashValue; }
        }

        //Constructor
        public BasePotion(int hashValue, string name, int value, int[] potionHashValue, string flavorText, string effect, string textureName)
            : base(hashValue, name, value, flavorText, textureName)
        {
            this.effect = effect;
            this.potionHashValue = potionHashValue;
        }


        public void DrawRecipeInfo(SpriteBatch spriteBatch, Rectangle infoBox, SpriteFont font)   
        {
            base.DrawInfo(spriteBatch, infoBox, font);
            
            spriteBatch.DrawString(font, 
                Data.Instance.Ingrediants(PotionHashValue[0]).Name + "\n" + 
                Data.Instance.Ingrediants(PotionHashValue[1]).Name + "\n" +
                Data.Instance.Ingrediants(PotionHashValue[2]).Name + "\n" +
                Data.Instance.Ingrediants(PotionHashValue[3]).Name, 
                new Vector2(
                infoBox.X,
                (float)(infoBox.Y + texture.Height + .9 * infoBox.Height)),
                Color.Black);

            spriteBatch.Draw(Data.Instance.Ingrediants(PotionHashValue[0]).Texture,
                new Vector2(
                infoBox.X + infoBox.Width - 150,
                (float)(infoBox.Y + texture.Height + .9 * infoBox.Height)),
                Color.White);
            spriteBatch.Draw(Data.Instance.Ingrediants(PotionHashValue[1]).Texture,
                new Vector2(
                infoBox.X + infoBox.Width - 75,
                (float)(infoBox.Y + texture.Height + .9 * infoBox.Height)),
                Color.White);
            spriteBatch.Draw(Data.Instance.Ingrediants(PotionHashValue[2]).Texture,
                new Vector2(
                infoBox.X + infoBox.Width - 150,
                (float)(infoBox.Y + texture.Height + .9 * infoBox.Height + 75)),
                Color.White);
            spriteBatch.Draw(Data.Instance.Ingrediants(PotionHashValue[3]).Texture,
                new Vector2(
                infoBox.X + infoBox.Width - 75,
                (float)(infoBox.Y + texture.Height + .9 * infoBox.Height + 75)),
                Color.White);
        }
    }
}
