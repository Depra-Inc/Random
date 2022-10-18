// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;
using Depra.Random.Extensions;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a non-negative random <see cref="long"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IArrayRandomizer{T}"/> instance.</param>
        /// <returns>A 64-bit signed integer that is greater than or equal to 0 and less than <see cref="long.MaxValue"/>.</returns>
        public static long NextLong(this IArrayRandomizer<byte[]> randomizer) =>
            (long) randomizer.NextULong(long.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="long"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IArrayRandomizer{T}"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>A 64-bit signed integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static long NextLong(this IArrayRandomizer<byte[]> randomizer, long maxExclusive)
        {
            if (maxExclusive < 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            return (long) randomizer.NextULong((ulong) maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="long"/> that is greater than or equal to <paramref name="minInclusive"/>, and less than <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IArrayRandomizer{T}"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 64-bit signed integer that is greater than or equal to <paramref name="minInclusive"/>, and less than <paramref name="maxExclusive"/>.
        /// </returns>
        public static long NextLong(this IArrayRandomizer<byte[]> randomizer, long minInclusive, long maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            // Working with ulong so that modulo works correctly with values > long.MaxValue.
            var uRange = (ulong) (maxExclusive - minInclusive);
            // Prevent a modulo bias; see https://stackoverflow.com/a/10984975/238419 for more information.
            // In the worst case, the expected number of calls is 2 (though usually it's
            // much closer to 1) so this loop doesn't really hurt performance at all.
            var limit = ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange;
            ulong ulongRand;
            do
            {
                ulongRand = randomizer.NextULong();
            } while (ulongRand > limit);

            return (long) (ulongRand % uRange) + minInclusive;
        }

        public static long NextPositiveLong(this IArrayRandomizer<byte[]> randomizer,
            long maxExclusive = long.MaxValue) => NextLong(randomizer, 1, maxExclusive);

        public static long NextNegativeLong(this IArrayRandomizer<byte[]> randomizer,
            long minInclusive = long.MinValue) => NextLong(randomizer, minInclusive, -1);
    }
}