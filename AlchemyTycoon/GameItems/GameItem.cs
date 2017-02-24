using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyTycoon.GameItems
{
    abstract class GameItem
    {
        //Feilds
        protected int hashValue;
        protected string name;
        protected int value;
        protected string flavorText;

        //Properties
        public int HashValue
        {
            get { return hashValue; }
        }
        public string Name
        {
            get { return name; }
        }
        public int Value
        {
            get { return value; }
        }
        public string FlavorText
        {
            get { return flavorText; }
        }

        //Constructor
        public GameItem(int hashValue, string name, int value, string flavorText)
        {
            this.hashValue = hashValue;
            this.name = name;
            this.value = value;
            this.flavorText = flavorText;
        }
    }
}
