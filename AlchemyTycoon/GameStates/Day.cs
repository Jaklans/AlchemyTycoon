using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;

namespace AlchemyTycoon.GameStates
{
    class Day
    {
        Texture2D bgScreen;
        Rectangle ScreePos;

        KeyboardState kbState;
        Text gold;
        Text time;
        Text stock;
        Text dialouge;
        Text npcInfo;
        

        protected void LoadContent(ContentManager content)
        {
            //gold = new Text()
            bgScreen = content.Load<Texture2D>("daytime");
        }

        protected void Update()
        {

        }
        protected void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bgScreen, ScreePos, Color.White);
        }

    }
}
