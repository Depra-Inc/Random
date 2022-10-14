using System;
using Depra.Random.Randomizers;

namespace Depra.Random.Extensions
{
    /// <summary>
    /// <see cref="Array"/> extensions.
    /// </summary>
    public static class ArrayRandomExtensions
    {
        /// <summary>
        /// Shuffles an array of elements.
        /// </summary>
        /// <param name="array">Array to get element of type <see cref="T"/>.</param>
        /// <param name="randomizer">Randomizer for <see cref="int"/>.</param>
        /// <typeparam name="T">Type of elements in array.</typeparam>
        public static void Shuffle<T>(this T[] array, IRandomizer randomizer)
        {
            if (array.Length < 1)
            {
                return;
            }

            var n = array.Length;
            while (n > 1)
            {
                var k = randomizer.Next(0, n--);
                (array[n], array[k]) = (array[k], array[n]);
            }
        }
    }
}