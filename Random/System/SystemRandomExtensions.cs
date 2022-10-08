using System.Collections.Generic;
using System.Linq;

namespace Depra.Random.System
{
    public static class SystemRandomExtensions
    {
        public static long NextLong(this global::System.Random random, long minInclusive = long.MinValue,
            long maxExclusive = long.MaxValue)
        {
            var result = (long) random.Next((int) (minInclusive >> 32), (int) (maxExclusive >> 32));
            result <<= 32;
            result |= (uint) random.Next((int) minInclusive, (int) maxExclusive);

            return result;
        }

        public static double NextDouble(this global::System.Random random, double minInclusive = double.MinValue,
            double maxExclusive = double.MaxValue)
        {
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