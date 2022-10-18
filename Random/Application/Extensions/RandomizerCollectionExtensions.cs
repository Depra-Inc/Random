// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.Extensions
{
    internal static class RandomizerCollectionExtensions
    {
        public static ITypedRandomizer<T> GetTypedRandomizer<T>(this IRandomizerCollection randomizerCollection) =>
            (ITypedRandomizer<T>) randomizerCollection.GetRandomizer(typeof(T));

        public static INumberRandomizer<T> GetNumberRandomizer<T>(this IRandomizerCollection randomizerCollection) =>
            (INumberRandomizer<T>) randomizerCollection.GetRandomizer(typeof(T));

        public static IArrayRandomizer<T> GetArrayRandomizer<T>(this IRandomizerCollection randomizerCollection) =>
            (IArrayRandomizer<T>) randomizerCollection.GetRandomizer(typeof(T));
    }
}