using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace AlchemyTycoon.GameItems
{
    class BaseIngredient : GameItem
    {
        //Feilds
        protected int ingredientHashValue;

        //Properties
        public int IngredientHashValue
        {
            get { return ingredientHashValue; }
        }

        //Constructor
        public BaseIngredient(int hashValue, string name, int value, string flavorText, Texture2D texture) 
            : base(hashValue, name, value, flavorText, texture)
        {

        }
    }
}
