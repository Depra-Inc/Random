using System;
using System.Linq;
using Depra.Random.Internal.Exceptions;

namespace Depra.Random.System
{
    public static class SystemRandomNumericExtensions
    {
        #region Double

        /// <summary>
        /// Returns a random <see cref="double"/> that is greater than or equal to <see cref="minInclusive"/>, and less than <see cref="maxExclusive"/>.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>A <see cref="double"/>-precision floating point number that is greater than or equal to <see cref="minInclusive"/>, and less than <see cref="maxExclusive"/>.</returns>
        public static double NextDouble(this global::System.Random random, double minInclusive = 0.0,
            double maxExclusive = double.MaxValue)
        {
            if (minInclusive > maxExclusive)
            {
                throw new RandomArgumentOutOfRangeException(minInclusive, nameof(maxExclusive));
            }

            var sample = random.NextDouble();
            return maxExclusive * sample + minInclusive * (1d - sample);
        }

        #endregion

        #region Float

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0f, and less than 1.0f.
        /// </summary>
        /// <param name="rand">The given <see cref="Random"/> instance.</param>
        /// <returns>A <see cref="Single"/>-precision floating point number that is greater than or equal to 0.0f, and less than 1.0f.</returns>
        public static float NextFloat(this global::System.Random rand) => (float) rand.NextDouble();

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to minValue, and less than maxValue.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>A <see cref="Single"/>-precision floating point number that is greater than or equal to <see cref="minInclusive"/>, and less than <see cref="maxExclusive"/>.</returns>
        public static float NextFloat(this global::System.Random random, float minInclusive,
            float maxExclusive = float.MaxValue)
        {
            if (minInclusive > maxExclusive)
            {
                throw new RandomArgumentOutOfRangeException(minInclusive, nameof(maxExclusive));
            }

            return (float) random.NextDouble(minInclusive, maxExclusive);
        }

        #endregion

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

        #region Byte

        /// <summary>
        /// Returns a random <see cref="byte"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="maxExclusive">The exclusive upper bound of the random number returned. <see cref="maxExclusive"/> must be greater than or equal to 0.</param>
        /// <returns>
        /// A 8-bit unsigned integer that is greater than or equal to 0 and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <see cref="maxExclusive"/>.
        /// However, if <see cref="maxExclusive"/> equals 0, <see cref="maxExclusive"/> is return.
        /// </returns>
        public static byte NextByte(this global::System.Random random, byte maxExclusive = byte.MaxValue) =>
            (byte) random.Next(maxExclusive);

        /// <summary>
        /// Returns a random <see cref="byte"/> that is within a specified range.
        /// </summary>
        /// <param name="rand">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>
        /// A 8-bit unsigned integer greater than or equal to <see cref="minInclusive"/> and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values includes <see cref="minInclusive"/> but not <see cref="maxExclusive"/>.
        /// If <see cref="minInclusive"/> equals <see cref="maxExclusive"/>, <see cref="minInclusive"/> is returned.
        /// </returns>
        public static byte NextByte(this global::System.Random rand, byte minInclusive, byte maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                throw new RandomArgumentOutOfRangeException(minInclusive, nameof(maxExclusive));
            }

            return (byte) rand.Next(minInclusive, maxExclusive);
        }

        #endregion

        #region SByte

