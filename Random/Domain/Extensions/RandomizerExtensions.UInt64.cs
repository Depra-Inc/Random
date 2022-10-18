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
        /// Returns a random <see cref="ulong"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IArrayRandomizer{T}"/> instance.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
        public static ulong NextULong(this IArrayRandomizer<byte[]> randomizer)
        {
            var buffer = new byte[8];
            randomizer.Next(buffer);

            return BitConverter.ToUInt64(buffer, 0);
        }

        /// <summary>
        /// Returns a random <see cref="ulong"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IArrayRandomizer{T}"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
        public static ulong NextULong(this IArrayRandomizer<byte[]> randomizer, ulong maxExclusive) =>
            randomizer.NextULong(ulong.MinValue, maxExclusive);

        /// <summary>
        /// Returns a random <see cref="ulong"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IArrayRandomizer{T}"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
        public static ulong NextULong(this IArrayRandomizer<byte[]> randomizer, ulong minInclusive, ulong maxExclusive)
        {
            var uRange = maxExclusive - minInclusive;
            if (uRange <= 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            var limit = ulong.MaxValue - ulong.MaxValue % uRange;
            ulong ulongRand;
            do
            {
                ulongRand = randomizer.NextULong();
            } while (ulongRand > limit);

            return ulongRand % uRange + minInclusive;
        }
    }
}