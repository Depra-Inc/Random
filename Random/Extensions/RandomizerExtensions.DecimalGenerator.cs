using System.Linq;
using Depra.Random.Randomizers;

namespace Depra.Random.Extensions
{
    public static partial class RandomizerExtensions
    {
        internal static class DecimalGenerator
        {
            public static decimal GenerateDecimal(IRandomizer randomizer)
            {
                var values = Enumerable.Range(0, 29)
                    .Select(x => randomizer.Next(10)
                        .ToString());
                
                var result = decimal.Parse($"0.{string.Join(string.Empty, values)}");
                return result / 1.000000000000000000000000000000000m;
            }

            public static decimal GenerateDecimal(IRandomizer randomizer, decimal minInclusive, decimal maxExclusive) =>
                randomizer.NextDecimal() * (maxExclusive - minInclusive) + minInclusive;
        }
    }
}