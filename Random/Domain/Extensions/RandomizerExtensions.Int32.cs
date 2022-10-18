// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        public static int NextPositiveInt(this INumberRandomizer<int> randomizer, int maxExclusive = int.MaxValue) =>
            randomizer.Next(1, maxExclusive);

        public static int NextNegativeInt(this INumberRandomizer<int> randomizer, int minInclusive = int.MinValue) =>
            randomizer.Next(minInclusive, -1);
    }
}