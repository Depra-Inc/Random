// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a non-negative random <see cref="short"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <returns>A 16-bit signed integer that is greater than or equal to 0 and less than <see cref="short.MaxValue"/>.</returns>
        public static short NextShort(this INumberRandomizer<int> randomizer) => (short) randomizer.Next(short.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="short"/> that is less than the specified <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 16-bit signed integer that is greater than or equal to 0 and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <paramref name="maxExclusive"/>.
        /// However, if <paramref name="maxExclusive"/> equals 0, <paramref name="maxExclusive"/> is return.
        /// </returns>
        public static short NextShort(this INumberRandomizer<int> randomizer, short maxExclusive)
        {
            if (maxExclusive < 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            return (short) randomizer.Next(maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="short"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 16-bit signed integer greater than or equal to <paramref name="minInclusive"/> and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values includes <paramref name="minInclusive"/> but not <paramref name="maxExclusive"/>.
        /// If <paramref name="minInclusive"/> equals <paramref name="maxExclusive"/>, <paramref name="minInclusive"/> is returned.
        /// </returns>
        public static short NextShort(this INumberRandomizer<int> randomizer, short minInclusive, short maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return (short) randomizer.Next(minInclusive, maxExclusive);
        }

        public static short NextPositiveShort(this INumberRandomizer<int> randomizer, short maxExclusive = short.MaxValue) =>
            NextShort(randomizer, 1, maxExclusive);

        public static short NextNegativeShort(this INumberRandomizer<int> randomizer, short minInclusive = short.MinValue) =>
            NextShort(randomizer, minInclusive, -1);
    }
}