using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

//Written by Aaron Reiner
namespace AlchemyTycoon.GameStates
{
    class Day
    {
        //Background image
        Texture2D bgScreen;
        Rectangle screenPos;

        //NPC
        private Texture2D npcTexture;
        private Rectangle npcPos;

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

        NPC npc = new NPC();
        DrawableObject dO;

        //LoadContent method
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            //gold = new Text()
            //Load in the screen
            bgScreen = content.Load<Texture2D>("daytime");
            screenPos = new Rectangle(0, 0, screenWidth, screenHeight);

            //Load in the button
            stockButton = new Button(content.Load<Texture2D>("stockButton"), graphics);
            stockButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));

            //Load in the NPC
            npcTexture = content.Load<Texture2D>();
            npcPos = new Rectangle(-200, 0, 200, 600);

            dO = new DrawableObject(npcTexture, npcPos);
        }
        private void CallNPCS()
        {
            for (int i = 0; i < 10; i++)
            {
                npc.MakeList();
                npc.BuyPotion();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgScreen, screenPos, Color.White);
            stockButton.Draw(spriteBatch);
            dO.Draw(spriteBatch);
        }
        public void Update(Rectangle position)
        {

            bool interacting = false;
            bool moving = true;
            bool leaving = false;

            //move NPC to center
            while (moving == true) { position.X += 5; }
            if(position.X == screenWidth/2 - 100) { moving = false; }

            //start interaction
            while(moving == false) { interacting = true; }

            //NPC leaves shop
            if (moving == false && interacting == false) { leaving = true; }
            while (leaving == true) { position.X += 5; }
            if(position.X == screenWidth)
            {
                leaving = false;
            }

        }
    }
}
