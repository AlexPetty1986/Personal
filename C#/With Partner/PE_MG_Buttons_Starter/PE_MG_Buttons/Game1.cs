using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace PE_MG_Buttons
{
    public class Game1 : Game
    {
        // Fields created by the MG template
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The list of buttons and setup for random bg color
        private SpriteFont font;
        private List<Button> buttons = new List<Button>();
        private Color bgColor = Color.White;
        private Random rng = new Random();

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ADD Your new fields here!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private List<Texture2D> sun = new List<Texture2D>();
        private Texture2D sunStar;
        private int leftButton = 0;
        private int rightButton = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("buttonFont");
            sunStar = Content.Load<Texture2D>("sun");

            // Create a few 100x200 buttons down the left side
            buttons.Add(new Button(
                    _graphics.GraphicsDevice,           // device to create a custom texture
                    new Rectangle(10, 40, 200, 100),    // where to put the button
                    "Random BG",                        // button label
                    font,                               // label font
                    Color.Purple));                     // button color
            buttons[0].OnLeftButtonClick += this.RandomizeBackground;
            buttons[0].OnLeftButtonClick += this.LeftButtonClicked;
            buttons[0].OnRightButtonClick += this.RandomizeBackground;
            buttons[0].OnRightButtonClick += this.RightButtonClicked;

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Add your additional button setup code here!
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            buttons.Add(new Button(
                    _graphics.GraphicsDevice,           // device to create a custom texture
                    new Rectangle(10, 160, 200, 100),   // where to put the button
                    "Sun",                              // button label
                    font,                               // label font
                    Color.Blue));                       // button color
            buttons[1].OnLeftButtonClick += this.AddSun;
            buttons[1].OnLeftButtonClick += this.LeftButtonClicked;
            buttons[1].OnRightButtonClick += this.AddSun;
            buttons[1].OnRightButtonClick += this.RightButtonClicked;

            buttons.Add(new Button(
                    _graphics.GraphicsDevice,           // device to create a custom texture
                    new Rectangle(10, 280, 200, 100),   // where to put the button
                    "Snow",                             // button label
                    font,                               // label font
                    Color.Red));                        // button color
            buttons[2].OnLeftButtonClick += this.RemoveSun;
            buttons[2].OnLeftButtonClick += this.LeftButtonClicked;
            buttons[2].OnRightButtonClick += this.RemoveSun;
            buttons[2].OnRightButtonClick += this.RightButtonClicked;
        }

        // There is no need to add anything to Game1's Update method!
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Button b in buttons)
            {
                b.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            _spriteBatch.Begin();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Add your additional drawing code here!
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            for(int i = 0; i < sun.Count; i++)
            {
                _spriteBatch.Draw(sun[i], new Rectangle(rng.Next(GraphicsDevice.Viewport.Width) - 50,
                rng.Next(GraphicsDevice.Viewport.Height) - 50, sun[sun.Count - 1].Width / 10, sun[sun.Count - 1].Height / 10), Color.White);
            }
            

            // Draw the buttons last.
            _spriteBatch.DrawString(font, "# of Clicks: Left - " + leftButton + " Right - " + rightButton, new Vector2(10, 10), Color.Black);

            foreach (Button b in buttons)
            {
                b.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // Button click handlers!
        public void LeftButtonClicked()
        {
            leftButton++;
        }

        public void RightButtonClicked()
        {
            rightButton++;
        }

        // Leave this one alone
        public void RandomizeBackground()
        {
            bgColor = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Add your new button click handlers here!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //adds a sun to the list
        public void AddSun()
        {
            sun.Add(sunStar);
        }

        //Removes a random sun from the list
        public void RemoveSun()
        {
            if(sun.Count > 0)
            {
                sun.RemoveAt(rng.Next(sun.Count));
            }
        }
    }
}
