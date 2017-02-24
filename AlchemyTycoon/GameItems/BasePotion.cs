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
        private string effect;
        private int[] potionHashValue;

        //Constructor
        public BasePotion(int hashValue, string name, int value, string flavorText, string effect, int[] potionHashValue) 
            : base(hashValue, name, value, flavorText)
        {
            this.effect = effect;
            this.potionHashValue = potionHashValue;
        }
        
    }
}
