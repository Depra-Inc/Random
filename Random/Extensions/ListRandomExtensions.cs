using System.Collections.Generic;
using Depra.Random.Randomizers;

namespace Depra.Random.Extensions
{
    public static class ListRandomExtensions
    {
        /// <summary>
        /// Return random element.
        /// </summary>
        /// <param name="elements">List to get element of type <see cref="T"/>.</param>
        /// <param name="randomizer">Randomizer for <see cref="int"/>.</param>
        /// <typeparam name="T">Type of elements in array.</typeparam>
        /// <returns>Random <see cref="T"/>.</returns>
        public static T GetRandomElement<T>(this IList<T> elements, INumberRandomizer<int> randomizer)
        {
            return elements.Count == 0
                ? default
                : elements[randomizer.Next(0, elements.Count)];
        }
    }
}