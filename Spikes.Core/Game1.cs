using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spikes.Core.GameModel;

namespace Spikes.Core
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics { get; }
        private SpriteBatch _spriteBatch;

        public GameObject Plane { get; set; }


        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Plane = new GameModel.Plane(this, _spriteBatch);
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

            base.Update(gameTime);

            _spriteBatch.Begin();
            Plane.Update(gameTime);
            _spriteBatch.End();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();
            Plane.Draw(gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
