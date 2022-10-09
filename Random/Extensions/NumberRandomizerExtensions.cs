using System;
using System.Threading.Tasks;
using Depra.Random.Randomizers;

namespace Depra.Random.Extensions
{
    public static class NumberRandomizerExtensions
    {
        public static async Task<T> NextAsync<T>(this INumberRandomizer<T> randomizer,
            T minInclusive, T maxExclusive) =>
            await Task.Run(() => randomizer.Next(minInclusive, maxExclusive))
                .ConfigureAwait(false);

        /// <summary>
        /// Generate random string of <paramref name="length"/> for <paramref name="charset"/>.
        /// </summary>
        /// <remarks>
        /// <see href="https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings">source</see>
        /// </remarks>
        public static string NextString(this INumberRandomizer<int> randomizer, int length, string charset)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (string.IsNullOrEmpty(charset))
            {
                throw new ArgumentException(nameof(charset));
            }

            var randomString = new char[length];
            for (var i = 0; i < length; i++)
            {
                randomString[i] = charset[randomizer.NextPositive(charset.Length)];
            }

            return new string(randomString);
        }

        public static byte GenerateByteKey(this INumberRandomizer<int> randomizer) =>
            (byte) randomizer.Next(100, 255);

        public static sbyte GenerateSByteKey(this INumberRandomizer<int> randomizer) =>
            (sbyte) randomizer.Next(100, 127);

        public static char GenerateCharKey(this INumberRandomizer<int> randomizer) =>
            (char) randomizer.Next(10000, 60000);
    }
}