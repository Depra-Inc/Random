// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a non-negative random <see cref="sbyte"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <returns>A 8-bit signed integer that is greater than or equal to 0 and less than <see cref="sbyte.MaxValue"/>.</returns>
        public static sbyte NextSByte(this INumberRandomizer<int> randomizer) =>
            (sbyte) randomizer.Next(sbyte.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="sbyte"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 8-bit signed integer that is greater than or equal to 0 and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <paramref name="maxExclusive"/>.
        /// However, if <paramref name="maxExclusive"/> equals 0, <paramref name="maxExclusive"/> is return.
        /// </returns>
        public static sbyte NextSByte(this INumberRandomizer<int> randomizer, sbyte maxExclusive)
        {
            if (maxExclusive < 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            return (sbyte) randomizer.Next(maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="sbyte"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 8-bit signed integer greater than or equal to <paramref name="minInclusive"/> and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values includes <paramref name="minInclusive"/> but not <paramref name="maxExclusive"/>.
        /// If <paramref name="minInclusive"/> equals <paramref name="maxExclusive"/>, <paramref name="maxExclusive"/> is returned.
        /// </returns>
        public static sbyte NextSByte(this INumberRandomizer<int> randomizer, sbyte minInclusive, sbyte maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return (sbyte) randomizer.Next(minInclusive, maxExclusive);
        }

        public static sbyte NextPositiveSByte(this INumberRandomizer<int> randomizer, sbyte maxExclusive = sbyte.MaxValue) =>
            NextSByte(randomizer, 1, maxExclusive);

        public static sbyte NextNegativeSByte(this INumberRandomizer<int> randomizer, sbyte minInclusive = sbyte.MinValue) =>
            NextSByte(randomizer, minInclusive, -1);
    }
}