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
        protected Inventory<GameItems.BaseIngredient> testInventory = new Inventory<GameItems.BaseIngredient>();
        protected Data testData = new Data("../../../../itemfolder");

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
            testInventory.AddItem(testData.Ingrediants(005));
            testInventory.AddItem(testData.Ingrediants(001));
            testInventory.AddItem(testData.Ingrediants(002));
            testInventory.AddItem(testData.Ingrediants(003));
            testInventory.AddItem(testData.Ingrediants(004));
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

                    testInventory.Update(ms);

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

                    testInventory.Draw(spriteBatch, new Vector2(40, 40), 3, 4);

                    break;
                default:
                    break;
            }

        }

    }
}
