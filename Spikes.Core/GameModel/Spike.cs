using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    public class Spike : GameObject
    {
        public Texture2D _texture;
        private string imagePath;

        Vector2 spikePosition { get; set; }

        public Spike(Game game, SpriteBatch spriteBatch, Vector2 position, string imagePath) : base(game, spriteBatch)
        {
            this.imagePath = imagePath;
            LoadContent();
            spikePosition = position;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _texture = Game.Content.Load<Texture2D>(imagePath);

        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            _spriteBatch.Draw(_texture, spikePosition, Color.White);


            base.Draw(gameTime);
        }
    }
}
