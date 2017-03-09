using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlchemyTycoon
{
    public class Night
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D img { get; set; }
        Rectangle imgRec { get; set; }

        string imgFileName { get; set; }
        KeyboardState kbs { get; set; }
        //public Night()
        //{
        //    graphics = new GraphicsDeviceManager(this);
        //    Cont
        //}
        public Night(Texture2D image, Rectangle imageRec)
        {
            img = image;
            imgRec = imageRec;
        }
        public Night(string imageFileName)
        {
            imgFileName = imageFileName;
        }
        public Night(KeyboardState kbState)
        {
            kbState = kbs;
        }

        //protected void LoadContent()
        //{
        //    spriteBatch = new SpriteBatch(GraphicsDevice);
        //
        //    // Load the single spritesheet
        //    spriteSheet = Content.Load<Texture2D>(imgFileName);
        //}
        //
        protected void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(img, imgRec, Color.White);
            spriteBatch.DrawString(SpriteFont,"",0,Color)

            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
