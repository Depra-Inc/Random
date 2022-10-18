// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a random <see cref="uint"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="uint.MaxValue"/>.</returns>
        public static uint NextUInt(this INumberRandomizer<int> randomizer) => GetRandomUInt32(randomizer);

        /// <summary>
        /// Returns a random <see cref="uint"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 32-bit unsigned integer that is greater than or equal to 0 and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <paramref name="maxExclusive"/>.
        /// However, if <paramref name="maxExclusive"/> equals 0, <paramref name="maxExclusive"/> is return.
        /// </returns>
        public static uint NextUInt(this INumberRandomizer<int> randomizer, uint maxExclusive) =>
            GetRandomUInt32(randomizer, maxExclusive);

        /// <summary>
        /// Returns a random <see cref="uint"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 32-bit unsigned integer greater than or equal to <paramref name="minInclusive"/> and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values includes <paramref name="minInclusive"/> but not <paramref name="maxExclusive"/>.
        /// If <paramref name="minInclusive"/> equals <paramref name="maxExclusive"/>, <paramref name="minInclusive"/> is returned.
        /// </returns>
        public static uint NextUInt(this INumberRandomizer<int> randomizer, uint minInclusive, uint maxExclusive) =>
            GetRandomUInt32(randomizer, minInclusive, maxExclusive);
        
        public static uint GetRandomUInt32(INumberRandomizer<int> randomizer) =>
            (uint) randomizer.Next(1 << 30) << 2 | (uint) randomizer.Next(1 << 2);

        public static uint GetRandomUInt32(INumberRandomizer<int> randomizer, uint maxExclusive)
        {
            uint x;
            if (maxExclusive < int.MaxValue)
            {
                return (uint) randomizer.Next((int) maxExclusive + 1);
            }

            do
            {
                do x = (uint) randomizer.Next(1 << 30) << 2;
                while (x > maxExclusive);
                {
                    x |= (uint) randomizer.Next(1 << 2);
                }
            } while (x > maxExclusive);

            return x;
        }

        public static uint GetRandomUInt32(INumberRandomizer<int> randomizer, uint minInclusive,
            uint maxExclusive) => minInclusive < maxExclusive
            ? minInclusive + GetRandomUInt32(randomizer, maxExclusive - minInclusive)
            : maxExclusive + GetRandomUInt32(randomizer, minInclusive - maxExclusive);
    }
}