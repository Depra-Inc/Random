using System;
using System.Collections.Generic;
using System.Linq;
using Depra.Random.Internal.Exceptions;
using Depra.Random.Randomizers;

namespace Depra.Random.Extensions
{
    public static partial class RandomizerExtensions
    {
        #region SByte

        /// <summary>
        /// Returns a non-negative random <see cref="sbyte"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <returns>A 8-bit signed integer that is greater than or equal to 0 and less than <see cref="sbyte.MaxValue"/>.</returns>
        public static sbyte NextSByte(this IRandomizer randomizer) => (sbyte) randomizer.Next(sbyte.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="sbyte"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 8-bit signed integer that is greater than or equal to 0 and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <paramref name="maxExclusive"/>.
        /// However, if <paramref name="maxExclusive"/> equals 0, <paramref name="maxExclusive"/> is return.
        /// </returns>
        public static sbyte NextSByte(this IRandomizer randomizer, sbyte maxExclusive)
        {
            if (maxExclusive < 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            return (sbyte) randomizer.Next(maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="sbyte"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 8-bit signed integer greater than or equal to <paramref name="minInclusive"/> and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values includes <paramref name="minInclusive"/> but not <paramref name="maxExclusive"/>.
        /// If <paramref name="minInclusive"/> equals <paramref name="maxExclusive"/>, <paramref name="maxExclusive"/> is returned.
        /// </returns>
        public static sbyte NextSByte(this IRandomizer randomizer, sbyte minInclusive, sbyte maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return (sbyte) randomizer.Next(minInclusive, maxExclusive);
        }

        public static sbyte NextPositiveSByte(this IRandomizer randomizer, sbyte maxExclusive = sbyte.MaxValue) =>
            NextSByte(randomizer, 1, maxExclusive);

        public static sbyte NextNegativeSByte(this IRandomizer randomizer, sbyte minInclusive = sbyte.MinValue) =>
            NextSByte(randomizer, minInclusive, -1);

        #endregion

        #region Byte

        /// <summary>
        /// Returns a random <see cref="byte"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="maxExclusive">The exclusive upper bound of the random number returned. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 8-bit unsigned integer that is greater than or equal to 0 and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <paramref name="maxExclusive"/>.
        /// However, if <paramref name="maxExclusive"/> equals 0, <paramref name="maxExclusive"/> is return.
        /// </returns>
        public static byte NextByte(this IRandomizer randomizer, byte maxExclusive = byte.MaxValue) =>
            (byte) randomizer.Next(maxExclusive);

        /// <summary>
        /// Returns a random <see cref="byte"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 8-bit unsigned integer greater than or equal to <paramref name="minInclusive"/> and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values includes <paramref name="minInclusive"/> but not <paramref name="maxExclusive"/>.
        /// If <paramref name="minInclusive"/> equals <paramref name="maxExclusive"/>, <paramref name="minInclusive"/> is returned.
        /// </returns>
        public static byte NextByte(this IRandomizer randomizer, byte minInclusive, byte maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return (byte) randomizer.Next(minInclusive, maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="byte"/> array with specific lenght.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="bufferLenght">A byte array.</param>
        /// <returns></returns>
        public static byte[] NextBytes(this IRandomizer randomizer, int bufferLenght)
        {
            var buffer = new byte[bufferLenght];
            randomizer.NextBytes(buffer);
            return buffer;
        }

        #endregion

        #region Short

        /// <summary>
        /// Returns a non-negative random <see cref="short"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <returns>A 16-bit signed integer that is greater than or equal to 0 and less than <see cref="short.MaxValue"/>.</returns>
        public static short NextShort(this IRandomizer randomizer) => (short) randomizer.Next(short.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="short"/> that is less than the specified <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 16-bit signed integer that is greater than or equal to 0 and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <paramref name="maxExclusive"/>.
        /// However, if <paramref name="maxExclusive"/> equals 0, <paramref name="maxExclusive"/> is return.
        /// </returns>
        public static short NextShort(this IRandomizer randomizer, short maxExclusive)
        {
            if (maxExclusive < 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            return (short) randomizer.Next(maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="short"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 16-bit signed integer greater than or equal to <paramref name="minInclusive"/> and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values includes <paramref name="minInclusive"/> but not <paramref name="maxExclusive"/>.
        /// If <paramref name="minInclusive"/> equals <paramref name="maxExclusive"/>, <paramref name="minInclusive"/> is returned.
        /// </returns>
        public static short NextShort(this IRandomizer randomizer, short minInclusive, short maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return (short) randomizer.Next(minInclusive, maxExclusive);
        }

        public static short NextPositiveShort(this IRandomizer randomizer, short maxExclusive = short.MaxValue) =>
            NextShort(randomizer, 1, maxExclusive);

        public static short NextNegativeShort(this IRandomizer randomizer, short minInclusive = short.MinValue) =>
            NextShort(randomizer, minInclusive, -1);

        #endregion

        #region UShort

        /// <summary>
        /// Returns a random <see cref="ushort"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <returns>A 16-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ushort.MaxValue"/>.</returns>
        public static ushort NextUShort(this IRandomizer randomizer) =>
            (ushort) randomizer.Next(ushort.MaxValue);

        /// <summary>
        /// Returns a random <see cref="ushort"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 16-bit unsigned integer that is greater than or equal to 0 and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <paramref name="maxExclusive"/>.
        /// However, if <paramref name="maxExclusive"/> equals 0, <paramref name="maxExclusive"/> is return.
        /// </returns>
        public static ushort NextUShort(this IRandomizer randomizer, ushort maxExclusive) =>
            (ushort) randomizer.Next(maxExclusive);

        /// <summary>
        /// Returns a random <see cref="ushort"/> that is within a specified range.
        /// </summary>
        /// <param name="rand">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 16-bit unsigned integer greater than or equal to <paramref name="minInclusive"/> and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values includes <paramref name="minInclusive"/> but not <paramref name="maxExclusive"/>.
        /// If <paramref name="minInclusive"/> equals <paramref name="maxExclusive"/>, <paramref name="minInclusive"/> is returned.
        /// </returns>
        public static ushort NextUShort(this IRandomizer rand, ushort minInclusive, ushort maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return (ushort) rand.Next(minInclusive, maxExclusive);
        }

        #endregion

        #region Int

        public static int NextPositiveInt(this IRandomizer randomizer, int maxExclusive = int.MaxValue) =>
            randomizer.Next(1, maxExclusive);

        public static int NextNegativeInt(this IRandomizer randomizer, int minInclusive = int.MinValue) =>
            randomizer.Next(minInclusive, -1);

        #endregion

        #region UInt

        /// <summary>
        /// Returns a random <see cref="uint"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="uint.MaxValue"/>.</returns>
        public static uint NextUInt(this IRandomizer randomizer) =>
            OptimizedUInt32Randomizer.GetRandomUInt32(randomizer);

        /// <summary>
        /// Returns a random <see cref="uint"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>
        /// A 32-bit unsigned integer that is greater than or equal to 0 and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values ordinarily includes 0 but not <paramref name="maxExclusive"/>.
        /// However, if <paramref name="maxExclusive"/> equals 0, <paramref name="maxExclusive"/> is return.
        /// </returns>
        public static uint NextUInt(this IRandomizer randomizer, uint maxExclusive) =>
            OptimizedUInt32Randomizer.GetRandomUInt32(randomizer, maxExclusive);

        /// <summary>
        /// Returns a random <see cref="uint"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 32-bit unsigned integer greater than or equal to <paramref name="minInclusive"/> and less than <paramref name="maxExclusive"/>.
        /// That is, the range of return values includes <paramref name="minInclusive"/> but not <paramref name="maxExclusive"/>.
        /// If <paramref name="minInclusive"/> equals <paramref name="maxExclusive"/>, <paramref name="minInclusive"/> is returned.
        /// </returns>
        public static uint NextUInt(this IRandomizer randomizer, uint minInclusive, uint maxExclusive) =>
            OptimizedUInt32Randomizer.GetRandomUInt32(randomizer, minInclusive, maxExclusive);

        #endregion

        #region Double

        /// <summary>
        /// Returns a random <see cref="double"/> that is greater than or equal to <paramref name="minInclusive"/>,
        /// and less than <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>A <see cref="double"/>-precision floating point number that is greater than or equal to <paramref name="minInclusive"/>,
        /// and less than <paramref name="maxExclusive"/>.</returns>
        public static double NextDouble(this IRandomizer randomizer, double minInclusive = 0.0,
            double maxExclusive = double.MaxValue)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            var sample = randomizer.NextDouble();
            return maxExclusive * sample + minInclusive * (1d - sample);
        }

        public static double NextPositiveDouble(this IRandomizer randomizer, double maxExclusive = double.MaxValue) =>
            NextDouble(randomizer, 1, maxExclusive);

        public static double NextNegativeDouble(this IRandomizer randomizer, double minInclusive = double.MinValue) =>
            NextDouble(randomizer, minInclusive, -1);

        #endregion

        #region Float

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to 0.0f, and less than 1.0f.
        /// </summary>
        /// <param name="rand">The given <see cref="IRandomizer"/> instance.</param>
        /// <returns>A <see cref="Single"/>-precision floating point number that is greater than or equal to 0.0f, and less than 1.0f.</returns>
        public static float NextFloat(this IRandomizer rand) => (float) rand.NextDouble();

        /// <summary>
        /// Returns a random floating-point number that is greater than or equal to minValue, and less than maxValue.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A <see cref="Single"/>-precision floating point number that is greater than or equal to <paramref name="minInclusive"/>,
        /// and less than <paramref name="maxExclusive"/>.
        /// </returns>
        public static float NextFloat(this IRandomizer randomizer, float minInclusive,
            float maxExclusive = float.MaxValue)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return (float) randomizer.NextDouble(minInclusive, maxExclusive);
        }

        public static float NextPositiveFloat(this IRandomizer randomizer, float maxExclusive = float.MaxValue) =>
            NextFloat(randomizer, 1, maxExclusive);

        public static float NextNegativeFloat(this IRandomizer randomizer, float minInclusive = float.MinValue) =>
            NextFloat(randomizer, minInclusive, -1);

        #endregion

        #region Long

        /// <summary>
        /// Returns a non-negative random <see cref="long"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <returns>A 64-bit signed integer that is greater than or equal to 0 and less than <see cref="long.MaxValue"/>.</returns>
        public static long NextLong(this IRandomizer randomizer) =>
            (long) randomizer.NextULong(long.MaxValue);

        /// <summary>
        /// Returns a non-negative random <see cref="long"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>A 64-bit signed integer that is greater than or equal to 0 and less than maxValue; that is, the range of return values ordinarily inclueds 0 but not maxValue. However, if maxValue equals 0, maxValue is return.</returns>
        public static long NextLong(this IRandomizer randomizer, long maxExclusive)
        {
            if (maxExclusive < 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            return (long) randomizer.NextULong((ulong) maxExclusive);
        }

        /// <summary>
        /// Returns a random <see cref="long"/> that is greater than or equal to <paramref name="minInclusive"/>, and less than <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A 64-bit signed integer that is greater than or equal to <paramref name="minInclusive"/>, and less than <paramref name="maxExclusive"/>.
        /// </returns>
        public static long NextLong(this IRandomizer randomizer, long minInclusive, long maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
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
                ulongRand = randomizer.NextULong();
            } while (ulongRand > limit);

            return (long) (ulongRand % uRange) + minInclusive;
        }

        public static long NextPositiveLong(this IRandomizer randomizer, long maxExclusive = long.MaxValue) =>
            NextLong(randomizer, 1, maxExclusive);

        public static long NextNegativeLong(this IRandomizer randomizer, long minInclusive = long.MinValue) =>
            NextLong(randomizer, minInclusive, -1);

        #endregion

        #region ULong

        /// <summary>
        /// Returns a random <see cref="ulong"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
        public static ulong NextULong(this IRandomizer randomizer)
        {
            var buffer = new byte[8];
            randomizer.NextBytes(buffer);

            return BitConverter.ToUInt64(buffer, 0);
        }

        /// <summary>
        /// Returns a random <see cref="ulong"/> that is less than the specified maximum.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
        public static ulong NextULong(this IRandomizer randomizer, ulong maxExclusive) =>
            randomizer.NextULong(ulong.MinValue, maxExclusive);

        /// <summary>
        /// Returns a random <see cref="ulong"/> that is within a specified range.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>A 32-bit unsigned integer that is greater than or equal to 0 and less than <see cref="ulong.MaxValue"/>.</returns>
        public static ulong NextULong(this IRandomizer randomizer, ulong minInclusive, ulong maxExclusive)
        {
            var uRange = maxExclusive - minInclusive;
            if (uRange <= 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            var limit = ulong.MaxValue - ulong.MaxValue % uRange;
            ulong ulongRand;
            do
            {
                ulongRand = randomizer.NextULong();
            } while (ulongRand > limit);

            return ulongRand % uRange + minInclusive;
        }

        #endregion

        #region Boolean

        private static uint _boolBits;

        /// <summary>
        /// Returns a random <see cref="bool"/> value.
        /// </summary>
        /// <param name="randomizer">The <see cref="IRandomizer"/> instance to use.</param>
        /// <returns>A <see cref="bool"/> value that is either <see langword="true"/> or <see langword="false"/>.</returns>
        public static bool NextBoolean(this IRandomizer randomizer)
        {
            _boolBits >>= 1;
            if (_boolBits <= 1)
            {
                _boolBits = (uint) ~randomizer.Next();
            }

            return (_boolBits & 1) == 0;
        }

        /// <summary>
        /// Returns a random bool with the specified probability of being <see langword="true"/>.
        /// </summary>
        /// <param name="randomizer">The <see cref="IRandomizer"/> instance to use.</param>
        /// <param name="probability">Probability argument must be in the range 0.0 to 1.0, inclusive.</param>
        /// <returns>A <see cref="bool"/> value that is either <see langword="true"/> or <see langword="false"/>.</returns>
        public static bool NextBoolean(this IRandomizer randomizer, double probability) =>
            randomizer.NextDouble() < probability;

        #endregion

        #region Decimal

        /// <summary>
        /// Returns a random <see cref="decimal"/> that is greater than or equal to 0.0m, and less than 1.0m.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to 0.</param>
        /// <returns>A <see cref="decimal"/> number that is greater than or equal to 0.0m, and less than <paramref name="maxExclusive"/>.</returns>
        public static decimal NextDecimal(this IRandomizer randomizer, decimal maxExclusive = decimal.MaxValue) =>
            DecimalGenerator.GenerateDecimal(randomizer, maxExclusive);

        /// <summary>
        /// Returns a random <see cref="decimal"/> that is greater than or equal to <paramref name="minInclusive"/>,
        /// and less than <paramref name="maxExclusive"/>.
        /// </summary>
        /// <param name="randomizer">The given <see cref="IRandomizer"/> instance.</param>
        /// <param name="minInclusive">The inclusive minimum bound.</param>
        /// <param name="maxExclusive">The exclusive maximum bound. Must be greater than or equal to <paramref name="minInclusive"/>.</param>
        /// <returns>
        /// A <see cref="decimal"/> number that is greater than or equal to <paramref name="minInclusive"/>, and less than <paramref name="maxExclusive"/>.
        /// </returns>
        public static decimal NextDecimal(this IRandomizer randomizer, decimal minInclusive, decimal maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            return DecimalGenerator.GenerateDecimal(randomizer, minInclusive, maxExclusive);
        }

        public static decimal
            NextPositiveDecimal(this IRandomizer randomizer, decimal maxExclusive = decimal.MaxValue) =>
            NextDecimal(randomizer, 1, maxExclusive);

        public static decimal
            NextNegativeDecimal(this IRandomizer randomizer, decimal minInclusive = decimal.MinValue) =>
            NextDecimal(randomizer, minInclusive, -1);

        #endregion

        #region Gaussian

        /// <summary>
        /// <see href="https://stackoverflow.com/questions/218060/random-gaussian-variables">source</see>
        /// </summary>
        public static double NextGaussian(this IRandomizer randomizer, double mu = 0, double sigma = 1)
        {
            // Uniform(0,1] random doubles.
            var u1 = 1.0 - randomizer.Next();
            var u2 = 1.0 - randomizer.Next();

            // Random normal(0,1).
            var randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) *
                                Math.Sin(2.0 * Math.PI * u2);

            // Random normal(mean,stdDev^2).
            var randNormal = mu + sigma * randStdNormal;

            return randNormal;
        }

        #endregion

        #region Enum

        public static TEnum NextEnum<TEnum>(this IRandomizer randomizer) where TEnum : struct, Enum
        {
#if NET5_0_OR_GREATER
            var values = Enum.GetValues<TEnum>();
            return values[random.Next(values.Length)];
#else
            return (TEnum) NextEnum(randomizer, typeof(TEnum));
#endif
        }

        private static object NextEnum(this IRandomizer randomizer, Type enumType)
        {
            var values = Enum.GetValues(enumType);
            var randomIndex = randomizer.Next(values.Length);
            var randomEnum = values.GetValue(randomIndex);

            return randomEnum;
        }

        #endregion

        #region String

        public static string NextString(this IRandomizer randomizer, int length, bool includeLowerCase) =>
            new string(randomizer.NextChars(length, includeLowerCase).ToArray());

        /// <summary>
        /// Generate random string of <paramref name="length"/> for <paramref name="charset"/>.
        /// </summary>
        /// <remarks>
        /// <see href="https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings">source</see>
        /// </remarks>
        public static string NextString(this IRandomizer randomizer, int length, string charset)
        {
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }

            if (string.IsNullOrEmpty(charset))
            {
                throw new ArgumentException(nameof(charset));
            }

            var randomString = new char[length];
            for (var i = 0; i < length; i++)
            {
                randomString[i] = charset[randomizer.Next(charset.Length)];
            }

            return new string(randomString);
        }

        #endregion

        #region Chars

        public static void NextChars(this IRandomizer randomizer, char[] buffer)
        {
            for (var i = 0; i < buffer.Length; ++i)
            {
                // Capping to byte value here to not exceed
                // 56 bit crypto keys length requirement by
                // Apple to avoid cryptography declaration.
                buffer[i] = (char) (randomizer.Next() % 256);
            }
        }

        public static IEnumerable<char> NextChars(this IRandomizer randomizer, int count,
            bool includeLowerCase)
        {
            var characters = CharsGenerator.GetAvailableRandomCharacters(includeLowerCase);
            var result = Enumerable.Range(0, count)
                .Select(_ => characters[randomizer.Next(characters.Count)]);

            return result;
        }

        #endregion
    }
}