// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        /// <summary>
        /// Returns a random <see cref="byte"/> array with specific lenght.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="bufferLenght">A <see cref="byte"/> array.</param>
        /// <returns></returns>
        public static byte[] NextBytes(this IArrayRandomizer<byte[]> randomizer, int bufferLenght)
        {
            var buffer = new byte[bufferLenght];
            randomizer.Next(buffer);
            return buffer;
        }
    }
}