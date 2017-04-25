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
            playerName = "I am a feild and I have no purpous atm. Riperoni";
            gold = 500;

            playerIngredients = new Inventory<GameItems.BaseIngredient>();
            playerPotions = new Inventory<GameItems.BasePotion>();
            playerKnownRecipies = new Inventory<GameItems.BasePotion>();
        }
    }
}
