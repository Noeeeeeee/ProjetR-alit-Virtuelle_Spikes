using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    public class SpikesManager : GameObject
    {
        public IList<Spike> spikesListTopBottom { get; set; } = new List<Spike>();
        public IList<Spike> spikesListLeftRight { get;  set; } = new List<Spike>();


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
            loadSpikesTopBottom(screenWidth, screenHeight);

        }

        public void loadSpikeLeft()
        {
            int maxLeft = RandomHelper.getNextIntBetween(1, 5);
            int y = 100;
            for (int i = 0; i < maxLeft; i++)
            {
                Spike spike = new Spike(Game, _spriteBatch, new Vector2(0, y), "Sprites/Spikes/rockGrassLeft");
                spike.setLeftRectangles(y);
                spikesListLeftRight.Add(spike);
                y += 50 * RandomHelper.getNextIntBetween(1, 4);
            }
        }

        public void loadSpikeRight()
        {
            int maxRight = RandomHelper.getNextIntBetween(1, 5);
            int y = 100;
            for (int i = 0; i < maxRight; i++)
            {
                Spike spike = new Spike(Game, _spriteBatch, new Vector2(screenWidth - 100, y), "Sprites/Spikes/rockGrassRight");
                spike.setRightRectangles(y);
                spikesListLeftRight.Add(spike);
                y += 50 * RandomHelper.getNextIntBetween(1, 4);
            }
        }

        private void loadSpikesTopBottom(int screenWidth, int screenHeight)
        {
            for (int i = 0; i < screenWidth; i += 45)
            {
                spikesListTopBottom.Add(new Spike(Game, _spriteBatch, new Vector2(i, screenHeight - 100), "Sprites/Spikes/rockGrass"));
            }

            for (int i = 0; i < screenWidth; i += 45)
            {
                spikesListTopBottom.Add(new Spike(Game, _spriteBatch, new Vector2(i, 0), "Sprites/Spikes/rockGrassDown"));
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            foreach(var spike in spikesListTopBottom)
            {
                spike.Update(gameTime);
            }
            if (spikesListLeftRight.Count != 0)
            {
                foreach (var spike in spikesListTopBottom)
                {
                    spike.Update(gameTime);
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            foreach (var spike in spikesListTopBottom)
            {
                spike.Draw(gameTime);
            }
            if(spikesListLeftRight.Count != 0)
            {
                foreach (var spike in spikesListLeftRight)
                {
                    spike.Draw(gameTime);
                }
            }
        }
    }
}
