using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Spikes.Core.GameModel
{
    /// <summary>
    /// Manager of the game
    /// </summary>
    public class GameManager : GameObject
    {
        /// <summary>
        /// Score of the player
        /// </summary>
        public int score { get; private set; }

        /// <summary>
        /// List of all objetcs
        /// </summary>
        private IList<GameObject> GameObjects { get; set; } = new List<GameObject>();

        /// <summary>
        /// True if the player pressed space, false otherwise
        /// </summary>
        public bool _hasStarted { get; set; }

        /// <summary>
        /// Verifiy if th player is dead
        /// </summary>
        private bool died { get; set; } = false;

        /// <summary>
        /// The plane
        /// </summary>
        private Plane Plane { get; set; }

        /// <summary>
        /// Manager of the spikes on the walls
        /// </summary>
        private SpikesManager SpikesManager { get; set; }

        /// <summary>
        /// Background of the game
        /// </summary>
        public GameObject Background { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game"> game </param>
        /// <param name="spriteBatch"> spritebatch of the game</param>
        public GameManager(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
        {
            Restart();
        }

        /// <summary>
        /// Reload the game to play again
        /// </summary>
        public void Restart()
        {

            score = 0;
            Plane = new Plane(Game, _spriteBatch);
            SpikesManager = new SpikesManager(Game, _spriteBatch);
            SpikesManager.loadSpikeRight(score);
            Plane.ToucheMur += Plane_ToucheMur;
            GameObjects.Add(Plane);
            GameObjects.Add(SpikesManager);
            Background = new Background(Game, _spriteBatch);

            _hasStarted = false;
        }

        /// <summary>
        /// Method which verify the collsion between the plane and the spikes
        /// </summary>
        /// <returns></returns>
        private bool HandleCollision()
        {
            foreach (var spike in SpikesManager.spikesListLeftRight)
            {
                foreach (var rectangle in spike.BoundingRectangles)
                {
                    if (rectangle.Intersects(Plane.BoundingRectangle))
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Method which verify if the plane is touching the left or right side
        /// </summary>
        /// <param name="BoolDirection"></param>
        private void Plane_ToucheMur(bool BoolDirection)
        {
            SpikesManager.spikesListLeftRight.Clear();
            if (!BoolDirection) // quand l'avion va vers la droite
            {
                score++;
                SpikesManager.loadSpikeRight(score);
            }
            else
            {
                score++;
                SpikesManager.loadSpikeLeft(score);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            base.LoadContent();

        }

        public override void Update(GameTime gameTime)
        {

            Background.Update(gameTime);

            foreach (var gameObjects in GameObjects)
            {
                gameObjects.Update(gameTime);
            }

            died = HandleCollision();

            foreach (var gameobject in GameObjects)
            {
                if (gameobject is Plane)
                {
                    var plane = gameobject as Plane;
                    if (plane.hasDied)
                    {
                        died = true;

                    }
                }

            }

            if (died)
            {
                GameObjects.Clear();
                Restart();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            foreach (var gameObjects in GameObjects)
            {
                gameObjects.Draw(gameTime);
            }

            base.Draw(gameTime);

        }
    }
}
