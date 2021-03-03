using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    public class Plane : GameObject
    {
        private Texture2D _texture;
        private SpriteBatch _spriteBatch;
        private static float velocity { get; set; } = 5f;

        private static float gravitation { get; set; } = 5f;
        private Vector2 Gravitation { get; set; } = new Vector2(velocity, gravitation);

        Vector2 planePosition { get; set; } = Vector2.Zero;

        private Rectangle BoundingRectangle => new Rectangle((int)planePosition.X, (int)planePosition.Y, _texture.Width, _texture.Height);

        bool hasJumped = true;

        bool reachlimitY = false;
        bool reachlimitX = false;

        //Screen Parameters
        int screenWidth;
        int screenHeight;



        public Plane(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
            _spriteBatch = spriteBatch;
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
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Draw(_texture, planePosition, Color.White);
        }

        public override void Update(GameTime gameTime)
        {

            var keyboardState = Keyboard.GetState();


            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (hasJumped && key == Keys.Space)
                {
                    planePosition = Vector2.Add(planePosition, new Vector2(0, -25));
                    hasJumped = false;
                }
            }

                if (keyboardState.IsKeyUp(Keys.Space))
                {
                    hasJumped = true;
                }

                if (hasJumped)
                    planePosition = Vector2.Add(planePosition, Gravitation);




            if (BoundingRectangle.X <= 0)
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitX);
                reachlimitX = true;

            if (BoundingRectangle.X + BoundingRectangle.Width >= screenWidth)
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitX);

            if (BoundingRectangle.Y <= 0)
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitY);
                reachlimitY = true;

            if (BoundingRectangle.Y + BoundingRectangle.Height >= screenHeight)
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitY);


            base.Update(gameTime);
        }
    }
}

