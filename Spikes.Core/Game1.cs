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
        private SpriteFont score;
        private SpriteFont startSentence;

        public GameManager GameManager { get; set; }

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
            base.Initialize();
        }

        protected override void LoadContent()
        {
            score = Content.Load<SpriteFont>("score");
            startSentence = Content.Load<SpriteFont>("startSentence");
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            GameManager = new GameManager(this, _spriteBatch);

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
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                GameManager._hasStarted = true;


            if (!GameManager._hasStarted)
                return;

            GameManager.Update(gameTime);
            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, globalTransformation);
            GameManager.Background.Draw(gameTime);
            _spriteBatch.End();


            if (!GameManager._hasStarted)
            {

                _spriteBatch.Begin();
                _spriteBatch.DrawString(score, "Votre dernier score : " + GameManager.lastscore, new Vector2(225, 310), Color.Black);
                _spriteBatch.DrawString(startSentence, "Faites leftShift pour lancer le jeu ", new Vector2(130, 360), Color.Black);
                _spriteBatch.End();
            }
            else
            {
               _spriteBatch.Begin();
               _spriteBatch.DrawString(score, "Score : " + GameManager.score, new Vector2(300, 200), Color.Black);
               _spriteBatch.End();
            }

            _spriteBatch.Begin();
            GameManager.Draw(gameTime);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
