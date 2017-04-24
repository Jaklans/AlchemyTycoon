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
        Texture2D npcTexture1;
        Texture2D npcTexture2;
        Texture2D npcTexture3;
        Texture2D npcTexture4;
        Texture2D npcTexture5;
        Texture2D npcTexture6;
        Texture2D npcTexture7;
        Texture2D npcTexture8;
        Texture2D npcTexture9;
        Texture2D npcTexture10;
        Rectangle npcPos;

        //Buttons
        Button stockButton;

        //Text
        SpriteFont spriteFont;
        Vector2 textPos;

        //Set the initial game screen size
        int screenWidth = 1280;
        int screenHeight = 800;

        //list of NPC textures
        List<Texture2D> textures = new List<Texture2D>();

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
            npcTexture1 = content.Load<Texture2D>("npc_standin.jpg");
            npcTexture2 = content.Load<Texture2D>("npc_standin.jpg");
            npcTexture3 = content.Load<Texture2D>("npc_standin.jpg");
            npcTexture4 = content.Load<Texture2D>("npc_standin.jpg");
            npcTexture5 = content.Load<Texture2D>("npc_standin.jpg");
            npcTexture6 = content.Load<Texture2D>("npc_standin.jpg");
            npcTexture7 = content.Load<Texture2D>("npc_standin.jpg");
            npcTexture8 = content.Load<Texture2D>("npc_standin.jpg");
            npcTexture9 = content.Load<Texture2D>("npc_standin.jpg");
            npcTexture10 = content.Load<Texture2D>("npc_standin.jpg");

            dO = new DrawableObject(npcTexture1, npcPos);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgScreen, screenPos, Color.White);
            stockButton.Draw(spriteBatch);
            dO.Draw(spriteBatch);
            spriteBatch.DrawString(spriteFont, "Gold: " + PlayerData.Instance.gold.ToString(), textPos, Color.White);
            npcPos = new Rectangle(-200, 0, 200, 600);
        }

        public void Update()
        {


            //fields
            bool interacting = false;
            bool moving = true;
            bool leaving = false;

            //move NPC to center
            while (moving == true) { npcPos.X += 5; }
            if(npcPos.X == screenWidth/2 - 100) { moving = false; }

            //start interaction
            while(moving == false) { interacting = true; }

            npc.MakeList();
            npc.BuyPotion();

            //NPC leaves shop
            if (moving == false && interacting == false) { leaving = true; }
            while (leaving == true) { npcPos.X += 5; }
            if(npcPos.X == screenWidth)
            {
                leaving = false;
            }

            
        }
    }
}
