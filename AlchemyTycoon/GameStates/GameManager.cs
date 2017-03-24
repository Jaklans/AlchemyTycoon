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
            Night
        }

        GameStates.MainMenu mM = new GameStates.MainMenu();
        //start the gae in the NightMenu
        PlayingEnum current = PlayingEnum.Night;

        public void Load(ContentManager Content, GraphicsDeviceManager graphics)
        {

            mM.LoadContent(Content, graphics);
        }

        public void Update(GameTime gameTime, GraphicsDeviceManager graphics, int screenWidth, int screenHeight)
        {

            mM.Update(gameTime, graphics);

            mM.UpdateScreen(graphics, screenWidth, screenHeight);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            mM.Draw(spriteBatch);

        }

    }
}
