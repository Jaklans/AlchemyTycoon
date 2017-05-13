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

        //Background image
        Texture2D bgScreen;
        Rectangle screenPos;

        //Buttons
        Button stockButton;

        //Text
        Text gold;
        Text time;
        Text stock;
        Text dialouge;
        Text npcInfo;
        SpriteFont spriteFont;
        Vector2 textPos;

        //NPC
        List<NPC> npcList = new List<NPC>();

        public Day()
        {
            for(int i = 0; i < 10; i++)
            {
                npcList.Add(new NPC());
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

            foreach(NPC i in npcList)
            {
                i.LoadContent(content);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgScreen, screenPos, Color.White);
            spriteBatch.DrawString(spriteFont, "Gold: " + PlayerData.Instance.gold.ToString(), textPos, Color.White);

            foreach(NPC i in npcList)
            {
                i.Draw(spriteBatch);
            }
        }

        //NPCs enter and exit the shop
        public void Update()
        {
            npcList[0].Move();
            for(int i = 1; i < 10; i++)
            {
                if (npcList[i - 1].NpcPos.X >= screenWidth) { npcList[i].Move(); }
                Console.WriteLine(npcList[i].NpcPos.X);
            }
        }
    }
}
