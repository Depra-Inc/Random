// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a random <see cref="double"/> that is greater than or equal to <paramref name="minInclusive"/>,
        /// and less than <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="ITypedRandomizer{T}"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>A <see cref="double"/>-precision floating point number that is greater than or equal to <paramref name="minInclusive"/>,
        /// and less than <paramref name="maxExclusive"/>.</returns>
        public static double NextDouble(this ITypedRandomizer<double> randomizer, double minInclusive = 0.0,
            double maxExclusive = double.MaxValue)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            var sample = randomizer.Next();
            return maxExclusive * sample + minInclusive * (1d - sample);
        }

        public static double NextPositiveDouble(this ITypedRandomizer<double> randomizer,
            double maxExclusive = double.MaxValue) =>
            NextDouble(randomizer, 1, maxExclusive);

        public static double NextNegativeDouble(this ITypedRandomizer<double> randomizer,
            double minInclusive = double.MinValue) =>
            NextDouble(randomizer, minInclusive, -1);
        
        /// <summary>
        /// <see href="https://stackoverflow.com/questions/218060/random-gaussian-variables">source</see>
        /// </summary>
        public static double NextGaussian(this ITypedRandomizer<int> random, double mu = 0, double sigma = 1)
        {
            // Uniform(0,1] random doubles.
            var u1 = 1.0 - random.Next();
            var u2 = 1.0 - random.Next();

            // Random normal(0,1).
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);

            // Random normal(mean,stdDev^2).
            var randNormal = mu + sigma * randStdNormal;

            return randNormal;
        }
    }
}