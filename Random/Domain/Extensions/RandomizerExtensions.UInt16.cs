// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a random <see cref="ushort"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <returns>A 16-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ushort.MaxValue"/>.</returns>
        public static ushort NextUShort(this INumberRandomizer<int> randomizer) =>
            (ushort) randomizer.Next(ushort.MaxValue);

        /// <summary>
        /// Returns a random <see cref="ushort"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 16-bit unsigned integer that is greater than or equal to 0 and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <paramref name="maxExclusive"/>.
        /// However, if <paramref name="maxExclusive"/> equals 0, <paramref name="maxExclusive"/> is return.
        /// </returns>
        public static ushort NextUShort(this INumberRandomizer<int> randomizer, ushort maxExclusive) =>
            (ushort) randomizer.Next(maxExclusive);

        /// <summary>
        /// Returns a random <see cref="ushort"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 16-bit unsigned integer greater than or equal to <paramref name="minInclusive"/> and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values includes <paramref name="minInclusive"/> but not <paramref name="maxExclusive"/>.
        /// If <paramref name="minInclusive"/> equals <paramref name="maxExclusive"/>, <paramref name="minInclusive"/> is returned.
        /// </returns>
        public static ushort NextUShort(this INumberRandomizer<int> randomizer, ushort minInclusive, ushort maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return (ushort) randomizer.Next(minInclusive, maxExclusive);
        }
    }
}