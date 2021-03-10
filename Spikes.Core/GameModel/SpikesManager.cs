using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    public class SpikesManager : GameObject
    {
        public IList<Spike> spikesList { get; set; } = new List<Spike>();

        //Screen Parameters
        int screenWidth;
        int screenHeight;

        public SpikesManager(Game game, SpriteBatch spriteBatch) : base(game, spriteBatch)
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
            screenWidth = 720;
            screenHeight = 800;
            for(int i = 0; i < screenWidth; i += 45)
            {
                spikesList.Add(new Spike(Game, _spriteBatch, new Vector2(i, screenHeight-100), "Sprites/Spikes/rockGrass"));
            }

            for (int i = 0; i < screenWidth; i += 45)
            {
                spikesList.Add(new Spike(Game, _spriteBatch, new Vector2(i, 0), "Sprites/Spikes/rockGrassDown"));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach(var spike in spikesList)
            {
                spike.Update(gameTime);
            }


        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            foreach (var spike in spikesList)
            {
                spike.Draw(gameTime);
            }
        }
    }
}
