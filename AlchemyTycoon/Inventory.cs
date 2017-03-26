﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlchemyTycoon
{
    //Handles either a potion or ingredient inventory
    class Inventory<T> where T : GameItems.GameItem
    {
            //Feilds
        private List<T> data;
        private int selectedItemIndex;

        private int xDepth;
        private int yDepth;
        private Rectangle bounds;

        private MouseState previousMousestate;

        public Data theData = new Data("../../../../itemfolder");

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
            data.Add(item);
        }

        public GameItems.BasePotion MakePotion()
        {
            if(data.Count >= 4)
            {
                /*List<int> craftList = new List<int>();
                craftList.Add(data[0].HashValue);
                craftList.Add(data[1].HashValue);
                craftList.Add(data[2].HashValue);
                craftList.Add(data[3].HashValue);*/
                

                GameItems.BasePotion thePotion;
                thePotion = theData.CreatePotion2(data[0].HashValue, data[1].HashValue, data[2].HashValue, data[3].HashValue);

                return thePotion;
            }
            else
            {
                return null;
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
        public Inventory<T> Update(MouseState mouseState, Inventory<T> otherInventory)
        {
            selectedItemIndex = -1;

            if (bounds.Contains(new Point(mouseState.X, mouseState.Y)) &&
                mouseState.LeftButton == ButtonState.Released &&
                previousMousestate.LeftButton == ButtonState.Pressed &&
                data.Count != 0)
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

                if (targetItemIndex < data.Count)
                {
                    otherInventory.AddItem(data[targetItemIndex]);
                    data.RemoveAt(targetItemIndex);
                }
            }

            previousMousestate = mouseState;

            return otherInventory;
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
                if (selectedItemIndex != -1 && selectedItemIndex < data.Count)
                {
                    return data[selectedItemIndex];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                previousMousestate = mouseState;

                return null;
            }
        }

        /// <summary>
        /// Draw method for all items in an invntory. Uses the given textures
        /// size for sizing! Cannot be rescaled, and all elements must have
        /// same dimentions, or will crash terribly
        /// </summary>
        /// <param name="sb">Input SpriteBatch</param>
        /// <param name="position">The location of the Inventory (Top Left corner)</param>
        /// <param name="vXDepth">Number of columns desired</param>
        /// <param name="vYDepth">Number of rows desired</param>
        public void Draw(SpriteBatch sb, Vector2 position, int vXDepth, int vYDepth)
        {
            if (data.Count != 0)
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
                for (int i = 0; i < yDepth; i++)
                {
                    for (int j = 0; j < xDepth; j++)
                    {
                        if (index < data.Count)
                        {
                            if (index != selectedItemIndex)
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
                            else
                            {
                                sb.Draw(
                                    data[index].Texture,
                                    new Vector2(
                                        position.X +
                                        j * data[index].Texture.Width,
                                        position.Y +
                                        i * data[index].Texture.Height
                                    ),
                                    Color.Aqua);
                            }
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
}
