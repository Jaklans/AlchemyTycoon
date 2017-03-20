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
        //these will be used to get the varables we need
        Texture2D img { get; set; }
        Rectangle imgRec { get; set; }

        //get all data for in game text
        string imgFileName { get; set; }
        SpriteFont nightFont { get; set; }
        string nightText { get; set; }
        Vector2 nighTextLocation { get; set; }
        Color nightTextColor { get; set; }
        //KeyboardState kbs { get; set; }
        //public Night()
        //{
        //    graphics = new GraphicsDeviceManager(this);
        //    Cont
        //}

        //then use constructors to take the data from child into this class so that we can use them
        public Night(Texture2D image, Rectangle imageRec)
        {
            img = image;
            imgRec = imageRec;
        }
        public Night(string imageFileName)
        {
            imgFileName = imageFileName;
        }
        public Night(SpriteFont font, string text, Vector2 textlocation, Color tcolor)
        {
            nightFont = font;
            nightText = text;
            nighTextLocation = textlocation;
            nightTextColor = tcolor;
        }
        //public Night(KeyboardState kbState)
        //{
        //    kbState = kbs;
        //}
        //
        //protected void LoadContent()
        //{
        //    spriteBatch = new SpriteBatch(GraphicsDevice);
        //
        //    // Load the single spritesheet
        //    spriteSheet = Content.Load<Texture2D>(imgFileName);
        //}
        //
        protected void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Add your drawing code here
            
            spriteBatch.Draw(img, imgRec, Color.White);
            spriteBatch.DrawString(nightFont, nightText, nighTextLocation, nightTextColor);

        }
    }
}
