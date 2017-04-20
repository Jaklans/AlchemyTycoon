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

        private DrawableObject defaultScreen;
        private DrawableObject inventoryScreen;
        private DrawableObject kitScreen;
        private DrawableObject recipeScreen;
        private DrawableObject ingrediantShop;
        private DrawableObject recipeShop;

        //Buttons on all non default screens
        newButton backButton;

        //Buttons on default screen
        newButton inventoryButton;
        newButton kitButton;
        newButton recipeButton;

        //Buttons on kit screen
        newButton makeButton;
        newButton clearButton;

        //Buttons on recipe book screen
        newButton recipeShopButton;

        //Buttons on recipe purchace screen
        newButton recipePurchace;

        //Buttons on ingredients screen
        newButton storeButton;

        //Buttons on ingredient purchace screen
        newButton ingredientPurchace;


        int screenWidth = 1280;
        int screenHeight = 800;

        private SpriteFont text;

        //Allows to itterate through and draw everything from a set group
        private Dictionary<nightState, List<DrawableObject>> drawlables;



        public void LoadContent(ContentManager content)
        {
            //Back Button
            backButton = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));


            //Default Screen
            defaultScreen = new DrawableObject(
                content.Load<Texture2D>(""), 
                new Rectangle(0, 0, screenWidth, screenHeight));
            inventoryButton = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));
            kitButton = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));
            recipeButton = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));

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
                content.Load<Texture2D>(""), 
                new Rectangle(0, 0, screenWidth, screenHeight));
            makeButton = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));
            clearButton = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));

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
                content.Load<Texture2D>(""),
                new Rectangle(0, 0, screenWidth, screenHeight));
            recipeShopButton = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));

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
                content.Load<Texture2D>(""),
                new Rectangle(0, 0, screenWidth, screenHeight));
            recipePurchace = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));

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
                content.Load<Texture2D>(""),
                new Rectangle(0, 0, screenWidth, screenHeight));
            storeButton = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));

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
                content.Load<Texture2D>(""),
                new Rectangle(0, 0, screenWidth, screenHeight));
            ingredientPurchace = new newButton(
                content.Load<Texture2D>(""),
                content.Load<Texture2D>(""));

            drawlables.Add(
                nightState.IngrediantShop,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    ingrediantShop,
                    ingredientPurchace,
                    backButton
                });




            //Ingrediant Shop Screen


            ////Buttons on recipe book screen
            //newButton recipeShopButton;
            //
            ////Buttons on recipe purchace screen
            //newButton recipePurchace;
            //
            ////Buttons on ingredients screen
            //newButton storeButton;
            //
            ////Buttons on ingredient purchace screen
            //newButton ingredientPurchace;


            inventoryScreen = new DrawableObject(
                content.Load<Texture2D>(""), 
                new Rectangle(0, 0, screenWidth, screenHeight));

            

            recipeScreen = new DrawableObject(
                content.Load<Texture2D>(""),
                new Rectangle(0, 0, screenWidth, screenHeight));

            ingrediantShop = new DrawableObject(
                content.Load<Texture2D>(""),
                new Rectangle(0, 0, screenWidth, screenHeight));

            recipeShop = new DrawableObject(
                content.Load<Texture2D>(""), 
                new Rectangle(0, 0, screenWidth, screenHeight));

            //Default Objects
            drawlables.Add(nightState.Default,
                new List<DrawableObject>()
                {
                    defaultScreen,
                    new newButton(content.Load<Texture2D>(""), content.Load<Texture2D>(""))
                }
                );
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