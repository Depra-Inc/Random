// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Domain.Extensions
{
    public static partial class RandomizerExtensions
    {
        public static TEnum NextEnum<TEnum>(this INumberRandomizer<int> randomizer) where TEnum : struct, Enum
        {
#if NET5_0_OR_GREATER
            var values = Enum.GetValues<TEnum>();
            return values[random.Next(values.Length)];
#else
            return (TEnum) NextEnum(randomizer, typeof(TEnum));
#endif
        }

        private static object NextEnum(this INumberRandomizer<int> randomizer, Type enumType)
        {
            var values = Enum.GetValues(enumType);
            var randomIndex = randomizer.Next(values.Length);
            var randomEnum = values.GetValue(randomIndex);

            return randomEnum;
        }
    }
}