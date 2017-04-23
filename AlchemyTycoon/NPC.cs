using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlchemyTycoon
{
    class NPC
    {
        Random rng = new Random();
        //Data dt = new Data("potions");

        //Set the list of potions the NPC Wants
        List<GameItems.BasePotion> shoppingCart = new List<GameItems.BasePotion>();

        Inventory<GameItems.BasePotion> invent = new Inventory<GameItems.BasePotion>();

        int count = 0;

        public void MakeList()
        {
            //the list will have 10 potions that a npc wants
            for (int i = 0; i < 10; i++)
            {
                //for 10 times add a random potion into NPC ShoppingCart
                //shoppingCart.Add(dt.Potions(rng.Next(0, dt.PotionCount + 1)));
                shoppingCart.Add(Data.Instance.Potions(rng.Next(0, Data.Instance.PotionCount + 1)));
            }
        }

        public void BuyPotion()
        {
            //look though if you have that potion inNPC wishlist
            foreach (var item in shoppingCart)
            {
                //Loop through your inventory

                foreach (var playerItem in PlayerData.Instance.playerPotions.inventoryData)
                {
                    //Find if Potion Values match
                    if (item.HashValue == playerItem.HashValue)
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
                            Leave();
                            return;
                        }
                        //if buying attemp fails (Price too high) continue loooking though list
                    }
                }   
                
            }
            //leaves if looked through all inventories and finds nothing
            Leave();
        }
        public bool Leave()
        {
            bool leave = false;
            count++;
            if (count == 11)
            {
                leave = true;
                count = 0;
            }
            return leave;
        }



    }
}
