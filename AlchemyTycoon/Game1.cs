using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace AlchemyTycoon
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Rectangle screenPos;
        Texture2D screen;

        enum GlobalGameState
        {
            MainMenu,
            Playing,
            Fullscreen,
            Exit,
        }

        GlobalGameState CurrentGameState = GlobalGameState.MainMenu;

        int screenWidth = 1280;
        int screenHeight = 800;
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
            screenPos = new Rectangle(0, 0, screenWidth, screenHeight);
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
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;

            graphics.ApplyChanges();
            IsMouseVisible = true;
            playit = new Button(Content.Load<Texture2D>("TempButton"), graphics.GraphicsDevice);
            playit.setPos(new Vector2(screenWidth, screenHeight));
            fS = new Button(Content.Load<Texture2D>("TempButton"), graphics.GraphicsDevice);
            fS.setPos(new Vector2(screenWidth, screenHeight - 50));
            exit = new Button(Content.Load<Texture2D>("TempButton"), graphics.GraphicsDevice);
            exit.setPos(new Vector2(screenWidth, screenHeight - 100));
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
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //gets mouse position
            MouseState mouse = Mouse.GetState();

            switch (CurrentGameState)
            {
                case GlobalGameState.MainMenu:
                    //if clicked goto playing screen
                    if (playit.isClicked == true)
                    {
                        CurrentGameState = GlobalGameState.Playing;
                    }
                    if (fS.isClicked == true)
                    {
                        screenHeight = GraphicsDevice.Viewport.Height;
                        screenWidth = GraphicsDevice.Viewport.Width;
                    }
                    if (exit.isClicked == true)
                    {
                        Exit();
                    }
                    break;
                case GlobalGameState.Playing:
                    GameManager.
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
