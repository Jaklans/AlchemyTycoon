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
        //A list to hold game items/potions
        private List<T> data;

        //Constructor/Initializator
        public Inventory()
        {
            //Performs initialization
            data = new List<T>();
        }
        
        //RemoveItem Method - For when the player sells a potion
        public T RemoveItem(int index)
        {
            //Removes item from a specific index of the list
            T temp = data[index];
            data.RemoveAt(index);
            return temp;
        }

        //AddItem Method - For when the player creates a potion
        public void AddItem(T item)
        {
            
            //Adds a new item to the list
            if(item.HashValue > data[data.Count / 2].HashValue)
            {
                //Adds the item using Add method
                data.Add(item);

                //Sorts the list after adding the item
                data.Sort();
            }
        }

        //Draw method 
        public void Draw(SpriteBatch sb, Vector2 position, int rows, int coloumns)
        {
            int index = 0;
            for(int i = 0; i < coloumns; i++)
            {
                for(int j = 0; j < rows; j++)
                {
                    data[index].draw();
                    index++;
                }
            }
        }
    }
}