        /// <summary>
        /// Returns a non-negative random <see cref="sbyte"/>.
        /// </summary>
        /// <param name="rand">The given <see cref="Random"/> instance.</param>
        /// <returns>A 8-bit signed integer that is greater than or equal to 0 and less than <see cref="sbyte.MaxValue"/>.</returns>
        public static sbyte NextSByte(this global::System.Random rand) => (sbyte) rand.Next(sbyte.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="sbyte"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="maxExclusive">The exclusive upper bound of the random number returned. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 8-bit signed integer that is greater than or equal to 0 and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <see cref="maxExclusive"/>.
        /// However, if <see cref="maxExclusive"/> equals 0, <see cref="maxExclusive"/> is return.
        /// </returns>
        public static sbyte NextSByte(this global::System.Random random, sbyte maxExclusive)
        {
            if (maxExclusive < 0)
            {
                throw new RandomArgumentOutOfRangeException(maxExclusive, 0);
            }

            return (sbyte) random.Next(maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="sbyte"/> that is within a specified range.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>
        /// A 8-bit signed integer greater than or equal to <see cref="minInclusive"/> and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values includes <see cref="minInclusive"/> but not <see cref="maxExclusive"/>.
        /// If <see cref="minInclusive"/> equals <see cref="maxExclusive"/>, <see cref="maxExclusive"/> is returned.
        /// </returns>
        public static sbyte NextSByte(this global::System.Random random, sbyte minInclusive, sbyte maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                throw new RandomArgumentOutOfRangeException(minInclusive, nameof(maxExclusive));
            }

            return (sbyte) random.Next(minInclusive, maxExclusive);
        }

        #endregion

        #region Short

        /// <summary>
        /// Returns a non-negative random <see cref="short"/>.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <returns>A 16-bit signed integer that is greater than or equal to 0 and less than <see cref="short.MaxValue"/>.</returns>
        public static short NextShort(this global::System.Random random) => (short) random.Next(short.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="short"/> that is less than the specified <see cref="maxExclusive"/>.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. <see cref="maxExclusive"/> must be greater than or equal to 0.</param>
        /// <returns>
        /// A 16-bit signed integer that is greater than or equal to 0 and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <see cref="maxExclusive"/>.
        /// However, if <see cref="maxExclusive"/> equals 0, <see cref="maxExclusive"/> is return.
        /// </returns>
        public static short NextShort(this global::System.Random random, short maxExclusive)
        {
            if (maxExclusive < 0)
            {
                throw new RandomArgumentOutOfRangeException(maxExclusive, 0);
            }

            return (short) random.Next(maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="short"/> that is within a specified range.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>
        /// A 16-bit signed integer greater than or equal to <see cref="minInclusive"/> and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values includes <see cref="minInclusive"/> but not <see cref="maxExclusive"/>.
        /// If <see cref="minInclusive"/> equals <see cref="maxExclusive"/>, <see cref="minInclusive"/> is returned.
        /// </returns>
        public static short NextShort(this global::System.Random random, short minInclusive, short maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                throw new RandomArgumentOutOfRangeException(minInclusive, nameof(maxExclusive));
            }

            return (short) random.Next(minInclusive, maxExclusive);
        }

        #endregion

        #region UShort

        /// <summary>
        /// Returns a random <see cref="ushort"/>.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <returns>A 16-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ushort.MaxValue"/>.</returns>
        public static ushort NextUShort(this global::System.Random random) =>
            (ushort) random.Next(ushort.MaxValue);

        /// <summary>
        /// Returns a random <see cref="ushort"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 16-bit unsigned integer that is greater than or equal to 0 and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <see cref="maxExclusive"/>.
        /// However, if <see cref="maxExclusive"/> equals 0, <see cref="maxExclusive"/> is return.
        /// </returns>
        public static ushort NextUShort(this global::System.Random random, ushort maxExclusive) =>
            (ushort) random.Next(maxExclusive);

        /// <summary>
        /// Returns a random <see cref="ushort"/> that is within a specified range.
        /// </summary>
        /// <param name="rand">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>
        /// A 16-bit unsigned integer greater than or equal to <see cref="minInclusive"/> and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values includes <see cref="minInclusive"/> but not <see cref="maxExclusive"/>.
        /// If <see cref="minInclusive"/> equals <see cref="maxExclusive"/>, <see cref="minInclusive"/> is returned.
        /// </returns>
        public static ushort NextUShort(this global::System.Random rand, ushort minInclusive, ushort maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                throw new RandomArgumentOutOfRangeException(minInclusive, nameof(maxExclusive));
            }

            return (ushort) rand.Next(minInclusive, maxExclusive);
        }

        #endregion

        #region UInt

        /// <summary>
        /// Returns a random <see cref="uint"/>.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="uint.MaxValue"/>.</returns>
        public static uint NextUInt(this global::System.Random random)
        {
            var buffer = new byte[4];
            random.NextBytes(buffer);

            return BitConverter.ToUInt32(buffer, 0);
        }

        /// <summary>
        /// Returns a random <see cref="uint"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <see cref="maxExclusive"/>.
        /// However, if <see cref="maxExclusive"/> equals 0, <see cref="maxExclusive"/> is return.
        /// </returns>
        public static uint NextUInt(this global::System.Random random, uint maxExclusive) =>
            random.NextUInt(uint.MinValue, maxExclusive);

        /// <summary>
        /// Returns a random <see cref="uint"/> that is within a specified range.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>
        /// A 32-bit unsigned integer greater than or equal to <see cref="minInclusive"/> and less than <see cref="maxExclusive"/>.
        /// That is, the range of return values includes <see cref="minInclusive"/> but not <see cref="maxExclusive"/>.
        /// If <see cref="minInclusive"/> equals <see cref="maxExclusive"/>, <see cref="minInclusive"/> is returned.
        /// </returns>
        public static uint NextUInt(this global::System.Random random, uint minInclusive, uint maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                throw new RandomArgumentOutOfRangeException(minInclusive, nameof(maxExclusive));
            }

            if (minInclusive == maxExclusive)
            {
                return minInclusive;
            }

            var range = maxExclusive - minInclusive;
            var bias = uint.MaxValue - uint.MaxValue % range;
            uint result;

            do
            {
                result = random.NextUInt();
            } while (result >= bias);

            return result % range + minInclusive;
        }

        #endregion

        #region ULong

        /// <summary>
        /// Returns a random <see cref="ulong"/>.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
        public static ulong NextULong(this global::System.Random random)
        {
            var buffer = new byte[8];
            random.NextBytes(buffer);

            return BitConverter.ToUInt64(buffer, 0);
        }

        /// <summary>
        /// Returns a random <see cref="ulong"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
        public static ulong NextULong(this global::System.Random random, ulong maxExclusive) =>
            random.NextULong(ulong.MinValue, maxExclusive);

        /// <summary>
        /// Returns a random <see cref="ulong"/> that is within a specified range.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
        public static ulong NextULong(this global::System.Random random, ulong minInclusive, ulong maxExclusive)
        {
            var uRange = maxExclusive - minInclusive;
            if (uRange <= 0)
            {
                throw new RandomArgumentOutOfRangeException(uRange, 0, true);
            }

            var limit = ulong.MaxValue - ulong.MaxValue % uRange;
            ulong ulongRand;
            do
            {
                ulongRand = random.NextULong();
            } while (ulongRand > limit);

            return ulongRand % uRange + minInclusive;
        }

        #endregion

        #region Long

        /// <summary>
        /// Returns a non-negative random <see cref="long"/>.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <returns>A 64-bit signed integer that is greater than or equal to 0 and less than <see cref="long.MaxValue"/>.</returns>
        public static long NextLong(this global::System.Random random) =>
            (long) random.NextULong(long.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="long"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="maxExclusive">The exclusive upper bound of the random number returned. maxValue must be greater than or equal to 0.</param>
        /// <returns>A 64-bit signed integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static long NextLong(this global::System.Random random, long maxExclusive)
        {
            if (maxExclusive < 0)
            {
                throw new RandomArgumentOutOfRangeException(maxExclusive, 0);
            }

            return (long) random.NextULong((ulong) maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="long"/> that is greater than or equal to <see cref="minInclusive"/>, and less than <see cref="maxExclusive"/>.
        /// </summary>
        /// <param name="random">The given <see cref="Random"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <see cref="minInclusive"/>.</param>
        /// <returns>A 64-bit signed integer that is greater than or equal to <see cref="minInclusive"/>, and less than <see cref="maxExclusive"/>.</returns>
        public static long NextLong(this global::System.Random random, long minInclusive, long maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                throw new RandomArgumentOutOfRangeException(minInclusive, nameof(maxExclusive));
            }

            // Working with ulong so that modulo works correctly with values > long.MaxValue.
            var uRange = (ulong) (maxExclusive - minInclusive);
            // Prevent a modulo bias; see https://stackoverflow.com/a/10984975/238419 for more information.
            // In the worst case, the expected number of calls is 2 (though usually it's
            // much closer to 1) so this loop doesn't really hurt performance at all.
            var limit = ulong.MaxValue - ((ulong.MaxValue % uRange) + 1) % uRange;
            ulong ulongRand;
            do
            {
                ulongRand = random.NextULong();
            } while (ulongRand > limit);

            return (long) (ulongRand % uRange) + minInclusive;
        }

        #endregion
    }
}