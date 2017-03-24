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
        //start the gae in the NightMenu
        PlayingEnum current = PlayingEnum.Night;

        public void Load(ContentManager content)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(GameTime gameTime)
        {

        }

    }
}
