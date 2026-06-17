using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gripg
{
    public class Player
    {
        private Vector2 _position;
        private readonly Animation _idleAnimation;

        public float Speed { get; set; } = 200f;
        public float Scale { get; set; } = 4f;

        public Player(Vector2 startPosition, Animation idleAnimation)
        {
            _position = startPosition;
            _idleAnimation = idleAnimation;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState keyboard = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (keyboard.IsKeyDown(Keys.W))
            {
                direction.Y -= 1f;
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                direction.Y += 1f;
            }

            if (keyboard.IsKeyDown(Keys.A))
            {
                direction.X -= 1f;
            }

            if (keyboard.IsKeyDown(Keys.D))
            {
                direction.X += 1f;
            }

            if (direction != Vector2.Zero)
            {
                direction.Normalize();
            }

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            _position += direction * Speed * deltaTime;

            _idleAnimation.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            _idleAnimation.Draw(spriteBatch, _position, Scale);
        }
    }
}
