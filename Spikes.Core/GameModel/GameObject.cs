using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    /// <summary>
    /// Represent a object
    /// </summary>
    public abstract class GameObject : DrawableGameComponent
    {
        /// <summary>
        /// Spritebatch of the game
        /// </summary>
        protected readonly SpriteBatch _spriteBatch;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="game">Game</param>
        /// <param name="spriteBatch">Spritebatch</param>
        public GameObject(Game game, SpriteBatch spriteBatch) : base(game)
        {
            _spriteBatch = spriteBatch;
        }
        
    }
}
