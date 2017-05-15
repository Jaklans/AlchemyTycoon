using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

//Written by Aiden Thinn, Simeon Chang, John Shull
namespace AlchemyTycoon
{
    public class NewNight
    {
        enum nightState
        {
            Default,
            Inventory,
            Kit,
            Recipes,
            IngrediantShop,
            RecipeShop
        }

        nightState state;
        nightState previousState;
        int stateChangeCooldown;

        public bool done;

        private DrawableObject defaultScreen;
        private DrawableObject inventoryScreen;
        private DrawableObject kitScreen;
        private DrawableObject recipeScreen;
        private DrawableObject ingrediantShop;
        private DrawableObject recipeShop;

        private Random rng;

        //Buttons on all non default screens
        newButton backButton;

        //Buttons on default screen
        newButton inventoryButton;
        newButton kitButton;
        newButton recipeButton;
        newButton dayButton;

        //Buttons on kit screen
        newButton makeButton;
        newButton clearButton;
        //Miscilanious kit itmes
        Inventory<GameItems.BaseIngredient> craftingTable;
        Inventory<GameItems.BasePotion> craftingOutput;

        //Buttons on recipe book screen
        newButton recipeShopButton;

        //Buttons on recipe purchace screen
        newButton recipePurchace;
        //Miscillanious recipe purchace items
        Inventory<GameItems.BasePotion> recipeStore;

        //Buttons on Inventory screen
        newButton storeButton;
        //Micilanious Inventory items
        GameItems.GameItem displayingItem;

        //Buttons on ingredient purchace screen
        newButton ingredientPurchace;
        //Miscillanious ing. purchace items
        Inventory<GameItems.BaseIngredient> itemStore;


        int screenWidth = 1920;
        int screenHeight = 1080;

        private SpriteFont text;

        //Allows to itterate through and draw everything from a set group
        private Dictionary<nightState, List<DrawableObject>> drawlables;


        public NewNight()
        {
            state = nightState.Default;
            previousState = nightState.Default;
            stateChangeCooldown = 0;

            drawlables = new Dictionary<nightState, List<DrawableObject>>();

            rng = new Random();

            craftingTable = new Inventory<GameItems.BaseIngredient>();
            craftingOutput = new Inventory<GameItems.BasePotion>();

            itemStore = new Inventory<GameItems.BaseIngredient>();
            recipeStore = new Inventory<GameItems.BasePotion>();

            for (int i = 0; i < 14; i++)
            {
                itemStore.AddItem(Data.Instance.RandomIngredient);
            }
            for (int i = 0; i < 7; i++)
            {
                recipeStore.AddItem(Data.Instance.RandomPotion);
            }
        }

        public void Clear()
        {
            itemStore = new Inventory<GameItems.BaseIngredient>();
            recipeStore = new Inventory<GameItems.BasePotion>();

            for (int i = 0; i < 14; i++)
            {
                itemStore.AddItem(Data.Instance.RandomIngredient);
            }
            for (int i = 0; i < 7; i++)
            {
                recipeStore.AddItem(Data.Instance.RandomPotion);
            }

            done = false;
        }

        public void LoadContent(ContentManager content)
        {
            //Back Button
            backButton = new newButton(
                content.Load<Texture2D>("Buttons/backButton"),
                content.Load<Texture2D>("Buttons/backButtonHL"),
                new Vector2(1400, 85));


            //Default Screen
            defaultScreen = new DrawableObject(
                content.Load<Texture2D>("Screens/nightScreen"),
                new Rectangle(0, 0, screenWidth, screenHeight));
            inventoryButton = new newButton(
                content.Load<Texture2D>("Buttons/allTemp"),
                content.Load<Texture2D>("Buttons/ingredientsTemp"));
            kitButton = new newButton(
                content.Load<Texture2D>("Buttons/allTemp"),
                content.Load<Texture2D>("Buttons/kitTemp"),
                new Vector2(660, 0));
            recipeButton = new newButton(
                content.Load<Texture2D>("Buttons/allTemp"),
                content.Load<Texture2D>("Buttons/recipeTemp"),
                new Vector2(1260, 0));
            dayButton = new newButton(
                content.Load<Texture2D>("Buttons/goToDay"),
                content.Load<Texture2D>("Buttons/goToDayHL"),
                new Vector2(1800, 1000));

            drawlables.Add(
                nightState.Default,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    inventoryButton,
                    kitButton,
                    recipeButton,
                    dayButton
                });


