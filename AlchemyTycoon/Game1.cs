using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlchemyTycoon
{
    enum GlobalGameState
    {
        MainMenu,
        Playing,
        Fullscreen,
        Exit,
    }
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle screenPos;
        Texture2D screen;


        KeyboardState kbs;

        GlobalGameState CurrentGameState = GlobalGameState.MainMenu;
        //set the initial game screen size
        int screenWidth = 1280;
        int screenHeight = 800;
        //make the buttons for menu
        Button playit;
        Button fS;
        Button exit;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
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

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //will set out initial game screen size

            IsMouseVisible = true;
            //Load the Temp Buttons
            playit = new Button(Content.Load<Texture2D>("TempButton"), graphics.GraphicsDevice);
            playit.setPos(new Vector2(screenWidth / 2, screenHeight / 2));
            fS = new Button(Content.Load<Texture2D>("TempButton"), graphics.GraphicsDevice);
            fS.setPos(new Vector2(screenWidth / 2, screenHeight / 2 + 50));
            exit = new Button(Content.Load<Texture2D>("TempButton"), graphics.GraphicsDevice);
            exit.setPos(new Vector2(screenWidth / 2, screenHeight / 2 + 100));
            screen = Content.Load<Texture2D>("TempMenu");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 

        //used to change the screen size
        void UpdateScreen(int width, int height)
        {
            //sets the new size using update
            screenWidth = width;
            screenHeight = height;
            graphics.ApplyChanges();

            Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //gets mouse position
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


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();


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

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
