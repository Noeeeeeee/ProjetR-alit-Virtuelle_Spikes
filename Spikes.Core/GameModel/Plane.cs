using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Spikes.Core.GameModel
{
    public class Plane : DrawableGameComponent
    {
        private Texture2D _texture;
        private SpriteBatch _spriteBatch;
        private static float velocity { get; set; } = 1f;

        private static float gravitation { get; set; } = 1f;
        private Vector2 Gravitation { get; set; } = new Vector2(velocity , gravitation );

        Vector2 planePosition { get; set; } = Vector2.Zero;

        private Rectangle BoundingRectangle => new Rectangle((int)planePosition.X, (int)planePosition.Y, _texture.Width, _texture.Height);
        public Plane(Game game, SpriteBatch spriteBatch) : base(game)
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
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            _spriteBatch.Draw(_texture, planePosition, Color.White);
        }

        public override void Update(GameTime gameTime)
        {

            var kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.Up))
                planePosition = Vector2.Add(planePosition, new Vector2(0 * (float)gameTime.ElapsedGameTime.TotalSeconds, -25 * (float)gameTime.ElapsedGameTime.TotalSeconds));

            planePosition = Vector2.Add(planePosition, Gravitation * (float)gameTime.ElapsedGameTime.TotalSeconds);
            var clientBounds = Game.Window.ClientBounds;

            if(BoundingRectangle.Left.Equals(clientBounds.Left) || BoundingRectangle.Right.Equals(clientBounds.Right))
            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitX);
            }

            if (BoundingRectangle.Top.Equals(clientBounds.Top) || BoundingRectangle.Bottom.Equals(clientBounds.Bottom))

            {
                Gravitation = Vector2.Reflect(Gravitation, Vector2.UnitY);
            }

            base.Update(gameTime);
        }
    }
}