            //Kit Screen
            kitScreen = new DrawableObject(
                content.Load<Texture2D>("Screens/kitScreen"),
                new Rectangle(280, 140, 1300, 800));
            makeButton = new newButton(
                content.Load<Texture2D>("Buttons/makeButton"),
                content.Load<Texture2D>("Buttons/makeButtonHL"),
                new Vector2(1300, 700));
            clearButton = new newButton(
                content.Load<Texture2D>("Buttons/clearButton"),
                content.Load<Texture2D>("Buttons/clearButtonHL"),
                new Vector2(1100, 700));

            drawlables.Add(
                nightState.Kit,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    kitScreen,
                    makeButton,
                    clearButton,
                    backButton
                });


            //Recipe Screen
            recipeScreen = new DrawableObject(
                content.Load<Texture2D>("Screens/recipeScreen"),
                new Rectangle(280, 140, 1300, 800));
            recipeShopButton = new newButton(
                content.Load<Texture2D>("Buttons/shop"),
                content.Load<Texture2D>("Buttons/shopHL"),
                new Vector2(300, 85));

            drawlables.Add(
                nightState.Recipes,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    recipeScreen,
                    recipeShopButton,
                    backButton
                });


            //Recipe Shop Screen
            recipeShop = new DrawableObject(
                content.Load<Texture2D>("Screens/recipeShop"),
                new Rectangle(280, 140, 1300, 800));
            recipePurchace = new newButton(
                content.Load<Texture2D>("Buttons/purchase"),
                content.Load<Texture2D>("Buttons/purchaseHL"),
                new Vector2(1400, 740));

            drawlables.Add(
                nightState.RecipeShop,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    recipeScreen,
                    recipeShop,
                    recipePurchace,
                    backButton
                });


            //Inventory Screen
            inventoryScreen = new DrawableObject(
                content.Load<Texture2D>("Screens/inventoryScreen"),
                new Rectangle(280, 140, 1300, 800));
            storeButton = new newButton(
                content.Load<Texture2D>("Buttons/shop"),
                content.Load<Texture2D>("Buttons/shopHL"),
                new Vector2(300, 85));

            drawlables.Add(
                nightState.Inventory,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    inventoryScreen,
                    storeButton,
                    backButton
                });


            //Ingrediant Shop Screen
            ingrediantShop = new DrawableObject(
                content.Load<Texture2D>("Screens/ingredientShop"),
                new Rectangle(280, 140, 1300, 800));
            ingredientPurchace = new newButton(
                content.Load<Texture2D>("Buttons/purchase"),
                content.Load<Texture2D>("Buttons/purchaseHL"),
                new Vector2(1400, 740));

            drawlables.Add(
                nightState.IngrediantShop,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    ingrediantShop,
                    ingredientPurchace,
                    backButton
                });


            //Text Font
            text = content.Load<SpriteFont>("Tahoma_40");
            text = content.Load<SpriteFont>("font");
        }

        public void Update(MouseState mouse)
        {
            if (stateChangeCooldown > 0)
            {
                stateChangeCooldown--;
                return;
            }

            dayButton.Update(mouse);

            if (dayButton.Clicked) { done = true; }

            switch (state)
            {
                //Default Screen
                case nightState.Default:
                    //Buttons
                    inventoryButton.Update(mouse);
                    kitButton.Update(mouse);
                    recipeButton.Update(mouse);

                    if (inventoryButton.Clicked) { state = nightState.Inventory; }
                    else if (kitButton.Clicked) { state = nightState.Kit; }
                    else if (recipeButton.Clicked) { state = nightState.Recipes; }

                    break;

                //Kit Screen
                case nightState.Kit:
                    //Buttons
                    backButton.Update(mouse);
                    makeButton.Update(mouse);
                    clearButton.Update(mouse);

                    if (backButton.Clicked || clearButton.Clicked)
                    {
                        if (backButton.Clicked) { state = nightState.Default; }

                        //Clears the table (done in either case)
                        while (craftingTable.inventoryData.Count != 0)
                        {
                            PlayerData.Instance.
                                playerIngredients.AddItem(
                                craftingTable.RemoveItem(0)
                                );
                        }
                        while (craftingOutput.inventoryData.Count != 0)
                        {
                            PlayerData.Instance.
                                playerPotions.AddItem(
                                craftingOutput.RemoveItem(0)
                                );
                        }
                    }

                    if (makeButton.Clicked && craftingTable.inventoryData.Count != 0)
                    {
                        GameItems.BasePotion temp = craftingTable.MakePotion();
                        if (temp != null)
                        {
                            craftingOutput.AddItem(temp);
                        }
                        else
                        {
//!Should add a junk potion, need sam to write that in
                        }
                    }

                    //Inventories
                    craftingOutput.Update(mouse, PlayerData.Instance.playerPotions);
                    craftingTable.Update(mouse, PlayerData.Instance.playerIngredients);
                    if (craftingTable.inventoryData.Count < 4)
                    {
                        PlayerData.Instance.playerIngredients.Update(mouse, craftingTable);
                    }

                    break;

                //Inventory Screen
                case nightState.Inventory:
                    //Buttons
                    backButton.Update(mouse);
                    storeButton.Update(mouse);

                    if (backButton.Clicked)
                    {
                        state = nightState.Default;
                        PlayerData.Instance.playerIngredients.selectedItemIndex = -1;
                        PlayerData.Instance.playerPotions.selectedItemIndex = -1;
                    }

                    if (storeButton.Clicked)
                    {
                        state = nightState.IngrediantShop;
                        PlayerData.Instance.playerIngredients.selectedItemIndex = -1;
                        PlayerData.Instance.playerPotions.selectedItemIndex = -1;
                    }

                    //Inventories
                    GameItems.BaseIngredient tempIngredient = PlayerData.Instance.playerIngredients.Update(mouse);
                    GameItems.BasePotion tempPotion = PlayerData.Instance.playerPotions.Update(mouse);

                    //Logic to determine which gameItem should be displayed, potion or ingredient
                    if (tempIngredient != null)
                    {
                        displayingItem = tempIngredient;

                    }
                    else if (tempPotion != null)
                    {
                        displayingItem = tempPotion;
                        PlayerData.Instance.playerIngredients.selectedItemIndex = -1;
                    }

                    break;

                //Inventory Purchace Screen
                case nightState.IngrediantShop:
                    //Buttons
                    backButton.Update(mouse);
                    ingredientPurchace.Update(mouse);

                    if (backButton.Clicked) { state = nightState.Inventory; itemStore.selectedItemIndex = -1; }

                    //Inventories
                    GameItems.BaseIngredient selectedItem = itemStore.Update(mouse);

                    if (selectedItem != null)
                    {
                        displayingItem = selectedItem;
                    }

                    if (ingredientPurchace.Clicked && displayingItem != null && PlayerData.Instance.gold >= displayingItem.Value)
                    {
                        PlayerData.Instance.playerIngredients.AddItem(
                            itemStore.RemoveItem((GameItems.BaseIngredient)displayingItem));
                        PlayerData.Instance.gold -= displayingItem.Value;
                        displayingItem = null;
                        itemStore.selectedItemIndex = -1;
                    }

                    break;

                //Recipe Book Screen
                case nightState.Recipes:
                    backButton.Update(mouse);
                    recipeShopButton.Update(mouse);

                    if (backButton.Clicked)
                    {
                        state = nightState.Default;
                        PlayerData.Instance.playerKnownRecipies.selectedItemIndex = -1;
                    }
                    if (recipeShopButton.Clicked) { state = nightState.RecipeShop; }

                    GameItems.BasePotion selectedPotion = PlayerData.Instance.playerKnownRecipies.Update(mouse);

                    if (selectedPotion != null)
                    {
                        displayingItem = selectedPotion;
                    }

                    break;

                //Recipe Purchace Screen
                case nightState.RecipeShop:
                    backButton.Update(mouse);
                    recipePurchace.Update(mouse);

                    if (backButton.Clicked) { state = nightState.Recipes; recipeStore.selectedItemIndex = -1; }

                    GameItems.BasePotion selectedRecipies = recipeStore.Update(mouse);

                    if(selectedRecipies != null)
                    {
                        displayingItem = selectedRecipies;
                    }

                    if(displayingItem != null && recipePurchace.Clicked && PlayerData.Instance.gold > 3 * displayingItem.Value)
                    {
                        PlayerData.Instance.playerKnownRecipies.AddItem((GameItems.BasePotion)displayingItem);

                        PlayerData.Instance.gold -= displayingItem.Value * 3;

                        displayingItem = null;
                        recipeStore.selectedItemIndex = -1;
                    }

                    break;

                default:
                    break;
            }
            if (state != previousState)
            {
                stateChangeCooldown = 15;
                previousState = state;
                displayingItem = null;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //Draws all basic objects for each gamestate (buttons and backgrounds)
            foreach (DrawableObject drawlable in drawlables[state])
            {
                drawlable.Draw(spriteBatch);
            }

            //Draws everything else :|
            switch (state)
            {
                //Default Screen
                case nightState.Default:
                    break;

                //Kit Screen
                case nightState.Kit:
                    PlayerData.Instance.playerIngredients.Draw(spriteBatch, new Vector2(325, 170), 7, 7);
                    PlayerData.Instance.playerPotions.Draw(spriteBatch, new Vector2(325, 705), 7, 3);
                    craftingTable.Draw(spriteBatch, new Vector2(1160, 375), 2, 2);
                    craftingOutput.Draw(spriteBatch, new Vector2(1200, 775), 1, 1);

                    for (int i = 0; i < craftingTable.inventoryData.Count(); i++)
                    {

                        spriteBatch.DrawString
                            (text,
                            craftingTable.inventoryData[i].Name,
                            new Vector2(
                                1322, 365 + 41 * i),
                            Color.Black
                            );
                    }

                    break;

                //Inventory Screen
                case nightState.Inventory:
                    PlayerData.Instance.playerIngredients.Draw(spriteBatch, new Vector2(330, 165), 7, 7);
                    PlayerData.Instance.playerPotions.Draw(spriteBatch, new Vector2(330, 700), 7, 3);

                    GameItems.BaseIngredient temp = PlayerData.Instance.playerIngredients.Update(Mouse.GetState());
                    if (temp != null)
                    {
                        temp.Draw(new Vector2(400, 0), spriteBatch);
                    }

                    if (displayingItem != null)
                    {
                        displayingItem.DrawInfo(spriteBatch, new Rectangle(1015, 100, 500, 650), text);
                    }

                    break;

                //Ingredient Purchace Screen
                case nightState.IngrediantShop:
                    PlayerData.Instance.playerIngredients.Draw(spriteBatch, new Vector2(315, 165), 7, 10);
                    itemStore.Draw(spriteBatch, new Vector2(1005, 195), 7, 2);

                    if (displayingItem != null)
                    {
                        displayingItem.DrawInfoReduced(spriteBatch, new Rectangle(1015, 370, 500, 650), text);
                    }

                    spriteBatch.DrawString(text, "Player Gold " + PlayerData.Instance.gold.ToString(), new Vector2(1130, 750), Color.Black);
                    break;

                //Recipe Book Screen
                case nightState.Recipes:
                    PlayerData.Instance.playerKnownRecipies.Draw(spriteBatch, new Vector2(305, 165), 7, 10);

                    if (displayingItem != null)
                    {
                        ((GameItems.BasePotion)displayingItem).DrawRecipeInfo(spriteBatch, new Rectangle(1015, 100, 500, 650), text);
                    }
                    break;

                //Recipe Shop Screen
                case nightState.RecipeShop:
                    PlayerData.Instance.playerKnownRecipies.Draw(spriteBatch, new Vector2(315, 165), 7, 10);
                    recipeStore.Draw(spriteBatch, new Vector2(1005, 265), 5, 1);
                    
                    if(displayingItem != null)
                    {
                        displayingItem.DrawInfo(spriteBatch, new Rectangle(1015, 370, 500, 650), text);
                    }

                    break;
            }
        }
    }
}
