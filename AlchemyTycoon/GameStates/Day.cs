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
        SpriteFont spriteFont;
        Vector2 textPos;

        //Set the initial game screen size
        int screenWidth = 1280;
        int screenHeight = 800;

        NPC npc = new NPC();
        DrawableObject dO;

        //LoadContent method
        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            //gold = new Text()
            spriteFont = content.Load<SpriteFont>("Tahoma_40");
            textPos = new Vector2(screenWidth / 10, 3 * screenHeight / 4);

            //Load in the screen
            bgScreen = content.Load<Texture2D>("daytime");
            screenPos = new Rectangle(0, 0, screenWidth, screenHeight);

            //Load in the button
            stockButton = new Button(content.Load<Texture2D>("stockButton"), graphics);
            stockButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));

            //Load in the NPC
            //npcTexture = content.Load<Texture2D>();

            dO = new DrawableObject(npcTexture, npcPos);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgScreen, screenPos, Color.White);
            stockButton.Draw(spriteBatch);
            dO.Draw(spriteBatch);
            spriteBatch.DrawString(spriteFont, "Gold: " + PlayerData.Instance.gold.ToString(), textPos, Color.White);
            npcPos = new Rectangle(-200, 0, 200, 600);
        }

        public bool finished;
        public void Update(SpriteBatch spriteBatch)
        {
            
            for (int i = 0; i < 10; i++)
            {
                npc.Draw(spriteBatch, i);
                npc.Update();
            }      
        }
    }
}
