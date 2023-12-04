using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private Paddle playerOne;
        private Paddle playerTwo;
        private Ball ball;
        private SpriteFont font;

        public Game1() {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferHeight = Globals.HEIGHT;
            _graphics.PreferredBackBufferWidth = Globals.WIDTH;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
            // TODO: Add your initialization logic here
            playerOne = new Paddle(false);
            playerTwo = new Paddle(true);
            ball = new Ball();

            base.Initialize();
        }

        protected override void LoadContent() {
            Globals.spriteBatch = new SpriteBatch(GraphicsDevice);

            Globals.pixel = new Texture2D(GraphicsDevice, 1, 1);
            Globals.pixel.SetData<Color>(new Color[] { Color.White });
            font = this.Content.Load<SpriteFont>("Score");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            playerOne.Update(gameTime);
            playerTwo.Update(gameTime);
            ball.Update(gameTime, playerOne, playerTwo);

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            Globals.spriteBatch.Begin();
            // TODO: Add your drawing code here
            writeScore();
            playerOne.Draw();

            playerTwo.Draw();

            ball.Draw();
            Globals.spriteBatch.End();

            base.Draw(gameTime);
        }

        private void writeScore() {
            Vector2 scoreLoc = new Vector2(Globals.WIDTH / 2 -  84, 20);
            string score = string.Format("{0} : {1}", Globals.playerOneScore, Globals.playerTwoScore);
            Globals.spriteBatch.DrawString(font, score, scoreLoc, Color.White);
        }
    }
}
