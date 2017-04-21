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
            //look though if you have that potion in your inventory
            foreach (var item in shoppingCart)
            {


                //finds it attempt to buy
                if (true/* Potion is in inventory run calculation whether NPC will buy */)
                {

                
                        //Recommended Pricing 50/50
                        int baseChance = 50;

                        int playerPrice = 120;//fake for now
                        int recommendedPrice = 100;//fake for now

                        //the higher the price chance lowers
                        //the cheaper the price the higher the chance
                        //calculation (BaseChance)50 + (100*((Recommened Price - Player Price)/Recommened Price))
                        int chanceTime = baseChance + (100 * ((recommendedPrice - playerPrice) / recommendedPrice));

                        //if RNG(0, 101) Less than Chance Npc will buy.
                        if (rng.Next(0, 101) >= chanceTime)
                        {
                                //if lower remove from inventory
                                invent.RemoveItem(item.HashValue);
                                //and increase gold by player price

                        }
                    //if buying attemp fails (Price too high) continue loooking though list
                }
                //if npc buys a potion escape loop, Each npc will only buy 1 potion
                return;
                
            }
        }




    }
}
