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

        private SpriteEffects flip = SpriteEffects.None;
        private static float velocity { get; set; } = 3f;

        private static float gravitation { get; set; } = 3f;
        private Vector2 Gravitation { get; set; } = new Vector2(velocity, gravitation);

        Vector2 planePosition { get; set; }

        private Rectangle BoundingRectangle => new Rectangle((int)planePosition.X, (int)planePosition.Y, _texture.Width, _texture.Height);

        bool hasJumped = true;

        bool reachlimitY { get; set; } = false;
        bool reachlimitX { get; set; } = false;

        //false = right and true = left
        bool BoolDirection { get; set; } = false;

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
            planePosition = new Vector2(screenWidth / 2, screenHeight / 2);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            
            if (BoundingRectangle.X <= 0)
            {         
                flip = SpriteEffects.None;
            }

            if (BoundingRectangle.X + BoundingRectangle.Width >= screenWidth)
            {
                flip = SpriteEffects.FlipHorizontally;

            }

           //_spriteBatch.Draw(_texture, planePosition, Color.White);
            _spriteBatch.Draw(_texture, planePosition, null, Color.White, 0.0f, Vector2.Zero, 1.0f, flip, 0.0f);
        }



        public override void Update(GameTime gameTime)
        {
            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            var keyboardState = Keyboard.GetState();


            foreach (Keys key in keyboardState.GetPressedKeys())
            {
                if (hasJumped && key == Keys.Space)
                {
                    if(BoolDirection) //A gauche
                    {
                        planePosition = Vector2.Add(planePosition, new Vector2(-20, -50));
                        hasJumped = false;
                    }

                    else //A droite
                    {
                        planePosition = Vector2.Add(planePosition, new Vector2(20, -50));
                        hasJumped = false;
                    }


                }
            }

            if (keyboardState.IsKeyUp(Keys.Space))
            {
                hasJumped = true;
            }

                planePosition = Vector2.Add(planePosition, Gravitation);
     

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
            if (BoundingRectangle.X <= 0)
            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitX);
                BoolDirection = false;
            }


            if (BoundingRectangle.X + BoundingRectangle.Width >= screenWidth)
            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitX);
                BoolDirection = true;
            }
                

            if (BoundingRectangle.Y <= 100)
            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitY);
                reachlimitY = true;
            }

            if (reachlimitY == true)
            {
                System.Diagnostics.Debug.WriteLine("Touche le haut ou le bas du terrain");
                reachlimitY = false;
            }

            if (BoundingRectangle.Y + BoundingRectangle.Height >= screenHeight-100)
            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitY);
                reachlimitY = true;
            }

            base.Update(gameTime);
        }
    }
}
