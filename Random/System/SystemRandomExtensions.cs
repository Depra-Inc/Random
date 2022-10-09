using System;
using System.Collections.Generic;
using System.Linq;

namespace Depra.Random.System
{
    public static class SystemRandomExtensions
    {
        /// <summary>
        /// Returns a random <see cref="long"/> from min (inclusive) to max (exclusive).
        /// </summary>
        /// <param name="random">The given random instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than min.</param>
        public static long NextLong(this global::System.Random random, long minInclusive = 0,
            long maxExclusive = long.MaxValue)
        {
            if (maxExclusive <= minInclusive)
            {
                throw new ArgumentOutOfRangeException(nameof(maxExclusive), "Max must be > min!");
            }

            // Working with ulong so that modulo works correctly with values > long.MaxValue.
            var uRange = (ulong) (maxExclusive - minInclusive);

            // Prevent a modulo bias; see https://stackoverflow.com/a/10984975/238419 for more information.
            // In the worst case, the expected number of calls is 2 (though usually it's
            // much closer to 1) so this loop doesn't really hurt performance at all.
            ulong ulongRand;
            do
            {
                var buffer = new byte[8];
                random.NextBytes(buffer);
                ulongRand = (ulong) BitConverter.ToInt64(buffer, 0);
            } while (ulongRand > ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange);

            return (long) (ulongRand % uRange) + minInclusive;
        }

        /// <summary>
        /// Returns a random <see cref="double"/> from min (inclusive) to max (exclusive).
        /// </summary>
        /// <param name="random">The given random instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than min.</param>
        public static double NextDouble(this global::System.Random random, double minInclusive = double.MinValue,
            double maxExclusive = double.MaxValue)
        {
            if (maxExclusive <= minInclusive)
            {
                throw new ArgumentOutOfRangeException(nameof(maxExclusive), "Max must be > min!");
            }

            return random.NextDouble() * (maxExclusive - minInclusive) + minInclusive;
        }

        public static void NextChars(this global::System.Random random, char[] buffer)
        {
            for (var i = 0; i < buffer.Length; ++i)
            {
                // Capping to byte value here to not exceed
                // 56 bit crypto keys length requirement by
                // Apple to avoid cryptography declaration.
                buffer[i] = (char) (random.Next() % 256);
            }
        }

        public static string NextString(this global::System.Random random, int count, bool includeLowerCase) =>
            new string(random.NextChars(count, includeLowerCase).ToArray());

        public static IEnumerable<char> NextChars(this global::System.Random random, int count,
            bool includeLowerCase)
        {
            var characters = GetAvailableRandomCharacters(includeLowerCase);
            var result = Enumerable.Range(0, count)
                .Select(_ => characters[random.Next(characters.Count)]);

            return result;
        }

        private static List<char> GetAvailableRandomCharacters(bool includeLowerCase)
        {
            var integers = Enumerable.Empty<int>();
            integers = integers.Concat(Enumerable.Range('A', 26));
            integers = integers.Concat(Enumerable.Range('0', 10));

            if (includeLowerCase)
            {
                integers = integers.Concat(Enumerable.Range('a', 26));
            }

            return integers.Select(i => (char) i).ToList();
        }
    }
}