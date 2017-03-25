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

        Data testData;
        Inventory<GameItems.BaseIngredient> testInventory;
        
        KeyboardState kbs;
        //set the initial game screen size
        int screenWidth = 1280;
        int screenHeight = 800;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        //Create the Objects
        GameStates.MainMenu mM = new GameStates.MainMenu();
        GameManager gM = new GameManager();

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //call the initialize from content

            // TODO: Add your initialization logic here
            //set the prefered window size to the values (Can be changed
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            
            graphics.ApplyChanges();


            //TestEnvironment
            testInventory = new Inventory<GameItems.BaseIngredient>();
            testData = new Data("../../../../itemfolder");

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
            gM.Load(Content, graphics);

            //TestEnvironment
            testData.LoadContent(Content, "../../../../itemfolder/Textures");

            IsMouseVisible = true;
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

            //start calling from game manager
            gM.Update(gameTime, graphics, screenWidth, screenHeight);

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

            gM.Draw(spriteBatch);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
