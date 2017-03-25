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
            MainMenu
        }

        GameStates.MainMenu mM = new GameStates.MainMenu();
        GameStates.Day day = new GameStates.Day();
        Night night = new Night();

        //start the gae in the NightMenu
        PlayingEnum current = PlayingEnum.MainMenu;

        public void Load(ContentManager Content, GraphicsDeviceManager graphics)
        {

            mM.LoadContent(Content, graphics);
            
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, int screenWidth, int screenHeight)
        {


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
                default:
                    break;
            }

        }

    }
}
