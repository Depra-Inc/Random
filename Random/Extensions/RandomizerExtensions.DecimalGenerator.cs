using Depra.Random.Randomizers;

namespace Depra.Random.Extensions
{
    public static partial class RandomizerExtensions
    {
        internal static class DecimalGenerator
        {
            // Provides a random decimal value in the range [0.0000000000000000000000000000, 0.9999999999999999999999999999)
            // with (theoretical) uniform and discrete distribution.
            public static decimal GenerateDecimal(IRandomizer random, decimal maxValue = decimal.MaxValue) =>
                GenerateDecimal(random, decimal.Zero, maxValue);

            public static decimal GenerateDecimal(IRandomizer random, decimal minInclusive, decimal maxExclusive)
            {
                var nextDecimalSample = GenerateDecimalSample(random);
                return maxExclusive * nextDecimalSample + minInclusive * (1 - nextDecimalSample);
            }

            private static decimal GenerateDecimalSample(IRandomizer random)
            {
                var sample = 1m;
                // After ~200 million tries this never took more than one attempt but it is possible to
                // generate combinations of a, b, and c with the approach below resulting in a sample >= 1.
                while (sample >= 1)
                {
                    var a = random.Next();
                    var b = random.Next();
                    // The high bits of 0.9999999999999999999999999999m are 542101086.
                    var c = random.Next(542101087);
                    sample = new decimal(a, b, c, false, 28);
                }

                return sample;
            }
        }
    }
}