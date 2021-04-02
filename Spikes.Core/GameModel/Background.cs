using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    /// <summary>
    /// Class representing the background of the game
    /// </summary>
    class Background : GameObject
    {
        /// <summary>
        /// The picture
        /// </summary>
        private Texture2D _imageBackground;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game"> game </param>
        /// <param name="spriteBatch"> spritebatch of the game</param>
        public Background(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
            LoadContent();
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
