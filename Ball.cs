using Microsoft.Xna.Framework;

namespace Pong {
    public class Ball {
        Rectangle rect;
        int right = 1; 
        int top = 1; 
        int moveSpeed = 200;

        public Ball() {
            rect = new Rectangle(Globals.WIDTH / 2 - 20, Globals.HEIGHT / 2 - 20, 40, 40);
        }
        public void Update(GameTime gametime, Paddle playerOne, Paddle playerTwo) {
            int delta = (int)(moveSpeed *  (float) gametime.ElapsedGameTime.TotalSeconds);

            if (playerOne.Rect.Right > rect.Left && playerOne.Rect.Top < rect.Top && playerOne.Rect.Bottom > rect.Bottom) {
                right = 1;
            }
            // inverse for player 2
            if (playerTwo.Rect.Left < rect.Right && playerTwo.Rect.Top < rect.Top && playerTwo.Rect.Bottom > rect.Bottom) {
                right = -1;
            }

            if (rect.Y < 0) {
                top *= -1;
            }
            if (rect.Y > Globals.HEIGHT - rect.Height) {
                top *= -1;
            }

            if (rect.X < 0) {
                Globals.playerTwoScore++;
                resetGame();
            }
            if (rect.X > Globals.WIDTH - rect.Width) {
                Globals.playerOneScore++;
                resetGame();
            }


            rect.X += delta * right;
            rect.Y += delta * top;
        }
        public void Draw() {
            Globals.spriteBatch.Draw(Globals.pixel, rect, Color.White);
        }

        private void resetGame() {
            rect.X = Globals.WIDTH / 2 - 20;
            rect.Y = Globals.HEIGHT / 2 - 20;
        }
    }
}
