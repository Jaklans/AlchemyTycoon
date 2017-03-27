using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;


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
        public BasePotion(int hashValue, string name, int value, int[] potionHashValue, string flavorText, string effect,  string textureName) 
            : base(hashValue, name, value, flavorText, textureName)
        {
            this.effect = effect;
            this.potionHashValue = potionHashValue;
        }
        
    }
}
