using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    public class Plane : GameObject
    {
        private Texture2D _texture;


        public Plane(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
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
            _texture = Game.Content.Load<Texture2D>("Sprites/Plane/planeRed1");
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Draw(_texture, Vector2.Zero, Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
