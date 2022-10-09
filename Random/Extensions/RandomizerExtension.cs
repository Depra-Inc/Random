using System;
using System.Threading.Tasks;
using Depra.Random.Randomizers;

namespace Depra.Random.Extensions
{
    /// <summary>
    /// <see cref="Random"/> extensions.
    /// </summary>
    public static class RandomizerExtension
    {
        public static async Task<T> NextAsync<T>(this IRandomizer<T> randomizer) =>
            await Task.Run(randomizer.Next).ConfigureAwait(false);

        /// <summary>
        /// <see href="https://stackoverflow.com/questions/218060/random-gaussian-variables">source</see>
        /// </summary>
        public static double NextGaussian(this IRandomizer<double> randomizer, double mu = 0, double sigma = 1)
        {
            // Uniform(0,1] random doubles.
            var u1 = 1.0 - randomizer.Next();
            var u2 = 1.0 - randomizer.Next();

            // Random normal(0,1).
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);

            // Random normal(mean,stdDev^2).
            var randNormal = mu + sigma * randStdNormal;

            return randNormal;
        }

        /// <summary>
        /// Generate random double between <paramref name="minValue"/> and <paramref name="maxValue"/>.
        /// <para></para>
        /// Note: This is a scaled implementation: (random.nextDouble() * (max - min)) + min
        /// </summary>
        /// <remarks>
        /// <see href="https://stackoverflow.com/questions/1064901/random-number-between-2-double-numbers">source</see>
        /// </remarks>
        public static double NextDouble(this IRandomizer<double> randomizer, double minValue = 0d,
            double maxValue = double.MaxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue), "'minValue' cannot be greater than 'maxValue'");
            }

            // Scaled.
            return randomizer.NextDouble() * (maxValue - minValue) + minValue;
        }

        /// <summary>
        /// Generate random decimal between <paramref name="minValue"/> and <paramref name="maxValue"/>.
        /// <para></para>
        /// Note: This is a scaled implementation: (random.nextDouble() * (max - min)) + min
        /// </summary>
        /// <remarks>
        /// <see href="https://stackoverflow.com/questions/609501/generating-a-random-decimal-in-c-sharp">source</see>
        /// </remarks>
        public static decimal NextDecimal(this IRandomizer<double> randomizer, decimal minValue = decimal.Zero,
            decimal maxValue = decimal.MaxValue)
        {
            if (minValue > maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(minValue), "'minValue' cannot be greater than 'maxValue'");
            }

            // Scaled.
            return (decimal) randomizer.Next() * (maxValue - minValue) + minValue;
        }

        public static float NextFloat(this IRandomizer<double> randomizer) => (float) randomizer.Next();

        public static float NextFloat(this IRandomizer<float> randomizer, float min, float max) =>
            randomizer.Next() * (max - min) + min;

        public static float NextPositiveFloat(this IRandomizer<double> randomizer) => (float) randomizer.NextDouble();
    }
}