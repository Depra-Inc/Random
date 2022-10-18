// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Return random element.
        /// </summary>
        /// <param name="elements">List to get element of type <see cref="T"/>.</param>
        /// <param name="randomizer">The given <see cref="INumberRandomizer{T}"/> instance.</param>
        /// <typeparam name="T">Type of elements in array.</typeparam>
        /// <returns>Random <see cref="T"/>.</returns>
        public static T GetRandomElement<T>(this IList<T> elements, INumberRandomizer<int> randomizer)
        {
            return elements.Count == 0
                ? default
                : elements[randomizer.Next(0, elements.Count)];
        }
    }
}