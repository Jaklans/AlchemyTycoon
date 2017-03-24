using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace AlchemyTycoon
{
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
        protected void LoadContent(ContentManager content, GraphicsDeviceManager graphics)
        {
            //Load in the screens
            defaultScreen = content.Load<Texture2D>("backroom");
            inventoryScreen = content.Load<Texture2D>("ingredients");
            kitScreen = content.Load<Texture2D>("kit");
            recipeScreen = content.Load<Texture2D>("recipebook");

            //Load in text
            text = content.Load<SpriteFont>("Tahoma_40.xnb");

            //Load in the buttons for each screen
            //Default screen
            inventoryButton = new Button(content.Load<Texture2D>("invButton"), graphics.GraphicsDevice);
            inventoryButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
            kitButton = new Button(content.Load<Texture2D>("kitButton"), graphics.GraphicsDevice);
            kitButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
            recipeBookButton = new Button(content.Load<Texture2D>("rbButton"), graphics.GraphicsDevice);
            recipeBookButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));

            //Kit screen
            makeButton = new Button(content.Load<Texture2D>("makeButton"), graphics.GraphicsDevice);
            makeButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
            clearButton = new Button(content.Load<Texture2D>("clearButton"), graphics.GraphicsDevice);
            clearButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));

            //Recipe book screen
            recipesButton = new Button(content.Load<Texture2D>("recipesButton"), graphics.GraphicsDevice);
            recipesButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
            guideButton = new Button(content.Load<Texture2D>("guideButton"), graphics.GraphicsDevice);
            guideButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
            availableButton = new Button(content.Load<Texture2D>("availButton"), graphics.GraphicsDevice);
            availableButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
            yourRecipeButton = new Button(content.Load<Texture2D>("yourButton"), graphics.GraphicsDevice);
            yourRecipeButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));

            //Inventory/Ingredient screen
            storeButton = new Button(content.Load<Texture2D>("storeButton"), graphics.GraphicsDevice);
            storeButton.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
            guide2Button = new Button(content.Load<Texture2D>("guide2Button"), graphics.GraphicsDevice);
            guide2Button.setPos(new Vector2(screenWidth / 2, screenHeight / 2));

        }

        //Update method
        protected void Update(GameTime gameTime)
        {
            //Get the mouse position
            MouseState mouse = Mouse.GetState();

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
        protected void Draw(SpriteBatch spriteBatch)
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

        }
    }
}