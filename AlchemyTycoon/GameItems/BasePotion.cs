using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyTycoon.GameItems
{
    class BasePotion : GameItem
    {
        //Feilds
        string effect;

        //Constructor
        public BasePotion(string name, int value, string flavorText, int[] color, int hashValue, string effect) 
            : base(name, value, flavorText, color, hashValue)
        {
            this.effect = effect;
            int[] ary = new int[3];
        }
        
    }
}
