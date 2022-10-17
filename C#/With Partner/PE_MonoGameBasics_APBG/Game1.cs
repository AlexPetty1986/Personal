using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_MonoGameBasics_APBG
{

    //enum to track GameStates
    enum GameState
    {
        MainMenu,
        Bounce,
        User
    }

    public class Game1 : Game
    {
        //variables
        private GraphicsDeviceManager graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D ret;

        //Monogame basics variables
        private Vector2 retPosition;
        private Vector2 retVelocity;
        private Rectangle smol;

        //Monogame Input & Text variables
        private KeyboardState prevKBState;
        private int smallRatSpeed;
        private SpriteFont labelFont;
        private SpriteFont bounceFont;
        private int ballBounces;
        private MouseState prevMouseState;

        //Monogame GameState FSM variables
        GameState currentState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            //ret position
            retPosition = new Vector2(5,5);

            //speed at which ret moves around screen (0.5f was unbearably slow)
            retVelocity = new Vector2(2, 2);

            //MonoGame Input and Text initializations
            prevKBState = Keyboard.GetState();
            smallRatSpeed = 1;
            prevMouseState = Mouse.GetState();

            //MonoGame GameState FSM initializations
            currentState = GameState.MainMenu;

            //screen bounds
            graphics.PreferredBackBufferWidth = 600;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            ballBounces = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //load the rat
            ret = this.Content.Load<Texture2D>("ret");

            //rectangle object for smaller blue rat
            smol = new Rectangle(GraphicsDevice.Viewport.Width/2 - ret.Width/4, 
                                GraphicsDevice.Viewport.Height/2 - ret.Height/4,
                                ret.Width/2, ret.Height/2);

            //Monogame Input and Text loads
            labelFont = Content.Load<SpriteFont>("LabelFont");
            bounceFont = Content.Load<SpriteFont>("BounceFont");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // Get the current device states
            KeyboardState kbState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            // Figure out which helper methods to call based on the current state
            // (these will change the current state if needed)
            switch (currentState)
            {
                case GameState.MainMenu:
                    ProcessMainMenu(kbState);
                    break;

                case GameState.Bounce:
                    ProcessBounceMode(kbState, mState);
                    break;

                case GameState.User:
                    ProcessUserMode(kbState, mState);
                    break;

                default:
                    break;

            }

            // Update our saved device state
            prevMouseState = mState;
            prevKBState = kbState;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Maroon);

            // Begin the Sprite Batch
            _spriteBatch.Begin();

            //currentState Switch FSM
            switch (currentState)
            {
                //Main Menu State
                case GameState.MainMenu:

                    //Draw the welcome message
                    _spriteBatch.DrawString(bounceFont, "Welcome to Group 19's MonoGame Demo!", new Vector2(0, 500), Color.Cyan);

                    //draw instructions
                    _spriteBatch.DrawString(bounceFont, "Press B to see some bouncing", new Vector2(0, 530), Color.Cyan);
                    _spriteBatch.DrawString(bounceFont, "Press U to control the image yourself", new Vector2(0, 560), Color.Cyan);
                    break;

                //Bounce State
                case GameState.Bounce:

                    //draw the image that will bounce
                    _spriteBatch.Draw(ret, retPosition, Color.White);

                    //draw the counter that will keep track of # of bounces
                    _spriteBatch.DrawString(bounceFont, "Bounces: " + ballBounces, new Vector2(300, 300), Color.Cyan);

                    //draw instructions
                    _spriteBatch.DrawString(bounceFont, "Press M to return to main menu", new Vector2(0, 500), Color.Cyan);
                    _spriteBatch.DrawString(bounceFont, "Click Right Mouse Button to reset", new Vector2(0, 530), Color.Cyan);
                    break;

                //User Input State
                case GameState.User:

                    //draw smaller rat in the center of screen that will be controlled
                    _spriteBatch.Draw(ret, smol, Color.Cyan);

                    //Draw name, the image speed, and the image position
                    _spriteBatch.DrawString(labelFont, "Applebees: " + smallRatSpeed + "(" + smol.X + "," + smol.Y + ")"
                                            , new Vector2(15, 15), Color.Cyan);

                    //instructions
                    _spriteBatch.DrawString(bounceFont, "Press M to return to main menu", new Vector2(0, 500), Color.Cyan);
                    _spriteBatch.DrawString(bounceFont, "Click Right Mouse Button to reset", new Vector2(0, 530), Color.Cyan);
                    break;
            }
            // End the Sprite Batch
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        //check for the press of a specific key
        private bool SingleKeyPress(Keys key, KeyboardState currentKbState)
        {
            if (currentKbState.IsKeyUp(key) && prevKBState.IsKeyDown(key))
            {
                prevKBState = currentKbState;
                return true;
            }
            else
            {
                return false;
            }
        }

        //method to process input for the MainMenu state
        private void ProcessMainMenu(KeyboardState kbState)
        {
            //switch to Bounce state with B
            if (SingleKeyPress(Keys.B, kbState))
            {
                currentState = GameState.Bounce;
            }

            //switch to User Control state with U
            if (SingleKeyPress(Keys.U, kbState))
            {
                currentState = GameState.User;
            }
        }

        //method to process input for the Bounce state
        private void ProcessBounceMode(KeyboardState kbState, MouseState mState)
        {
            //ret's position is incremented by the velocity
            retPosition += retVelocity;

            //if ret goes too far left/right.
            if (retPosition.X <= GraphicsDevice.Viewport.X || retPosition.X >= GraphicsDevice.Viewport.Width - ret.Width)
            {
                //invert horizontal velocity
                retVelocity.X *= -1;

                ballBounces += 1;
            }

            //if ret goes too far up/down.
            if (retPosition.Y <= GraphicsDevice.Viewport.Y || retPosition.Y >= GraphicsDevice.Viewport.Height - ret.Height)
            {
                //invert vertical velocity
                retVelocity.Y *= -1;

                ballBounces += 1;
            }

            //switch to Main Menu state with M
            if (SingleKeyPress(Keys.M, kbState))
            {
                currentState = GameState.MainMenu;
            }

            //reset state
            if (mState.RightButton == ButtonState.Released && prevMouseState.RightButton == ButtonState.Pressed)
            {
                //reset bouncy rat position
                retPosition = new Vector2(5, 5);

                //reset bounce counter
                ballBounces = 0;
            }
            prevMouseState = mState;
        }

        //method to process input for the User state
        private void ProcessUserMode(KeyboardState kbState, MouseState mState)
        {
            //press w to go up
            if (kbState.IsKeyDown(Keys.W))
            {
                smol.Y -= smallRatSpeed;
            }

            //press s to go down
            if (kbState.IsKeyDown(Keys.S))
            {
                smol.Y += smallRatSpeed;
            }

            //press a to go left
            if (kbState.IsKeyDown(Keys.A))
            {
                smol.X -= smallRatSpeed;
            }

            //press d to go right
            if (kbState.IsKeyDown(Keys.D))
            {
                smol.X += smallRatSpeed;
            }

            //increment image velocity
            if (SingleKeyPress(Keys.Space, kbState))
            {
                smallRatSpeed += 1;
            }

            //switch to Main Menu state with M
            if (SingleKeyPress(Keys.M, kbState))
            {
                currentState = GameState.MainMenu;
            }   

            //reset state
            if (mState.RightButton == ButtonState.Released && prevMouseState.RightButton == ButtonState.Pressed)
            {

                //reset small rat position
                smol = new Rectangle(GraphicsDevice.Viewport.Width / 2 - ret.Width / 4,
                                    GraphicsDevice.Viewport.Height / 2 - ret.Height / 4,
                                    ret.Width / 2, ret.Height / 2);

                //reset small rat speed
                smallRatSpeed = 1;
            }
            prevMouseState = mState;
        }
    }
}
