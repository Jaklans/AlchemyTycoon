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
        private int selectedItemIndex;
        private bool active;

        private int xDepth;
        private int yDepth;
        private Rectangle bounds;

        private MouseState previousMousestate;

            //Constructor
        public Inventory()
        {
            data = new List<T>();

            selectedItemIndex = -1;
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
        
        /// <summary>
        /// This version of update only gets called when there are two 
        /// inventories on screen. It handles the swap if an item is 
        /// clicked
        /// </summary>
        /// <param name="mouseState">Mousestate for selection</param>
        /// <param name="otherInventory">The other inventory on screen
        /// that items will transfer too when clicked on</param>
        /// <returns></returns>
        public void Update(MouseState mouseState, Inventory<T> otherInventory)
        {
            if (bounds.Contains(new Point(mouseState.X, mouseState.Y)) &&
                mouseState.LeftButton == ButtonState.Released &&
                previousMousestate.LeftButton == ButtonState.Pressed)
            {
                Vector2 mouse = mouseState.Position.ToVector2();

                //Deals with only the distance from top left
                mouse.X -= bounds.X;
                mouse.Y -= bounds.Y;

                //Divides by image dimmentions, resulting in only the cords on a grid
                mouse.X /= data[0].Texture.Width;
                mouse.Y /= data[0].Texture.Height;

                int targetItemIndex = 0;

                targetItemIndex += (xDepth * (int)mouse.Y);
                targetItemIndex += (int)mouse.X;

                otherInventory.AddItem(RemoveItem(targetItemIndex));

                previousMousestate = mouseState;
            }

            previousMousestate = mouseState;
        }

        /// <summary>
        ///This version of update gets called when only one inventory is on
        ///screen. It returns an object that is clicked on
        /// </summary>
        /// <param name="mouseState">Mousestate for selection</param>
        /// <returns></returns>
        public T Update(MouseState mouseState)
        {
            if (bounds.Contains(new Point(mouseState.X, mouseState.Y)) &&
                mouseState.LeftButton == ButtonState.Released &&
                previousMousestate.LeftButton == ButtonState.Pressed)
            {

                Vector2 mouse = mouseState.Position.ToVector2();

                //Deals with only the distance from top left
                mouse.X -= bounds.X;
                mouse.Y -= bounds.Y;

                //Divides by image dimmentions, resulting in only the cords on a grid
                mouse.X /= data[0].Texture.Width;
                mouse.Y /= data[0].Texture.Height;

                int targetItemIndex = 0;

                targetItemIndex += (xDepth * (int)mouse.Y);
                targetItemIndex += (int)mouse.X;
                
                previousMousestate = mouseState;
                
                if (selectedItemIndex != targetItemIndex)
                {
                    selectedItemIndex = targetItemIndex;
                }
                else
                {
                    selectedItemIndex = -1;
                }

                return data[selectedItemIndex];
            }
            else
            {
                previousMousestate = mouseState;

                return null;
            }
        }

        public void Draw(SpriteBatch sb, Vector2 position, int vXDepth, int vYDepth)
        {
            xDepth = vXDepth;
            yDepth = vYDepth;

            bounds = new Rectangle(
                (int)position.X,
                (int)position.Y,
                xDepth * data[0].Texture.Width,
                yDepth * data[0].Texture.Height
                );
            //Could be optimized to only do once
            

            //Handles the drawing of static item grid
            int index = 0;
            for(int i = 0; i < yDepth; i++)
            {
                for(int j = 0; j < xDepth; j++)
                {
                    if (index < data.Count)
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
                    /*else if(index < data.Count)
                    {
                        //Selected Item will be Aqua for now
                        sb.Draw(
                            data[index].Texture,
                            new Vector2(
                                position.X +
                                j * data[index].Texture.Width,
                                position.Y +
                                i * data[index].Texture.Height
                                ),
                            Color.Aqua
                            );
                    }*/
                    index++;
                }
            }

        }
    }
}
