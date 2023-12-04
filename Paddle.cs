using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public class Paddle
    {
        public Rectangle Rect;
        readonly float moveSpeed = 500f;
        bool isPlayerTwo;

        public Paddle(bool isPlayerTwo)
        {
            this.isPlayerTwo = isPlayerTwo;
            if (this.isPlayerTwo) 
            {
                Rect = new Rectangle(Globals.WIDTH - 40, 140, 40, 200);
            } else 
            {
                Rect = new Rectangle(0, 140, 40, 200);
            }
        }
        public void Update(GameTime gametime)
        {
            KeyboardState k = Keyboard.GetState();

            if (this.isPlayerTwo)
            {
                if (k.IsKeyDown(Keys.Up) && Rect.Y > 0)
                {
                    Rect.Y -= (int)(moveSpeed * (float)gametime.ElapsedGameTime.TotalSeconds);
                }
                if (k.IsKeyDown(Keys.Down) && Rect.Y < Globals.HEIGHT - Rect.Height)
                {
                    Rect.Y += (int)(moveSpeed * (float)gametime.ElapsedGameTime.TotalSeconds);
                }
            }
            else
            {

                if (k.IsKeyDown(Keys.W) && Rect.Y > 0)
                {
                    Rect.Y -= (int)(moveSpeed * (float)gametime.ElapsedGameTime.TotalSeconds);
                }
                if (k.IsKeyDown(Keys.S) && Rect.Y < Globals.HEIGHT - Rect.Height)
                {
                    Rect.Y += (int)(moveSpeed * (float)gametime.ElapsedGameTime.TotalSeconds);
                }
            }
        }
        public void Draw()
        {
            Globals.spriteBatch.Draw(Globals.pixel, Rect, Color.White);
        }
    }
}
