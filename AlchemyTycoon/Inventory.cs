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
            //Feilds
        private List<T> data;
        private int movingItemIndex;// The index of an item that is being dragged by the mouse
        private bool active;
        private Rectangle bounds;

            //Constructor
        public Inventory()
        {
            data = new List<T>();
            
            movingItemIndex = -1;
            // -1 signifies no item is being moved
        }

            //Methods
        public T RemoveItem(int index)
        {
            //Removes item from a specific index of the list
            T temp = data[index];
            data.RemoveAt(index);
            return temp;
        }
        
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

        public void Update(MouseState mouseState)
        {
            if (bounds.Contains(new Point(mouseState.X, mouseState.Y)))
            {

            }
        }
        
        public void Draw(SpriteBatch sb, Vector2 position, int rows, int coloumns)
        {
            bounds = new Rectangle(
                (int)position.X,
                (int)position.Y,
                rows * data[0].Texture.Width,
                coloumns * data[0].Texture.Height
                );
                //Could be optimized to only do once

            //Handles the drawing of static item grid
            int index = 0;
            for(int i = 0; i < rows; i++)
            {
                for(int j = 0; j < coloumns; j++)
                {
                    if (index != movingItemIndex && index < data.Count)
                    {
                        data[index].Draw(
                            new Vector2(
                                position.X +
                                j * data[index].Texture.Width,
                                position.Y +
                                i * data[index].Texture.Height
                                ),
                            sb
                            );
                    }
                    index++;
                }
            }
            //Handles Click and Drag drawing functions
            // (tied to update method)

        }
        
    }
}
