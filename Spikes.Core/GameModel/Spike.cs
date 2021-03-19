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

        public IList<Rectangle> BoundingRectangles { get; set; } = new List<Rectangle>();

        Vector2 spikePosition { get; set; }

        //Screen Parameters
        int screenWidth;
        int screenHeight;

        public Spike(Game game, SpriteBatch spriteBatch, Vector2 position, string imagePath) : base(game, spriteBatch)
        {
            this.imagePath = imagePath;
            LoadContent();
            spikePosition = position;
        }

        public void setLeftRectangles(int y)
        {
            BoundingRectangles.Add(new Rectangle(0, y, 22, 40));
            BoundingRectangles.Add(new Rectangle(22, y-3, 19, 30));
            BoundingRectangles.Add(new Rectangle(41, y-8, 17, 21));
            BoundingRectangles.Add(new Rectangle(58, y-12, 17, 14));
            BoundingRectangles.Add(new Rectangle(75, y-17, 27, 9));
        }

        public void setRightRectangles(int y)
        {
            BoundingRectangles.Add(new Rectangle(screenWidth-20, y, 22, 40));
            BoundingRectangles.Add(new Rectangle(screenWidth - 22, y - 3, 19, 30));
            BoundingRectangles.Add(new Rectangle(screenWidth - 41, y - 8, 17, 21));
            BoundingRectangles.Add(new Rectangle(screenWidth - 58, y - 12, 17, 14));
            BoundingRectangles.Add(new Rectangle(screenWidth - 75, y - 17, 27, 9));
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            _texture = Game.Content.Load<Texture2D>(imagePath);
            screenWidth = 720;
            screenHeight = 800;
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
