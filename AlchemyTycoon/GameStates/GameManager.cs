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

        GameStates.Day day = new GameStates.Day();
        NewNight night = new NewNight();

        PlayingEnum current = PlayingEnum.Night;

        public void Load(ContentManager Content, GraphicsDeviceManager graphics)
        {
            night.LoadContent(Content);
            day.LoadContent(Content, graphics.GraphicsDevice);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, int screenWidth, int screenHeight)
        {
            MouseState ms = Mouse.GetState();
            
            MouseState refinedMS = new MouseState(
                (int)((ms.X / 1700f) * 1920f),
                (int)((ms.Y / 928f) * 1080f), 
                ms.ScrollWheelValue, ms.LeftButton,
                ms.MiddleButton, ms.RightButton, 
                ms.XButton1, ms.XButton2);

            switch (current)
            {
                case PlayingEnum.Day:
                    day.Update();
                    if (day.finished) { current = PlayingEnum.Night; night.Clear(); }
                    break;
                case PlayingEnum.Night:
                    night.Update(refinedMS);
                    if (night.done) { current = PlayingEnum.Day; day.Reset(); }
                    break;
                default:
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            MouseState mouse = Mouse.GetState();
            switch (current)
            {
                case PlayingEnum.Day:
                    day.Draw(spriteBatch);
                    break;
                case PlayingEnum.Night:
                    night.Draw(spriteBatch);
                    break;
                default:
                    break;
            }

        }

    }
}
