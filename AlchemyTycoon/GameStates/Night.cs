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
        //these will be used to get the variables we need
        Texture2D defaultScreen;
        Rectangle dsRec;
        Texture2D inventoryScreen;
        Rectangle invRec;
        Texture2D kitScreen;
        Rectangle ksRec;
        Texture2D recipeScreen;
        Rectangle rsRec;

        //Enum for Night's states
        enum nightState
        {
            Default,
            Inventory,
            Kit,
            Recipes
        }

        //Current state
        nightState currentState = nightState.Default;

        //Screen size
        int screenWidth = 1280;
        int screenHeight = 800;

        //get all data for in game text
        string imgFileName;
        SpriteFont nightFont;
        string nightText;
        Vector2 nighTextLocation;
        Color nightTextColor;

        //LoadContent method
        protected void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures
            
            switch(currentState)
            {
                case nightState.Default:
                    break;
                case nightState.Inventory:
                    break;
                case nightState.Kit:
                    break;
                case nightState.Recipes:
                    break;
                default:
                    break;
            }
        }

        protected void Draw(SpriteBatch spriteBatch)
        {
            // TODO: Add your drawing code here
            
            //spriteBatch.Draw(img, imgRec, Color.White);
            //spriteBatch.DrawString(nightFont, nightText, nighTextLocation, nightTextColor);

            switch(currentState)
            {
                case nightState.Default:
                    spriteBatch.Draw(defaultScreen, dsRec, Color.White);
                    break;
                case nightState.Inventory:
                    spriteBatch.Draw(inventoryScreen, invRec, Color.White);
                    break;
                case nightState.Kit:
                    spriteBatch.Draw(kitScreen, ksRec, Color.White);
                    break;
                case nightState.Recipes:
                    spriteBatch.Draw(recipeScreen, rsRec, Color.White);
                    break;
                default:
                    break;
            }

        }
    }
}
