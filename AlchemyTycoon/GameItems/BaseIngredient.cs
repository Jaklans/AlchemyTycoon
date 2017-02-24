using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyTycoon.GameItems
{
    class BaseIngredient : GameItem
    {
        //Feilds
        int ingredientHashValue;

        //Constructor
        public BaseIngredient(int hashValue, string name, int value, string flavorText) 
            : base(hashValue, name, value, flavorText)
        {

        }
    }
}
