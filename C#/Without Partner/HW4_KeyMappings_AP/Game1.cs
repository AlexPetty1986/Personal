using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HW4_KeyMappings
{
    /// <summary>
    /// This is the main type for your game.
    /// 
    /// ONLY MODIFY WHERE MARKED WITH "TODO"
    /// Use View -> Task List to get a summary of all TODOs in the project
    /// </summary>
    public class Game1 : Game
    {
        // Constants
        private const int WindowSize = 600;

        // MonoGame related fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Track device state across frames
        private KeyboardState prevKBState;

        // Assets
        private SpriteFont titleFont;
        private SpriteFont buttonFont;

        // The snake!
        private Snake snake;

        // The control scheme manager
        private ControlsManager controlsMgr;

        /// <summary>
        /// Create the base game.
        /// </summary>
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Adjust the window size to always have the same proportions based on the window width
            _graphics.PreferredBackBufferWidth = WindowSize;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = WindowSize;   // set this value to the desired height of your window
            _graphics.ApplyChanges();

            snake = new Snake(WindowSize);
            controlsMgr = new ControlsManager();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: Subscribe the snake's SetControls method to the controls manager's OnControlsUpdate event
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //make sure the controls of the snake are subscribed to the controlMgr
            controlsMgr.OnControlsUpdate += snake.SetControls;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the 2 fonts we use.
            buttonFont = Content.Load<SpriteFont>("font");
            titleFont = Content.Load<SpriteFont>("titleFont");
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

            // Always get the current keyboard state
            KeyboardState kbState = Keyboard.GetState();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // TODO: If the snake is alive (i.e. the game is running), tell it to update itself
            // TODO: If not, if Space was pressed AND there's an active control scheme, start playing
            // TODO: Otherwise, tell the controls manager to check for updates
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            //if the snake is alive
            if(snake.IsAlive)
            {
                snake.Update(gameTime);
            }

            //if the snake is not alive, the current control scheme is not null and the space bar is pressed
            else if(kbState.IsKeyDown(Keys.Space) && controlsMgr.CurrentScheme != null && !snake.IsAlive)
            {
                snake.Reset();
            }

            //anything else
            else
            {
                controlsMgr.Update();
            }

            // Save the keyboard state for next time
            prevKBState = kbState;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Remember that you'll need to use ShapeBatch.Begin/End or _spriteBatch.Begin/End
            // appropriately around different types of drawing methods

            // TODO: Always draw the snake in the background
            // TODO: If the snake isn't alive, draw the controls selection buttons (and then their text) & instructions
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            GraphicsDevice.Clear(Color.LightBlue);

            //Begin drawing the snake and buttons
            _spriteBatch.Begin();
                ShapeBatch.Begin(GraphicsDevice);
                    //Always have the snake drawn in the background
                    snake.Draw();

                    //if the snake isn't alive
                    if (!snake.IsAlive)
                    {
                        //draw the buttons and the instructions
                        _spriteBatch.DrawString(titleFont, "Click a button to set the controls!", new Vector2(40, 40), Color.Black);
                        controlsMgr.DrawButtons();
                        controlsMgr.DrawButtonText(_spriteBatch, buttonFont);

                        //if there is currently no button scheme selected
                        if(controlsMgr.CurrentScheme != null)
                        {
                            _spriteBatch.DrawString(titleFont, "Press SPACE to play!", new Vector2(40, 175), Color.Blue);
                        }
                    }
                ShapeBatch.End();
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
