// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections.Generic;
using System.Linq;

namespace Depra.Random.Extensions
{
    public static partial class RandomizerExtensions
    {
        internal static class CharsGenerator
        {
            public static List<char> GetAvailableRandomCharacters(bool includeLowerCase)
            {
                var integers = Enumerable.Empty<int>();
                integers = integers.Concat(Enumerable.Range('A', 26));
                integers = integers.Concat(Enumerable.Range('0', 10));

                if (includeLowerCase)
                {
                    integers = integers.Concat(Enumerable.Range('a', 26));
                }

                var characters = new List<char>();
                foreach (var i in integers)
                {
                    var character = (char) i;
                    characters.Add(character);
                }

                return characters;
            }
        }
    }
}