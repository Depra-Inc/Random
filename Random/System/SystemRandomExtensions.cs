using System;
using System.Linq;
using Depra.Random.Internal.Exceptions;

namespace Depra.Random.System
{
    public static class SystemRandomExtensions
    {
        /// <summary>
        /// Returns a random <see cref="bool"/> value.
        /// </summary>
        /// <param name="random">The <see cref="Random"/> instance to use.</param>
        /// <returns>A <see cref="bool"/> value that is either <see langword="true"/>&#160;or <see langword="false"/>.</returns>
        public static bool NextBoolean(this global::System.Random random) => (random.Next() & 1) == 0;
        
        #region Decimal

        /// <summary>
        /// Returns a random <see cref="decimal"/> that is greater than or equal to 0.0m, and less than 1.0m.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <returns>A <see cref="decimal"/> number that is greater than or equal to 0.0m, and less than 1.0m.</returns>
        public static decimal NextDecimal(this global::System.Random random)
        {
            var values = Enumerable.Range(0, 29).Select(x => random.Next(10).ToString());
            var result = decimal.Parse($"0.{string.Join(string.Empty, values)}");

            return result / 1.000000000000000000000000000000000m;
        }

        /// <summary>
        /// Returns a random <see cref="decimal"/> that is greater than or equal to <see cref="minInclusive"/>, and less than <see cref="maxExclusive"/>.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>A <see cref="decimal"/> number that is greater than or equal to <see cref="minInclusive"/>, and less than <see cref="maxExclusive"/>.</returns>
        public static decimal NextDecimal(this global::System.Random random, decimal minInclusive, decimal maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                throw new RandomArgumentOutOfRangeException(minInclusive, nameof(maxExclusive));
            }

            return random.NextDecimal() * (maxExclusive - minInclusive) + minInclusive;
        }

        #endregion
    }
}