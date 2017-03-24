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
    enum GlobalGameState
    {
        MainMenu,
        Playing,
        Fullscreen,
        Exit,

    }
    class MainMenu
    {
        //make the buttons for menu
        Button playit;
        Button fS;
        Button exit;
        Rectangle screenPos;
        Texture2D screen;
        KeyboardState kbs;
        //set the initial game screen size
        int screenWidth = 1280;
        int screenHeight = 800;


        GlobalGameState CurrentGameState = GlobalGameState.MainMenu;

        protected void Initialize()
        {
            // TODO: Add your initialization logic here
            //set the prefered window size to the values (Can be changed
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            //be ablle to change the desired screen size
            screenPos = new Rectangle(0, 0, screenWidth, screenHeight);

            graphics.ApplyChanges();
            base.Initialize();
        }
        protected void LoadContent(ContentManager Content)
        {
            //Load the Temp Buttons
            playit = new Button(Content.Load<Texture2D>("TempButton"), graphics.GraphicsDevice);
            playit.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
            fS = new Button(Content.Load<Texture2D>("TempButton"), graphics.GraphicsDevice);
            fS.setPos(new Vector2(screenWidth / 2, screenHeight / 2 + 50));
            exit = new Button(Content.Load<Texture2D>("TempButton"), graphics.GraphicsDevice);
            exit.setPos(new Vector2(screenWidth / 2, screenHeight / 2 + 100));
            screen = Content.Load<Texture2D>("TempMenu");
        }
        void UpdateScreen(int width, int height)
        {
            //sets the new size using update
            screenWidth = width;
            screenHeight = height;
            graphics.ApplyChanges();

            Initialize();
        }

        protected void Update(GameTime gameTime)
        {
            MouseState mouse = Mouse.GetState();
            KeyboardState newKeyState = Keyboard.GetState();
            if (kbs != null)
            {
                kbs = newKeyState;
            }

            switch (CurrentGameState)
            {
                case GlobalGameState.MainMenu:

                    playit.Update(mouse);
                    fS.Update(mouse);
                    exit.Update(mouse);
                    //if clicked goto playing screen
                    if (playit.isClicked == true)
                    {
                        CurrentGameState = GlobalGameState.Playing;
                    }
                    if (fS.isClicked == true)
                    {
                        //if the screen is FullScreen reverse Change
                        if (graphics.IsFullScreen == true)
                        {
                            graphics.IsFullScreen = false;
                            UpdateScreen(1280, 800);
                        }//if windowed make full screen
                        else
                        {
                            graphics.IsFullScreen = true;
                            UpdateScreen(1920, 1080);
                        }

                    }
                    if (exit.isClicked == true)
                    {
                        Exit();
                    }
                    break;
                case GlobalGameState.Playing:
                    if (kbs.IsKeyDown(Keys.Back))
                    {
                        CurrentGameState = GlobalGameState.MainMenu;

                    }
                    break;
                default:
                    break;
            }
        }
        protected void Draw(SpriteBatch spriteBatch)
        {

            switch (CurrentGameState)
            {
                case GlobalGameState.MainMenu:
                    spriteBatch.Draw(screen, screenPos, Color.White);
                    playit.Draw(spriteBatch);
                    fS.Draw(spriteBatch);
                    exit.Draw(spriteBatch);
                    break;
                case GlobalGameState.Playing:
                    break;
                default:
                    break;
            }
        }

    }
}
}
