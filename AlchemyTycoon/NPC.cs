﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace AlchemyTycoon
{
    class NPC
    {
        Random rng = new Random();
        //Data dt = new Data("potions");

        //Set the list of potions the NPC Wants
        List<GameItems.BasePotion> shoppingCart = new List<GameItems.BasePotion>();

        //Inventory<GameItems.BasePotion> invent = new Inventory<GameItems.BasePotion>();
        int screenWidth = 1280;
        int screenHeight = 800;
        int count = 0;

        Rectangle newNPCPos;
        Rectangle npcPos;
        public List<Texture2D> npcList = new List<Texture2D>();

        public void MakeList()
        {
            //the list will have 10 potions that a npc wants
            for (int i = 0; i < 10; i++)
            {
                //for 10 times add a random potion into NPC ShoppingCart
                //shoppingCart.Add(dt.Potions(rng.Next(0, dt.PotionCount + 1)));
                shoppingCart.Add(Data.Instance.RandomPotion);
            }
        }

        public void BuyPotion()
        {
            bool done = false;
            //look though if you have that potion inNPC wishlist
            foreach (var item in shoppingCart)
            {
                //Loop through your inventory

                foreach (var playerItem in PlayerData.Instance.playerPotions.inventoryData)
                {
                    //Find if Potion Values match
                    if (item.HashValue == playerItem.HashValue && !done)
                    {
                        //Recommended Pricing 50/50
                        int baseChance = 50;

                        int playerPrice = Data.Instance.Potions(item.HashValue).Value;//fake for now
                        int recommendedPrice = Data.Instance.Potions(item.HashValue).Value;//Potion's base value

                        //the higher the price chance lowers
                        //the cheaper the price the higher the chance
                        //calculation (BaseChance)50 + (100*((Recommened Price - Player Price)/Recommened Price))
                        int chanceTime = baseChance + (100 * ((recommendedPrice - playerPrice) / recommendedPrice));

                        //if RNG(0, 101) Less than Chance Npc will buy.
                        if (rng.Next(0, 101) >= chanceTime)
                        {
                            //if lower remove from inventory
                            PlayerData.Instance.playerPotions.RemoveItem(item.HashValue);
                            //and increase gold by player price
                            //needs to access player's gold and increase
                            PlayerData.Instance.gold += playerPrice;

                            //if npc buys a potion escape loop, Each npc will only buy 1 potion
                            done = true;
                            return;
                        }
                        //if buying attemp fails (Price too high) continue loooking though list
                    }
                }   
                
            }
            //leaves if looked through all inventories and finds nothing
        }

        public void LoadContent(ContentManager content, GraphicsDevice graphics)
        {
            for (int i = 0; i < 10; i++)
            {
                npcList.Add(content.Load<Texture2D>("npc_standin"));
            }
            npcPos = new Rectangle(-200, 0, 200, 600);
            newNPCPos = npcPos;
        }

        public bool finished = false;
        Texture2D currentNPC;
        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 10; i++)
            {
                spriteBatch.Draw(npcList[i], newNPCPos, Color.White);
            }
        }
        public void Update()
        {

            //fields
            bool interacting = false;
            bool moving = true;
            bool leaving = false;

            //move NPC to center
            while (moving == true) { npcPos.X += 5; }
            if (npcPos.X == screenWidth / 2 - 100) { moving = false; }

            //start interaction
            while (moving == false) { interacting = true; }

            this.MakeList();
            this.BuyPotion();

            //NPC leaves shop
            if (moving == false && interacting == false) { leaving = true; }
            while (leaving == true) { npcPos.X += 5; }
            if (npcPos.X == screenWidth)
            {
                leaving = false;
            }

            if(newNPCPos.X == screenWidth && currentNPC == npcList[9])
            {
                finished = true;
            }

            else if (newNPCPos.X == screenWidth && currentNPC != npcList[9])
            {
                newNPCPos = npcPos;
            }
        }

    }
}
