using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Writen by Aiden Thinn
namespace AlchemyTycoon
{
    class PlayerData
    {
        private static PlayerData instance;

        public static PlayerData Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PlayerData();
                }
                return instance;
            }
        }

        //Attributes - Factors pertaining to a specific user that need to be saved and loaded
        public string playerName;
        public int gold;
        public Inventory<GameItems.BasePotion> playerPotions;
        public Inventory<GameItems.BaseIngredient> playerIngredients;
        public Inventory<GameItems.BasePotion> playerKnownRecipies;

        //Constructor - Requires a name
        public PlayerData()
        {
            playerName = "I am a feild and I have no purpous. Riperoni";
            gold = 500;

            playerIngredients = new Inventory<GameItems.BaseIngredient>();
            playerPotions = new Inventory<GameItems.BasePotion>();
            playerKnownRecipies = new Inventory<GameItems.BasePotion>();
           
            playerIngredients.AddItem(Data.Instance.Ingrediants(1));
            playerIngredients.AddItem(Data.Instance.Ingrediants(2));
            playerIngredients.AddItem(Data.Instance.Ingrediants(3));
            playerIngredients.AddItem(Data.Instance.Ingrediants(4));
            playerIngredients.AddItem(Data.Instance.Ingrediants(5));
           
            playerPotions.AddItem(Data.Instance.Potions(1));
            playerPotions.AddItem(Data.Instance.Potions(2));
            playerPotions.AddItem(Data.Instance.Potions(3));
            playerPotions.AddItem(Data.Instance.Potions(4));
            playerPotions.AddItem(Data.Instance.Potions(5));
           
            playerKnownRecipies.AddItem(Data.Instance.Potions(1));
            playerKnownRecipies.AddItem(Data.Instance.Potions(2));
            playerKnownRecipies.AddItem(Data.Instance.Potions(3));
            playerKnownRecipies.AddItem(Data.Instance.Potions(4));
            playerKnownRecipies.AddItem(Data.Instance.Potions(5));

        }
    }
}
