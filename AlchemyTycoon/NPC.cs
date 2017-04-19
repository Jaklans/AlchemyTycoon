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
        Data dt = new Data("potions");

        //Set the list of potions the NPC Wants
        List<GameItems.BasePotion> shoppingCart = new List<GameItems.BasePotion>();
        public void MakeList()
        {
            //the list will have 10 potions that a npc wants
            for (int i = 0; i < 10; i++)
            {
                //for 10 times add a random potion into NPC ShoppingCart
                shoppingCart.Add(dt.Potions(rng.Next(0, dt.PotionCount + 1)));
            }
        }
        public void BuyPotion()
        {
            //look though if you have thhat potion in your inventory

            //finds it attempt to buy

            //Recommended Pricing 50/50
            //the higher the price chance lowers
            //the cheaper the price the higher the chance
            //calculation (BaseChance)50 + (100*((Recommened Price - Player Price)/Recommened Price))
            //if RNG(0, 101) Less than Chance Npc will buy.

            //if buying attemp fails (Price too high) continue loooking though list

            //if npc buys a potion escape loop, Each npc will only buy 1 potion

            //if Npc does not find potion, escape loop


        }




    }
}
