// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a random <see cref="decimal"/> that is greater than or equal to 0.0m, and less than 1.0m.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>A <see cref="decimal"/> number that is greater than or equal to 0.0m, and less than <paramref name="maxExclusive"/>.</returns>
        public static decimal NextDecimal(this INumberRandomizer<int> randomizer,
            decimal maxExclusive = decimal.MaxValue) => GenerateDecimal(randomizer, maxExclusive);

        /// <summary>
        /// Returns a random <see cref="decimal"/> that is greater than or equal to <paramref name="minInclusive"/>,
        /// and less than <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A <see cref="decimal"/> number that is greater than or equal to <paramref name="minInclusive"/>, and less than <paramref name="maxExclusive"/>.
        /// </returns>
        public static decimal NextDecimal(this INumberRandomizer<int> randomizer, decimal minInclusive,
            decimal maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return GenerateDecimal(randomizer, minInclusive, maxExclusive);
        }

        public static decimal NextPositiveDecimal(this INumberRandomizer<int> randomizer,
            decimal maxExclusive = decimal.MaxValue) => NextDecimal(randomizer, 1, maxExclusive);

        public static decimal NextNegativeDecimal(this INumberRandomizer<int> randomizer,
            decimal minInclusive = decimal.MinValue) => NextDecimal(randomizer, minInclusive, -1);

        // Provides a random decimal value in the range [0.0000000000000000000000000000, 0.9999999999999999999999999999)
        // with (theoretical) uniform and discrete distribution.
        private static decimal GenerateDecimal(INumberRandomizer<int> randomizer,
            decimal maxExclusive = decimal.MaxValue) => GenerateDecimal(randomizer, decimal.Zero, maxExclusive);

        private static decimal GenerateDecimal(INumberRandomizer<int> randomizer, decimal minInclusive,
            decimal maxExclusive)
        {
            var nextDecimalSample = GenerateDecimalSample(randomizer);
            return maxExclusive * nextDecimalSample + minInclusive * (1 - nextDecimalSample);
        }

        private static decimal GenerateDecimalSample(INumberRandomizer<int> randomizer)
        {
            var sample = 1m;
            // After ~200 million tries this never took more than one attempt but it is possible to
            // generate combinations of a, b, and c with the approach below resulting in a sample >= 1.
            while (sample >= 1)
            {
                var a = randomizer.Next();
                var b = randomizer.Next();
                // The high bits of 0.9999999999999999999999999999m are 542101086.
                var c = randomizer.Next(542101087);
                sample = new decimal(a, b, c, false, 28);
            }

            return sample;
        }
    }
}