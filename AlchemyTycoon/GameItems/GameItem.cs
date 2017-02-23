using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyTycoon.GameItems
{
    abstract class GameItem
    {
        protected string name;
        protected int value;
        protected string flavorText;
        protected int[] color;
        protected int hashValue;

        public GameItem(string name, int value, string flavorText, int[] color, int hashValue)
        {
            this.name = name;
            this.value = value;
            this.flavorText = flavorText;
            this.color = color;
            this.hashValue = hashValue;
        }
    }
}
