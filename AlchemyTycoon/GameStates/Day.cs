using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace AlchemyTycoon.GameStates
{
    class Day
    {
        //Background image
        Texture2D bgScreen;
        Rectangle ScreePos;

        //Buttons
        Button stockButton;

        //Text
        Text gold;
        Text time;
        Text stock;
        Text dialouge;
        Text npcInfo;

        //Set the initial game screen size
        int screenWidth = 1280;
        int screenHeight = 800;

        //LoadContent method
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            //gold = new Text()
            //Load in the screen
            bgScreen = content.Load<Texture2D>("daytime");

            //Load in the button
            stockButton = new Button(content.Load<Texture2D>("stockButton"), graphics);
            stockButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
        }

        //Update method
        public void Update()
        {
            //Get the mouse position
            MouseState mouse = Mouse.GetState();

            stockButton.Update(mouse);

            //When clicked, will go to inventory of potions the player made for sale
            if(stockButton.isClicked == true)
            {

            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgScreen, ScreePos, Color.White);
            stockButton.Draw(spriteBatch);
        }

    }
}
