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
        public bool finished;

        Random rng;

        //Background image
        Texture2D bgScreen;
        Rectangle screenPos;

        Texture2D infoBox;

        //Buttons

        //Text
        SpriteFont spriteFont;
        Vector2 textPos;

        //NPC
        List<NPC> npcList = new List<NPC>();

        public Day()
        {
            rng = new Random();

            for(int i = 0; i < 10; i++)
            {
                npcList.Add(new NPC(rng.Next(0, 2)));
            }
        }

        public void Reset()
        {
            npcList = new List<NPC>();

            for (int i = 0; i < 10; i++)
            {
                npcList.Add(new NPC(rng.Next(0, 50)));
            }
        }

        //Set the initial game screen size
        int screenWidth = 1920;
        int screenHeight = 1080;

        //LoadContent method
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            //gold = new Text()
            spriteFont = content.Load<SpriteFont>("Tahoma_40");
            textPos = new Vector2(screenWidth / 10, 3 * screenHeight / 4);

            //Load in the screen
            bgScreen = content.Load<Texture2D>("Screens/daytimeScreen");
            screenPos = new Rectangle(0, 0, screenWidth, screenHeight);

            infoBox = content.Load<Texture2D>("Screens/daytimeInfoBox");

            foreach(NPC i in npcList)
            {
                i.LoadContent(content);
            }
        }
        //praise mys
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgScreen, screenPos, Color.White);
            
            foreach(NPC i in npcList)
            {
                i.Draw(spriteBatch);
            }
            
            spriteBatch.Draw(infoBox, new Rectangle(0, 675, 1920, 800), Color.White);

            spriteBatch.DrawString(spriteFont, "Gold: " + PlayerData.Instance.gold.ToString(), textPos, Color.Black);

            PlayerData.Instance.playerPotions.Draw(spriteBatch, new Vector2(500, 800), 7, 3);
        }

        //NPCs enter and exit the shop
        public void Update()
        {
            npcList[0].Move();
            for(int i = 1; i < 10; i++)
            {
                if (npcList[i - 1].NpcPos.X >= screenWidth)
                {
                    if (npcList[i].Move() && i == 9)
                    {
                        finished = true;
                    }
                }
            }
        }
    }
}
