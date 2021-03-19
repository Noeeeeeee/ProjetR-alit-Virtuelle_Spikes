using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spikes.Core.GameModel;
using System.Collections.Generic;

namespace Spikes.Core
{
    public class Game1 : Game
    {
        public GraphicsDeviceManager Graphics { get; }
        private SpriteBatch _spriteBatch;
        Vector2 baseScreenSize = new Vector2(800, 480);
        private Matrix globalTransformation;
        int backbufferWidth, backbufferHeight;

        private IList<GameObject> GameObjects { get; set; } = new List<GameObject>();

        private bool _hasStarted;

        bool died = false;

        GameModel.Plane Plane { get; set; }

        public SpikesManager SpikesManager { get; set; }

        public GameObject Background { get; set; }



        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Graphics.PreferredBackBufferWidth = 720;
            Graphics.PreferredBackBufferHeight = 800;
        }

        public void ScalePresentationArea()
        {
            //Work out how much we need to scale our graphics to fill the screen
            backbufferWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
            backbufferHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
            float horScaling = backbufferWidth / baseScreenSize.X;
            float verScaling = backbufferHeight / baseScreenSize.Y;
            Vector3 screenScalingFactor = new Vector3(horScaling, verScaling, 1);
            globalTransformation = Matrix.CreateScale(screenScalingFactor);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

           
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Restart();

            // TODO: use this.Content to load your game content here
        }

        private void Restart()
        {

            
           Plane = new GameModel.Plane(this, _spriteBatch);
            SpikesManager = new SpikesManager(this, _spriteBatch);
            SpikesManager.loadSpikeRight();
            Plane.ToucheMur += Plane_ToucheMur;
            GameObjects.Add(Plane);
            GameObjects.Add(SpikesManager);
            Background = new Background(this, _spriteBatch);

            _hasStarted = false;
        }

        private bool HandleCollision()
        {
            foreach(var spike in SpikesManager.spikesListLeftRight)
            {
               foreach( var rectangle in spike.BoundingRectangles)
                {
                    if (rectangle.Intersects(Plane.BoundingRectangle))
                        return true;
                }
            }
            return false;
        }

        private void Plane_ToucheMur(bool BoolDirection)
        {
            SpikesManager.spikesListLeftRight.Clear();
            if (!BoolDirection) // quand l'avion va vers la droite
            {
                SpikesManager.loadSpikeRight();
            }
            else
            {
                SpikesManager.loadSpikeLeft();
            }
        }


        protected override void Update(GameTime gameTime)
        {
            Graphics.ApplyChanges();
            //Confirm the screen has not been resized by the user
            if (backbufferHeight != GraphicsDevice.PresentationParameters.BackBufferHeight ||
                backbufferWidth != GraphicsDevice.PresentationParameters.BackBufferWidth)
            {
                ScalePresentationArea();
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Condition to start the game
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _hasStarted = true;


            if (!_hasStarted)
                return;


            Background.Update(gameTime);

            foreach (var gameObjects in GameObjects)
            {
                gameObjects.Update(gameTime);
            }
            var died = HandleCollision();
            if (died)
            {
                
            }

            foreach(var gameobject in GameObjects)
            {
                if(gameobject is GameModel.Plane)
                {
                    var plane = gameobject as GameModel.Plane;
                    if(plane.hasDied)
                    {
                        died = true;
                        
                    }
                }

            }
            if(died)
            {
                GameObjects.Clear();
                Restart();
            }       
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);
            Background.Draw(gameTime);
            _spriteBatch.End();

            _spriteBatch.Begin();
            foreach (var gameObjects in GameObjects)
            {
                gameObjects.Draw(gameTime);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
