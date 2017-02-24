using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyTycoon.GameItems
{
    abstract class GameItem
    {
        protected int hashValue;
        protected string name;
        protected int value;
        protected string flavorText;

        public GameItem(int hashValue, string name, int value, string flavorText)
        {
            this.hashValue = hashValue;
            this.name = name;
            this.value = value;
            this.flavorText = flavorText;
        }
    }
}
