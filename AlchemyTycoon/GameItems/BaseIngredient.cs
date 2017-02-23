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
        

        //Constructor
        public BaseIngredient(string name, int value, string flavorText, int[] color, int hashValue, string effect) 
            : base(name, value, flavorText, color, hashValue)
        {
            
        }
    }
}
