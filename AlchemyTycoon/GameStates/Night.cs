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
            GameItems.BaseIngredient displayIngredient;
            GameItems.BasePotion displayPotion;
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

            drawlables = new Dictionary<nightState, List<DrawableObject>>();

            rng = new Random();

            craftingTable = new Inventory<GameItems.BaseIngredient>();
            craftingOutput = new Inventory<GameItems.BasePotion>();

            itemStore = new Inventory<GameItems.BaseIngredient>();
            recipeStore = new Inventory<GameItems.BasePotion>();

            for(int i = 0; i < 10; i++)
            {
                itemStore.AddItem(Data.Instance.RandomIngredient);
            }
            for (int i = 0; i < 5; i++)
            {
                recipeStore.AddItem(Data.Instance.RandomPotion);
            }
        }

        public void LoadContent(ContentManager content)
        {
            //Back Button
            backButton = new newButton(
                content.Load<Texture2D>("TempButton.jpg"),
                content.Load<Texture2D>("TempButton.jpg"));


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

            drawlables.Add(
                nightState.Default,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    inventoryButton,
                    kitButton,
                    recipeButton
                });


            //Kit Screen
            kitScreen = new DrawableObject(
                content.Load<Texture2D>("Screens/kitScreen"), 
                new Rectangle(0, 0, screenWidth, screenHeight));
            makeButton = new newButton(
                content.Load<Texture2D>("Buttons/makeButton"),
                content.Load<Texture2D>("Buttons/makeButtonHL"));
            clearButton = new newButton(
                content.Load<Texture2D>("Buttons/clearButton"),
                content.Load<Texture2D>("Buttons/clearButtonHL"));

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
                new Rectangle(0, 0, screenWidth, screenHeight));
            recipeShopButton = new newButton(
                content.Load<Texture2D>("Buttons/shop"),
                content.Load<Texture2D>("Buttons/shopHL"));

            drawlables.Add(
                nightState.Recipes,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    recipeScreen,
                    recipeShopButton,
                    backButton
                } );


            //Recipe Shop Screen
            recipeShop = new DrawableObject(
                content.Load<Texture2D>("Screens/recipeShop"),
                new Rectangle(0, 0, screenWidth, screenHeight));
            recipePurchace = new newButton(
                content.Load<Texture2D>("Buttons/shop"),
                content.Load<Texture2D>("Buttons/shopHL"));

            drawlables.Add(
                nightState.RecipeShop,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    recipeScreen,
                    recipeShop,
                    recipePurchace,
                    backButton
                } );


            //Inventory Screen
            inventoryScreen = new DrawableObject(
                content.Load<Texture2D>("Screens/inventoryScreen"),
                new Rectangle(0, 0, screenWidth, screenHeight));
            storeButton = new newButton(
                content.Load<Texture2D>("Buttons/shop"),
                content.Load<Texture2D>("Buttons/shopHL"));

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
                new Rectangle(0, 0, screenWidth, screenHeight));
            ingredientPurchace = new newButton(
                content.Load<Texture2D>("Buttons/purchase"),
                content.Load<Texture2D>("Buttons/purchaseHL"));

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
        }

        public void Update(MouseState mouse)
        {
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
                    else if ( recipeButton.Clicked) { state = nightState.Recipes; } 
                    
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
                        while(craftingTable.inventoryData.Count != 0)
                        {
                            PlayerData.Instance.
                                playerIngredients.AddItem(
                                craftingTable.RemoveItem(0)
                                );
                        }
                        while(craftingOutput.inventoryData.Count != 0)
                        {
                            PlayerData.Instance.
                                playerPotions.AddItem(
                                craftingOutput.RemoveItem(0)
                                );
                        }
                    }

                    if (makeButton.Clicked && craftingOutput.inventoryData.Count != 0)
                    {
                        GameItems.BasePotion temp = craftingTable.MakePotion();
                        if(temp != null)
                        {
                            craftingOutput.AddItem(temp);
                        }
                        else
                        {
                            //Should add a junk potion, need sam to write that in
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

                    if (backButton.Clicked) { state = nightState.Default; }

                    //Inventories
                    GameItems.BaseIngredient tempIngredient = PlayerData.Instance.playerIngredients.Update(mouse);
                    GameItems.BasePotion tempPotion =  PlayerData.Instance.playerPotions.Update(mouse);

                    //Logic to determine which gameItem should be displayed, potion or ingredient
                    if(tempIngredient != displayIngredient)
                    {
                        displayIngredient = tempIngredient;
                        displayingItem = tempIngredient;
                    }
                    else if(tempPotion != displayPotion)
                    {
                        displayPotion = tempPotion;
                        displayingItem = tempPotion;
                    }

                    break;

                //Inventory Purchace Screen
                case nightState.IngrediantShop:
                    //Buttons
                    backButton.Update(mouse);
                    ingredientPurchace.Update(mouse);

                    if (backButton.Clicked) { state = nightState.Inventory; }

                    //Inventories
                    GameItems.BaseIngredient selectedItem = itemStore.Update(mouse);
                    if (ingredientPurchace.Clicked && selectedItem != null && PlayerData.Instance.gold >= selectedItem.Value)
                    {
                        PlayerData.Instance.playerIngredients.AddItem(
                            itemStore.RemoveItem(selectedItem));
                        PlayerData.Instance.gold -= selectedItem.Value;
                    }

                    break;

                //Recipe Book Screen
                case nightState.Recipes:
                    backButton.Update(mouse);
                    recipeShopButton.Update(mouse);

                    if (backButton.Clicked) { state = nightState.Default; }
                    if (recipeShopButton.Clicked) { state = nightState.RecipeShop; }
                    
//! Find way to display recipies

                    break;
                    
                //Recipe Purchace Screen
                case nightState.RecipeShop:
                    backButton.Update(mouse);
                    recipePurchace.Update(mouse);

                    if (backButton.Clicked) { state = nightState.Recipes; }

                    break;

                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draws all basic objects for each gamestate (buttons and backgrounds)
            foreach(DrawableObject drawlable in drawlables[state])
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
                    PlayerData.Instance.playerIngredients.Draw(spriteBatch, new Vector2(0, 0), 5, 7);
                    PlayerData.Instance.playerPotions.Draw(spriteBatch, new Vector2(0, 500), 5, 3);
                    craftingTable.Draw(spriteBatch, new Vector2(500, 0), 2, 2);
                    craftingOutput.Draw(spriteBatch, new Vector2(500, 250), 1, 1);
                    break;

                //Inventory Screen
                case nightState.Inventory:
                    PlayerData.Instance.playerIngredients.Draw(spriteBatch, new Vector2(0, 0), 5, 7);
                    PlayerData.Instance.playerPotions.Draw(spriteBatch, new Vector2(0, 500), 5, 3);
//! Draw item info
                    break;

                //Ingredient Purchace Screen
                case nightState.IngrediantShop:
                    PlayerData.Instance.playerIngredients.Draw(spriteBatch, new Vector2(0, 0), 5, 10);
                    itemStore.Draw(spriteBatch, new Vector2(500, 0), 5, 2);
//! Draw item info
                    break;

                //Recipe Book Screen
                case nightState.Recipes:
                    PlayerData.Instance.playerKnownRecipies.Draw(spriteBatch, new Vector2(0, 0), 5, 10);
//! Draw recipe info
                    break;

                //Recipe Shop Screen
                case nightState.RecipeShop:
                    PlayerData.Instance.playerKnownRecipies.Draw(spriteBatch, new Vector2(0, 0), 5, 10);
                    recipeStore.Draw(spriteBatch, new Vector2(500, 0), 5, 1);
//! Draw recipe info
                    break;
            }
        }
    }
    public class Night
    {
        //Background images
        Texture2D defaultScreen;
        Rectangle dsRec;
        Texture2D inventoryScreen;
        Rectangle invRec;
        Texture2D kitScreen;
        Rectangle ksRec;
        Texture2D recipeScreen;
        Rectangle rsRec;

        //Text
        SpriteFont text;

        //Buttons on all screens
        Button backButton;

        //Buttons on default/after hours menu screen
        Button inventoryButton;
        Button kitButton;
        Button recipeBookButton;

        //Buttons on kit screen
        Button makeButton;
        Button clearButton;

        //Buttons on recipe book screen
        Button recipesButton;
        Button guideButton;
        Button availableButton;
        Button yourRecipeButton;

        //Buttons on inventory/ingredients screen
        Button storeButton;
        Button guide2Button;

        //Set the initial game screen size
        int screenWidth = 1280;
        int screenHeight = 800;

        //Enum for Night's states
        enum nightState
        {
            Default,
            Inventory,
            Kit,
            Recipes
        }

        //Current state
        nightState currentState = nightState.Default;

        //LoadContent method
        public void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            //Load in the screens
            defaultScreen = content.Load<Texture2D>("backroom");
            dsRec = new Rectangle(0, 0, screenWidth, screenHeight);
            inventoryScreen = content.Load<Texture2D>("ingredients");
            invRec = new Rectangle(0, 0, screenWidth, screenHeight);//Wont be real position change  the size and position
            kitScreen = content.Load<Texture2D>("kit");
            ksRec = new Rectangle(0, 0, screenWidth, screenHeight); ;//Wont be real position change  the size and position
            recipeScreen = content.Load<Texture2D>("recipebook");
            rsRec = new Rectangle(0, 0, screenWidth, screenHeight); ;//Wont be real position change  the size and position

            //Load in text
            text = content.Load<SpriteFont>("Tahoma_40");

            //Load in the buttons for each screen

            //All screens
            backButton = new Button(content.Load<Texture2D>("backButton"), graphics.GraphicsDevice);
            backButton.setPos(new Vector2(400, 400));

            //Default screen
            inventoryButton = new Button(content.Load<Texture2D>("inventoryButton"), graphics.GraphicsDevice);
            inventoryButton.setPos(new Vector2(0, 0));
            kitButton = new Button(content.Load<Texture2D>("kitButton"), graphics.GraphicsDevice);
            kitButton.setPos(new Vector2(400, 0));
            recipeBookButton = new Button(content.Load<Texture2D>("rbButton"), graphics.GraphicsDevice);
            recipeBookButton.setPos(new Vector2(0, 400));

            //Kit screen
            makeButton = new Button(content.Load<Texture2D>("makeButton"), graphics.GraphicsDevice);
            makeButton.setPos(new Vector2(0, 0));
            clearButton = new Button(content.Load<Texture2D>("clearButton"), graphics.GraphicsDevice);
            clearButton.setPos(new Vector2(400, 0));

            //Recipe book screen
            recipesButton = new Button(content.Load<Texture2D>("recipesButton"), graphics.GraphicsDevice);
            recipesButton.setPos(new Vector2(0, 0));
            guideButton = new Button(content.Load<Texture2D>("guideButton"), graphics.GraphicsDevice);
            guideButton.setPos(new Vector2(400, 0));
            availableButton = new Button(content.Load<Texture2D>("availButton"), graphics.GraphicsDevice);
            availableButton.setPos(new Vector2(0, 400));
            yourRecipeButton = new Button(content.Load<Texture2D>("yourButton"), graphics.GraphicsDevice);
            yourRecipeButton.setPos(new Vector2(400, 400));

            //Inventory/Ingredient screen
            storeButton = new Button(content.Load<Texture2D>("storeButton"), graphics.GraphicsDevice);
            storeButton.setPos(new Vector2(0, 0));
            guide2Button = new Button(content.Load<Texture2D>("guide2Button"), graphics.GraphicsDevice);
            guide2Button.setPos(new Vector2(400, 0));

        }

        //Update method
        public void Update(GameTime gameTime)
        {
            //Get the mouse position
            MouseState mouse = Mouse.GetState();

            //Button to go back to Default State
            backButton.Update(mouse);
            if (backButton.isClicked && currentState != nightState.Default)
            {
                currentState = nightState.Default;
            }

            //Changing the states based on where the player clicks on
            switch (currentState)
            {
                case nightState.Default:
                    inventoryButton.Update(mouse);
                    kitButton.Update(mouse);
                    recipeBookButton.Update(mouse);

                    //When clicked, go to the inventory/ingredients screen
                    if(inventoryButton.isClicked == true)
                    {
                        currentState = nightState.Inventory;
                    }

                    //When clicked, go to the kit screen
                    if(kitButton.isClicked == true)
                    {
                        currentState = nightState.Kit;
                    }

                    //When clicked, go to the recipe book screen
                    if(recipeBookButton.isClicked == true)
                    {
                        currentState = nightState.Recipes;
                    }
                    break;
                case nightState.Inventory:
                    storeButton.Update(mouse);
                    guide2Button.Update(mouse);

                    //When clicked, will take you to the store
                    if(storeButton.isClicked == true)
                    {

                    }

                    //When clicked, will take you to the field guide
                    if(guide2Button.isClicked == true)
                    {

                    }
                    break;
                case nightState.Kit:
                    makeButton.Update(mouse);
                    clearButton.Update(mouse);

                    //When clicked, will allow player to make potions
                    if(makeButton.isClicked == true)
                    {

                    }

                    //When clicked, will clear out the ingredients used to make a potion
                    if(clearButton.isClicked == true)
                    {

                    }
                    break;
                case nightState.Recipes:
                    recipesButton.Update(mouse);
                    guideButton.Update(mouse);
                    availableButton.Update(mouse);
                    yourRecipeButton.Update(mouse);

                    //When clicked, will take player to recipes they can get
                    if(recipesButton.isClicked == true)
                    {

                    }

                    //When clicked, will take player to the field guide
                    if(guideButton.isClicked == true)
                    {

                    }

                    //When clicked, will take player to the recipes that are available to them
                    if(availableButton.isClicked == true)
                    {

                    }

                    //When clicked, will take player to the recipes they have purchased/learned
                    if(yourRecipeButton.isClicked == true)
                    {

                    }
                    break;
                default:
                    break;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Add your drawing code here

            //spriteBatch.Draw(img, imgRec, Color.White);
            //spriteBatch.DrawString(nightFont, nightText, nighTextLocation, nightTextColor);
            


            switch (currentState)
            {
                case nightState.Default:
                    spriteBatch.Draw(defaultScreen, dsRec, Color.White);
                    inventoryButton.Draw(spriteBatch);
                    kitButton.Draw(spriteBatch);
                    recipeBookButton.Draw(spriteBatch);
                    break;
                case nightState.Inventory:
                    spriteBatch.Draw(inventoryScreen, invRec, Color.White);
                    storeButton.Draw(spriteBatch);
                    guide2Button.Draw(spriteBatch);
                    break;
                case nightState.Kit:
                    spriteBatch.Draw(kitScreen, ksRec, Color.White);
                    makeButton.Draw(spriteBatch);
                    clearButton.Draw(spriteBatch);
                    break;
                case nightState.Recipes:
                    spriteBatch.Draw(recipeScreen, rsRec, Color.White);
                    recipesButton.Draw(spriteBatch);
                    guideButton.Draw(spriteBatch);
                    availableButton.Draw(spriteBatch);
                    yourRecipeButton.Draw(spriteBatch);
                    break;
                default:
                    break;


            }
            if (currentState != nightState.Default)
            {
                backButton.Draw(spriteBatch);
            }

        }
    }
}