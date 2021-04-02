using System;
using System.Collections.Generic;
using System.Text;

namespace Spikes.Core.GameModel
{
    /// <summary>
    /// Class which generate random values
    /// </summary>
    public static class RandomHelper
    {
        private static readonly Random Random = new Random();

        /// <summary>
        /// generate an int between 0 and i
        /// </summary>
        /// <param name="i">max value</param>
        /// <returns>int </returns>
        public static int getNextInt(int i)
        {
            return Random.Next(i);
        }

        /// <summary>
        /// generate an int between i and y
        /// </summary>
        /// <param name="i">min value</param>
        /// <param name="y">max value</param>
        /// <returns>int value</returns>
        public static int getNextIntBetween(int i, int y)
        {
            return Random.Next(i, y);
        }
    }
}
