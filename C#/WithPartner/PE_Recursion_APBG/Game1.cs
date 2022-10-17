using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_Recursion_APBG
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            string itemA = "tacocat";
            string itemB = "apple";
            string itemC= "razor";

            System.Diagnostics.Debug.WriteLine(itemA + ": " + IsPalindrome(itemA, 0, itemA.Length - 1));
            System.Diagnostics.Debug.WriteLine(itemB + ": " + IsPalindrome(itemB, 0, itemB.Length - 1));
            System.Diagnostics.Debug.WriteLine(itemC + ": " + IsPalindrome(itemC, 0, itemC.Length - 1));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Vector2 pos = new Vector2(400, 475);
            float radians = (float)(Math.PI / 180 * 90);

            // TODO: Add your drawing code here
            ShapeBatch.Begin(GraphicsDevice);
                RecursiveTree(pos, 100f, radians);
            ShapeBatch.End();
            base.Draw(gameTime);
        }

        private bool IsPalindrome(string phrase, int startIndex, int endIndex)
        {
            //if the starting index is equal to or greater than the end index
            if (startIndex >= endIndex)
            {
                return true;
            }

            //if the letters are not equal
            else if (phrase[startIndex] != phrase[endIndex])
            {
                return false;
            }
                   
            return IsPalindrome(phrase, startIndex+1, endIndex-1);
        }

        private void RecursiveTree(Vector2 position, float length, float angle)
        {
            Vector2 locate = ShapeBatch.Line(position, length, angle, Color.White);

            //to stop it from going onforever
            if(length > 1)
            {
                RecursiveTree(locate, .8f * length, angle + .45f);
                RecursiveTree(locate, .8f * length, angle + -.45f);
            }
        }

        /*private void RecursiveThing(Vector2 position, float length, float angle)
        {
            ShapeBatch.Triangle(position, length, angle, Color.White);

            if (length > 10)
            {
                RecursiveThing(new Vector2(position, position + 50), .8f * length, angle + .45f);
                RecursiveThing(-position, .8f * length, angle + -.45f);
            }
        }*/
    }
}
