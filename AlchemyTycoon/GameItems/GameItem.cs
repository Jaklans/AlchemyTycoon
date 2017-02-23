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

        public GameItem(string name, int value, string flavorText)
        {
            this.name = name;
            this.value = value;
            this.flavorText = flavorText;
        }
    }
}
