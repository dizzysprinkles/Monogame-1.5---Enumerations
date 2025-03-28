using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_1._5___Enumerations
{
    enum FruitState
    {
        Fresh,
        Mouldy,
        ReallyMouldy,
        Rotten
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        FruitState fruitState;
        KeyboardState keyboardState;
        MouseState mouseState;
        string message;

        Texture2D fruit1Texture, fruit2Texture, fruit3Texture, fruit4Texture;
        SpriteFont instructionFont;
        Rectangle window;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            window = new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
            fruitState = FruitState.Fresh;
            message = "Left click the mouse to travel to the future.";

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            fruit1Texture = Content.Load<Texture2D>("Images/fruit1");
            fruit2Texture = Content.Load<Texture2D>("Images/fruit2");
            fruit3Texture = Content.Load<Texture2D>("Images/fruit3");
            fruit4Texture = Content.Load<Texture2D>("Images/fruit4");
            instructionFont = Content.Load<SpriteFont>("Fonts/InstructionFont");

        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            if (fruitState == FruitState.Fresh)
            {
                message = "Click left mouse button to travel to the future.";
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    fruitState = FruitState.Mouldy;
                }
            }
            else if (fruitState == FruitState.Mouldy)
            {
                message = "Hit spacebar to travel to the future.";
                if (keyboardState.IsKeyDown(Keys.Space))
                {
                    fruitState = FruitState.ReallyMouldy;
                }
            }
            else if (fruitState == FruitState.ReallyMouldy)
            {
                message = "Hit enter to travel to the future.";
                if (keyboardState.IsKeyDown(Keys.Enter))
                {
                    fruitState = FruitState.Rotten;
                }
            }
            else if (fruitState == FruitState.Rotten)
            {
                message = "Right click the mouse to travel to the distant past.";
                if (mouseState.RightButton == ButtonState.Pressed)
                {
                    fruitState = FruitState.Fresh;
                }
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            if (fruitState == FruitState.Fresh)
            {
                _spriteBatch.Draw(fruit1Texture, window, Color.White);
            }
            else if (fruitState == FruitState.Mouldy)
            {
                _spriteBatch.Draw(fruit2Texture, window, Color.White);
            }
            else if (fruitState == FruitState.ReallyMouldy)
            {
                _spriteBatch.Draw(fruit3Texture, window, Color.White);
            }
            else if (fruitState == FruitState.Rotten)
            {
                _spriteBatch.Draw(fruit4Texture, window, Color.White);
            }
            _spriteBatch.DrawString(instructionFont, message, new Vector2(10, 10), Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
