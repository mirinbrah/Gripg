using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Gripg
{
    public class Animation
    {
        private readonly Texture2D _texture;
        private readonly Rectangle[] _frames;
        private readonly float _frameTime;
        private float _timer;
        private int _currentFrame;

        public Animation(Texture2D texture, Rectangle[] frames, float frameTime)
        {
            _texture = texture;
            _frames = frames;
            _frameTime = frameTime;
        }

        public void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer < _frameTime)
            {
                return;
            }

            _timer -= _frameTime;
            _currentFrame = (_currentFrame + 1) % _frames.Length;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, float scale)
        {
            Rectangle frame = _frames[_currentFrame];
            Vector2 origin = new Vector2(frame.Width / 2f, frame.Height / 2f);

            spriteBatch.Draw(
                _texture,
                position,
                frame,
                Color.White,
                0f,
                origin,
                scale,
                SpriteEffects.None,
                0f);
        }
    }
}
