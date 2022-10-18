// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0f, and less than 1.0f.
        /// </summary>
        /// <param name="randomizer">The given <see cref="ITypedRandomizer{T}"/> instance.</param>
        /// <returns>A <see cref="float"/>-precision floating point number that is greater than or equal to 0.0f, and less than 1.0f.</returns>
        public static float NextFloat(this ITypedRandomizer<double> randomizer) => (float) randomizer.Next();

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to minValue, and less than maxValue.
        /// </summary>
        /// <param name="randomizer">The given <see cref="ITypedRandomizer{T}"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A <see cref="float"/>-precision floating point number that is greater than or equal to <paramref name="minInclusive"/>,
        /// and less than <paramref name="maxExclusive"/>.
        /// </returns>
        public static float NextFloat(this ITypedRandomizer<double> randomizer, float minInclusive,
            float maxExclusive = float.MaxValue)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return (float) randomizer.NextDouble(minInclusive, maxExclusive);
        }

        public static float NextPositiveFloat(this ITypedRandomizer<double> randomizer,
            float maxExclusive = float.MaxValue) =>
            NextFloat(randomizer, 1, maxExclusive);

        public static float NextNegativeFloat(this ITypedRandomizer<double> randomizer,
            float minInclusive = float.MinValue) =>
            NextFloat(randomizer, minInclusive, -1);

    }
}