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

                return integers.Select(i => (char) i).ToList();
            }
        }
    }
}