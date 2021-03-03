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
        private float velocity = 150f;
        private float jump = -800f; // distance of the jump of the plane
        private float gravity = 150f; // gravity of the plane
        private float screenWidth;
        private float screenHeight;
        bool hasJumped = true;

        // position of the plane
        public Vector2 Position { get; set; }        



        public Plane(Game1 game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
            LoadContent();
            // to put the plane in the center of the screen
            screenWidth = game.Graphics.PreferredBackBufferWidth;
            screenHeight = game.Graphics.PreferredBackBufferHeight;
            Position = new Vector2(screenWidth / 2, screenHeight / 2);
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
            _spriteBatch.Draw(_texture, Position, null, Color.White, 0f, new Vector2(_texture.Width / 2, _texture.Height / 2), Vector2.One, SpriteEffects.None, 0f );
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            var keyboardState = Keyboard.GetState(); // keyboard

            
            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if(hasJumped && key == Keys.Space)
                {
                    Position = Vector2.Add(Position, new Vector2(velocity * (float)gameTime.ElapsedGameTime.TotalSeconds, jump * (float)gameTime.ElapsedGameTime.TotalSeconds));
                    hasJumped = false;
                }
                
            }

            if (keyboardState.IsKeyUp(Keys.Space))
            {
                hasJumped = true;
            }

            if (hasJumped)
                Position = Vector2.Add(Position, new Vector2(velocity * (float)gameTime.ElapsedGameTime.TotalSeconds, gravity * (float)gameTime.ElapsedGameTime.TotalSeconds));


           
            //var touchCollection = TouchPanel.GetState(); // phone's screen
            //foreach (var touchLocation in touchCollection)
            //{
            //    if (touchLocation.State == TouchLocationState.Pressed)
            //    {
            //        //if (touchLocation.Position.X > 10)
            //        //{
            //        //}
            //        Position = Vector2.Add(Position, new Vector2(velocity * (float)gameTime.ElapsedGameTime.TotalSeconds, jump * (float)gameTime.ElapsedGameTime.TotalSeconds));
            //    }
            //    else Position = Vector2.Add(Position, new Vector2(velocity * (float)gameTime.ElapsedGameTime.TotalSeconds, gravity * (float)gameTime.ElapsedGameTime.TotalSeconds));

            //}
        }
    }
}
