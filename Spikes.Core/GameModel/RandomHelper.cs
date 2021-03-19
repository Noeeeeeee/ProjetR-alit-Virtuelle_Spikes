using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    public static class RandomHelper
    {
        private static readonly Random Random = new Random();

        public static int getNextInt(int i)
        {
            return Random.Next(i);
        }

        public static int getNextIntBetween(int i, int y)
        {
            return Random.Next(i, y);
        }
    }
}
