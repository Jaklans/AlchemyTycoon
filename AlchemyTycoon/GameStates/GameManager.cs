using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

//Written by Simeon Chang, John Shull, and Sam Sorensen
namespace AlchemyTycoon
{
    class GameManager
    {
        enum PlayingEnum
        {
            Day,
            Night,
            MainMenu,
            TestEnvironment
        }

        //Test Enviro Vars
        public static Data testData = new Data("../../../../itemfolder");
        protected Inventory<GameItems.BaseIngredient> testIngredients = new Inventory<GameItems.BaseIngredient>(testData);
        protected Inventory<GameItems.BasePotion> testPotions = new Inventory<GameItems.BasePotion>(testData);
        protected Inventory<GameItems.BasePotion> testOutput = new Inventory<GameItems.BasePotion>(testData);
        protected Inventory<GameItems.BaseIngredient> testInput = new Inventory<GameItems.BaseIngredient>(testData);
        

        Vector2 potionButton = new Vector2();

        private Button makePotion;
        private Button demoButton;

        Text ingInv;
        Text potInv;
        Text inpInv;
        Text outInv;

        SpriteFont textFont;

        GameStates.MainMenu mM = new GameStates.MainMenu();
        GameStates.Day day = new GameStates.Day();
        Night night = new Night();

        //start the game in the NightMenu
        PlayingEnum current = PlayingEnum.TestEnvironment;

        public void Load(ContentManager Content, GraphicsDeviceManager graphics)
        {

            mM.LoadContent(Content, graphics);
            night.LoadContent(Content, graphics);

            //TestEnvironment
            testData.LoadContent(Content, "../../../../itemfolder/Textures");
            /*testInventory.AddItem(testData.Ingrediants(005));
            testInventory.AddItem(testData.Ingrediants(001));
            testInventory.AddItem(testData.Ingrediants(002));
            testInventory.AddItem(testData.Ingrediants(003));
            testInventory.AddItem(testData.Ingrediants(004));

            testInventory2.AddItem(testData.Ingrediants(003));
            testInventory2.AddItem(testData.Ingrediants(001));
            testInventory2.AddItem(testData.Ingrediants(004));
            testInventory2.AddItem(testData.Ingrediants(003));
            testInventory2.AddItem(testData.Ingrediants(004));

            testInventory3.AddItem(testData.Ingrediants(003));
            testInventory3.AddItem(testData.Ingrediants(001));
            testInventory3.AddItem(testData.Ingrediants(004));
            testInventory3.AddItem(testData.Ingrediants(003));
            testInventory3.AddItem(testData.Ingrediants(004));*/

            testIngredients.AddItem(testData.Ingrediants(005));
            testIngredients.AddItem(testData.Ingrediants(001));
            testIngredients.AddItem(testData.Ingrediants(002));
            testIngredients.AddItem(testData.Ingrediants(003));
            testIngredients.AddItem(Data.Instance.Ingrediants(004));

            makePotion = new Button(Content.Load<Texture2D>("potionButton"), graphics.GraphicsDevice);
            makePotion.setPos(new Vector2(400, 550));

            demoButton = new Button(Content.Load<Texture2D>("demoButton"), graphics.GraphicsDevice);
            demoButton.setPos(new Vector2(1100, 50));

            textFont = Content.Load<SpriteFont>("Tahoma_40");

            ingInv = new Text("This is your ingredient inventory. \nClick on things to add them to the input inventory.", textFont, Color.AntiqueWhite);
            ingInv.setPos(new Vector2(5, 5));

            inpInv = new Text("This is the input inventory. \nAdd everything but the green blob, \nthen press 'make potion' to make a potion.", textFont, Color.AntiqueWhite);
            inpInv.setPos(new Vector2(5, 420));

            outInv = new Text("This is the output inventory, where potions will appear when made.", textFont, Color.AntiqueWhite);
            outInv.setPos(new Vector2(480, 480));

            potInv = new Text("This is the potion inventory, where potions will be stored.", textFont, Color.AntiqueWhite);
            potInv.setPos(new Vector2(480, 5));

            potInv = new Text("This button goes to where the the night class runs. All is very WIP, but basic navigation is covered.", textFont, Color.AntiqueWhite);
            potInv.setPos(new Vector2(500, 5));
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, int screenWidth, int screenHeight)
        {
            MouseState ms = Mouse.GetState();

            switch (current)
            {
                case PlayingEnum.Day:
                    day.Update();
                    break;
                case PlayingEnum.Night:
                    night.Update(gameTime);
                    break;
                case PlayingEnum.MainMenu:
                    mM.Update(gameTime);

                    if (mM.ReturntheState() == GameStates.GlobalGameState.Playing)
                    {
                        current = PlayingEnum.Night;
                    }
                    //mM.UpdateScreen(graphics, screenWidth, screenHeight);
                break;
                case PlayingEnum.TestEnvironment:

                    /*testInventory.Update(ms,testInventory2);
                    testInventory2.Update(ms, testInventory);
                    testInventory3.Update(ms);*/

                    

                    testIngredients.Update(ms, testInput);
                    testInput.Update(ms, testIngredients);
                    testOutput.Update(ms, testPotions);
                    testPotions.Update(ms);

                    makePotion.Update(ms);
                    
                    if(makePotion.isClicked == true)
                    {
                        GameItems.BasePotion thePotion;
                        thePotion = testInput.MakePotion();
                        if(thePotion != null)
                        {
                            testOutput.AddItem(thePotion);
                        }
                        
                    }

                    demoButton.Update(ms);

                    if (demoButton.isClicked)
                    {
                        current = PlayingEnum.Night;
                    }

                    break;
                default:
                    break;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (current)
            {
                case PlayingEnum.Day:
                    day.Draw(spriteBatch);
                    break;
                case PlayingEnum.Night:
                    night.Draw(spriteBatch);
                    break;
                case PlayingEnum.MainMenu:
                    mM.Draw(spriteBatch);

                    break;

                case PlayingEnum.TestEnvironment:

                    /*testInventory.Draw(spriteBatch, new Vector2(40, 40), 3, 4);
                    testInventory2.Draw(spriteBatch, new Vector2(400, 450), 4, 3);
                    testInventory3.Draw(spriteBatch, new Vector2(600, 40), 4, 4);*/

                    testIngredients.Draw(spriteBatch, new Vector2(50, 50), 3, 4);
                    testInput.Draw(spriteBatch, new Vector2(50, 500), 2, 2);
                    testOutput.Draw(spriteBatch, new Vector2(600, 550), 2, 2);
                    testPotions.Draw(spriteBatch, new Vector2(500, 50), 3, 4);

                    makePotion.Draw(spriteBatch);
                    Vector2 theScale2 = new Vector2(0.33f);
                    ingInv.changeFont(spriteBatch, theScale2);
                    outInv.changeFont(spriteBatch, theScale2);
                    potInv.changeFont(spriteBatch, theScale2);
                    inpInv.changeFont(spriteBatch, theScale2);


                    demoButton.Draw(spriteBatch);
                    /*inpInv.Draw(spriteBatch);
                    outInv.Draw(spriteBatch);
                    potInv.Draw(spriteBatch);
                    ingInv.Draw(spriteBatch);*/

                    

                    

                    break;
                default:
                    break;
            }

        }

    }
}
