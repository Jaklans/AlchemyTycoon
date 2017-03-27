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

        GameStates.MainMenu mM = new GameStates.MainMenu();
        GameStates.Day day = new GameStates.Day();
        Night night = new Night();

        //start the game in the NightMenu
        PlayingEnum current = PlayingEnum.TestEnvironment;

        public void Load(ContentManager Content, GraphicsDeviceManager graphics)
        {

            mM.LoadContent(Content, graphics);

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
            testIngredients.AddItem(testData.Ingrediants(004));

            makePotion = new Button(Content.Load<Texture2D>("potionButton"), graphics.GraphicsDevice);
            makePotion.setPos(new Vector2(300, 500));
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
                    mM.Update(gameTime, graphics);

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

                    testIngredients.Draw(spriteBatch, new Vector2(25, 25), 3, 4);
                    testInput.Draw(spriteBatch, new Vector2(25, 500), 2, 2);
                    testOutput.Draw(spriteBatch, new Vector2(500, 500), 2, 2);
                    testPotions.Draw(spriteBatch, new Vector2(500, 25), 3, 4);

                    makePotion.Draw(spriteBatch);

                    break;
                default:
                    break;
            }

        }

    }
}
