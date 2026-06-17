using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Gripg
{
    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player _player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D playerTexture = Content.Load<Texture2D>("player/player");

            Rectangle[] idleFrames =
            {
                new Rectangle(0, 0, 160, 128),
                new Rectangle(160, 0, 160, 128),
                new Rectangle(320, 0, 160, 128),
                new Rectangle(480, 0, 160, 128),
                new Rectangle(640, 0, 160, 128),
                new Rectangle(800, 0, 160, 128),
                new Rectangle(960, 0, 160, 128),
                new Rectangle(1120, 0, 160, 128),
            };

            Animation idleAnimation = new Animation(playerTexture, idleFrames, 0.18f);

            _player = new Player(new Vector2(300, 300), idleAnimation)
            {
                Scale = 4f,
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            _player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _player.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
