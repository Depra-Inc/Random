// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.Services
{
    public static class RandomServiceExtensions
    {
        public static ITypedRandomizer<T> GetTypedRandomizer<T>(this IRandomService randomService) =>
            (ITypedRandomizer<T>) randomService.GetRandomizer(typeof(T));

        public static INumberRandomizer<T> GetNumberRandomizer<T>(this IRandomService randomService) =>
            (INumberRandomizer<T>) randomService.GetRandomizer(typeof(T));

        public static IArrayRandomizer<T> GetArrayRandomizer<T>(this IRandomService randomService) =>
            (IArrayRandomizer<T>) randomService.GetRandomizer(typeof(T));
    }
}