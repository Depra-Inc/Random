// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        private static uint _boolBits;
        
        /// <summary>
        /// Returns a random <see cref="bool"/> value.
        /// </summary>
        /// <param name="random">The <see cref="ITypedRandomizer{T}"/> instance to use.</param>
        /// <returns>A <see cref="bool"/> value that is either <see langword="true"/> or <see langword="false"/>.</returns>
        public static bool NextBoolean(this ITypedRandomizer<int> random)
        {
            _boolBits >>= 1;
            if (_boolBits <= 1)
            {
                _boolBits = (uint) ~random.Next();
            }

            return (_boolBits & 1) == 0;
        }

        /// <summary>
        /// Returns a random bool with the specified probability of being <see langword="true"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance to use.</param>
        /// <param name="probability">Probability argument must be in the range 0.0 to 1.0, inclusive.</param>
        /// <returns>A <see cref="bool"/> value that is either <see langword="true"/> or <see langword="false"/>.</returns>
        public static bool NextBoolean(this ITypedRandomizer<double> randomizer, double probability) =>
            randomizer.Next() < probability;
    }
}