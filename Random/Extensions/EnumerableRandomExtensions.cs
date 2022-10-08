using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Random.Randomizers;

namespace Depra.Random.Extensions
{
    public static class EnumerableRandomExtensions
    {
        /// <summary>
        /// Gets a random element of enumerable.
        /// </summary>
        /// <param name="elements">Enumerable to get element of type <see cref="T"/>.</param>
        /// <param name="randomizer">Randomizer for <see cref="int"/>.</param>
        /// <typeparam name="T">Type of elements in enumerable.</typeparam>
        /// <returns>Random <see cref="T"/>.</returns>
        public static T RandomElement<T>(this IEnumerable<T> elements, INumberRandomizer<int> randomizer)
        {
            if (elements == null)
            {
                throw new NullReferenceException("Collection is Null!");
            }

            if (elements.Any() == false)
            {
                return default;
            }

            var randomIndex = randomizer.Next(0, elements.Count());
            return elements.ElementAt(randomIndex);
        }

        public static int RandomElementCount<T>(this IReadOnlyList<T> readOnlyList, INumberRandomizer<int> randomizer,
            int min = 0, int max = -1)
        {
            if (max == -1)
            {
                max = readOnlyList.Count;
            }

            return randomizer.Next(min, max);
        }

        public static IEnumerable<T> RandomUniqueElements<T>(this IEnumerable<T> enumerable,
            INumberRandomizer<int> randomizer, int min = 0, int max = -1)
        {
            var array = enumerable.ToArray();
            var randomElementCount = array.RandomElementCount(randomizer, min, max);
            var result = array.RandomUniqueElementsWithCount(randomElementCount);

            return result;
        }

        public static IEnumerable<T> RandomUniqueElementsWithCount<T>(this IEnumerable<T> enumerable, int elementCount) =>
            enumerable.OrderBy(arg => Guid.NewGuid()).Take(elementCount);

        /// <summary>
        /// Gets a random element given its weight.
        /// </summary>
        /// <param name="enumerable">Enumerable to get an element.</param>
        /// <param name="randomizer">Randomizer for <see cref="double"/></param>
        /// <param name="weight">Method to get weights of elements.</param>
        /// <typeparam name="T">Type of elements in enumerable.</typeparam>
        /// <returns>Random element.</returns>
        /// <exception cref="Exception">Random double was more than sum of the weights.</exception>
        public static T GetWeighedRandom<T>(this IEnumerable<T> enumerable, INumberRandomizer<double> randomizer,
            Func<T, double> weight)
        {
            var array = enumerable.ToArray();
            var sum = array.Sum(weight);
            var randomValue = randomizer.Next(0, sum);

            foreach (var element in array)
            {
                randomValue -= weight(element);
                if (randomValue <= 0)
                {
                    return element;
                }
            }

            throw new Exception(
                $"Algorithm error in {nameof(GetWeighedRandom)} method {typeof(EnumerableRandomExtensions)}");
        }
    }
}