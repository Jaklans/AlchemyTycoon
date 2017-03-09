using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlchemyTycoon.GameItems
{
    //Handles either a potion or ingredient inventory
    class Inventory<T> where T : GameItems.GameItem
    {
        //A list to hold game items
        private List<T> data;

        //Constructor
        public Inventory()
        {
            //Performs initialization
            data = new List<T>();
        }
        
        //RemoveItem Method
        public T RemoveItem(int index)
        {
            //Removes item from a specific index
            T temp = data[index];
            data.RemoveAt(index);
            return temp;
        }

        //AddItem Method
        public void AddItem(T item)
        {
            
            //Add a new item to the list
            if(item.HashValue > data[data.Count / 2].HashValue)
            {
                //Recursion???
            }
        }

        //Draw method - Not implenmented yet
        public void Draw(SpriteBatch sb)
        {
            //sb.Draw();
        }
    }
}
