using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    /// <summary>
    /// Class which represent a spike
    /// </summary>
    public class Spike : GameObject
    {
        /// <summary>
        /// Texture of a spike
        /// </summary>
        public Texture2D _texture;

        /// <summary>
        /// Path of the pictore for the spike
        /// </summary>
        private string imagePath;

        /// <summary>
        /// List of rectangles for the collision with the spikes
        /// </summary>
        public IList<Rectangle> BoundingRectangles { get; set; } = new List<Rectangle>();


        /// <summary>
        /// width of the screen
        /// </summary>
        int screenWidth;

        /// <summary>
        /// height of the screen
        /// </summary>
        int screenHeight;

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="spriteBatch">Spritebatch</param>
        /// <param name="position">position of the spike</param>
        /// <param name="imagePath">Path of the pictore for the spike</param>
        public Spike(Game game, SpriteBatch spriteBatch, Vector2 position, string imagePath) : base(game, spriteBatch)
        {
            this.imagePath = imagePath;
            LoadContent();
        }

        /// <summary>
        /// Set all the rectangles for a spike on the left side
        /// </summary>
        /// <param name="y">position of the spike</param>
        public void setLeftRectangles(int y)
        {
            BoundingRectangles.Add(new Rectangle(0, y, 22, 40));
            BoundingRectangles.Add(new Rectangle(22, y - 3, 19, 30));
            BoundingRectangles.Add(new Rectangle(41, y - 8, 17, 21));
            BoundingRectangles.Add(new Rectangle(58, y - 12, 17, 14));
            BoundingRectangles.Add(new Rectangle(75, y - 17, 27, 9));
        }

        /// <summary>
        /// Set all the rectangles for a spike on the right side
        /// </summary>
        /// <param name="y">position of the spike</param>
        public void setRightRectangles(int y)
        {
            BoundingRectangles.Add(new Rectangle(screenWidth - 20, y, 22, 40));
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
