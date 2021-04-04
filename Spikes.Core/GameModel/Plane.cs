using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    /// <summary>
    /// Class which represent a plane
    /// </summary>
    public class Plane : GameObject
    {
        /// <summary>
        /// Texture of a plane
        /// </summary>
        private Texture2D _texture;

        /// <summary>
        /// Effect for the plane to rotate the texture
        /// </summary>
        private SpriteEffects flip = SpriteEffects.None;

        /// <summary>
        /// value for the gravitation
        /// </summary>
        private static float velocity { get; set; } = 3f;

        /// <summary>
        /// value for the gravitation
        /// </summary>
        private static float gravitation { get; set; } = 3f;

        /// <summary>
        /// Vector of Gravitation
        /// </summary>
        private Vector2 Gravitation { get; set; } = new Vector2(velocity, gravitation);

        /// <summary>
        /// Position of the plane
        /// </summary>
        private Vector2 planePosition { get; set; }

        /// <summary>
        /// BoundingRectangle of the plane
        /// </summary>
        public Rectangle BoundingRectangle => new Rectangle((int)planePosition.X, (int)planePosition.Y, _texture.Width, _texture.Height);

        /// <summary>
        /// Verify that the plane has jumped
        /// </summary>
        private bool hasJumped = true;


        /// <summary>
        /// Verify that the plane has died
        /// </summary>
        public bool hasDied = false;

        /// <summary>
        /// Direction of the plane (false = right and true = left)
        /// </summary>
        private bool BoolDirection { get; set; } = false;

        /// <summary>
        /// Screen parameter Width)
        /// </summary>
        private int screenWidth;

        /// <summary>
        /// Screen parameter Height
        /// </summary>
        private int screenHeight;

        /// <summary>
        /// provoke it self when a plaine hit the wall
        /// </summary>
        public event Action<bool> TouchWall;

        /// <summary>
        /// Constructor of the plane
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="spriteBatch">Spritebatch</param>
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
                    if (BoolDirection) //In left
                    {
                        planePosition = Vector2.Add(planePosition, new Vector2(-20, -65));
                        hasJumped = false;
                    }

                    else //In right
                    {
                        planePosition = Vector2.Add(planePosition, new Vector2(20, -65));
                        hasJumped = false;
                    }
                }
            }

            if (keyboardState.IsKeyUp(Keys.Space))
            {
                hasJumped = true;
            }

            planePosition = Vector2.Add(planePosition, Gravitation);


            if (isCollideLeft())
            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitX);
                BoolDirection = false;
                TouchWall(BoolDirection);
            }

            if (isCollideRight())
            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitX);
                BoolDirection = true;
                TouchWall(BoolDirection);
            }

            if (isCollideTop())
            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitY);
                hasDied = true;
            }


            if (isCollideBottom())
            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitY);
                hasDied = true;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// bool method Collision with right side of the screen
        /// </summary>
        /// <returns>true or false</returns>
        private bool isCollideRight()
        {
            return BoundingRectangle.X + BoundingRectangle.Width >= screenWidth && !BoolDirection;
        }

        /// <summary>
        /// bool method Collision with left side of the screen
        /// </summary>
        /// <returns>true or false</returns>
        private bool isCollideLeft()
        {
            return BoundingRectangle.X <= 0 && BoolDirection;
        }

        /// <summary>
        /// bool method Collision with the top of the screen
        /// </summary>
        /// <returns></returns>
        private bool isCollideTop()
        {
            return BoundingRectangle.Y <= 80;
        }

        /// <summary>
        /// bool method Collision with the bottom of the screen
        /// </summary>
        /// <returns></returns>
        private bool isCollideBottom()
        {
            return BoundingRectangle.Y + BoundingRectangle.Height >= screenHeight - 100;
        }
    }
}
