using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace PE_MarioWalking
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The Mario to draw depending on the current state
        private Mario mario;

        // Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
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
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Sets up the mario location
            Vector2 marioLoc = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            // Load the single spritesheet and create a new Mario object
            Texture2D spriteSheet = Content.Load<Texture2D>("Mario");

            mario = new Mario(spriteSheet, marioLoc, MarioState.FaceRight);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Handles animation for you
            mario.UpdateAnimation(gameTime);

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            // PRACTICE EXERCISE: Add your finite state machine code (switch statement) here!
            // - Be sure to check the finite state machine's state first
            // - Then check for specific transitions inside each state (may require keyboard input)
            // - Update Mario's state as needed

            // Step 1: Grab user input
            KeyboardState kbState = Keyboard.GetState();

            // Step 2: Change state
            switch (mario.State)
            {
                //Mario facing left or walking left
                case MarioState.FaceLeft:
                case MarioState.WalkLeft:
                    if (kbState.IsKeyDown(Keys.Left))
                    {
                        mario.State = MarioState.WalkLeft;
                    }
                    else if (kbState.IsKeyUp(Keys.Left))
                    {
                        mario.State = MarioState.FaceLeft;
                    }
                    if (mario.State == MarioState.FaceLeft && kbState.IsKeyDown(Keys.Right))
                    {
                        mario.State = MarioState.FaceRight;
                    }
                    if (kbState.IsKeyDown(Keys.Down) && mario.State == MarioState.FaceLeft)
                    {
                        mario.State = MarioState.CrouchLeft;
                    }
                    break;

                //Mario crouching left
                case MarioState.CrouchLeft:
                    if(kbState.IsKeyUp(Keys.Down))
                    {
                        mario.State = MarioState.FaceLeft;
                    }
                    break;

                //mario facing right or walking right
                case MarioState.FaceRight:
                case MarioState.WalkRight:
                    if (kbState.IsKeyDown(Keys.Right))
                    {
                        mario.State = MarioState.WalkRight;
                    }
                    else if(kbState.IsKeyUp(Keys.Right))
                    {
                        mario.State = MarioState.FaceRight;
                    }
                    if (mario.State == MarioState.FaceRight && kbState.IsKeyDown(Keys.Left))
                    {
                        mario.State = MarioState.FaceLeft;
                    }
                    if(kbState.IsKeyDown(Keys.Down) && mario.State == MarioState.FaceRight)
                    {
                        mario.State = MarioState.CrouchRight;
                    }
                    break;

                //mario crouching right
                case MarioState.CrouchRight:
                    if (kbState.IsKeyUp(Keys.Down))
                    {
                        mario.State = MarioState.FaceRight;
                    }
                    break;

            }
            // Step 3: Move Mario only when walking
            if(mario.State == MarioState.WalkLeft)
            {
                if (kbState.IsKeyDown(Keys.Left))
                {
                    mario.X -= 1;
                }
            }

            else if(mario.State == MarioState.WalkRight)
            {
                if(kbState.IsKeyDown(Keys.Right))
                {
                    mario.X += 1;
                }
            }

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin the sprite batch
            _spriteBatch.Begin();

            mario.Draw(_spriteBatch);

            // End the sprite batch
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
