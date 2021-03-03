using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    class Background : GameObject
    {

        private Game1 _game;
        private Texture2D _imageBackground;

        public Background(Game1 game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
            LoadContent();
            _game = game;

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _imageBackground = Game.Content.Load<Texture2D>("Sprites/Background/background");

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);


        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_imageBackground, Vector2.Zero, Color.White);


            base.Draw(gameTime);
        }
    }
}
