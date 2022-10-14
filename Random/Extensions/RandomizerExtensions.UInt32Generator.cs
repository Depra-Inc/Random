using System;
using Depra.Random.Internal.Exceptions;
using Depra.Random.Randomizers;

namespace Depra.Random.Extensions
{
    public static partial class RandomizerExtensions
    {
        internal static class OptimizedUInt32Randomizer
        {
            public static uint GetRandomUInt32(IRandomizer random) =>
                (uint) random.Next(1 << 30) << 2 | (uint) random.Next(1 << 2);

            public static uint GetRandomUInt32(IRandomizer random, uint maxExclusive)
            {
                uint x;
                if (maxExclusive < int.MaxValue)
                {
                    return (uint) random.Next((int) maxExclusive + 1);
                }

                do
                {
                    do x = (uint) random.Next(1 << 30) << 2;
                    while (x > maxExclusive);
                    {
                        x |= (uint) random.Next(1 << 2);
                    }
                } while (x > maxExclusive);

                return x;
            }

            public static uint GetRandomUInt32(IRandomizer random, uint minInclusive,
                uint maxExclusive) => minInclusive < maxExclusive
                ? minInclusive + GetRandomUInt32(random, maxExclusive - minInclusive)
                : maxExclusive + GetRandomUInt32(random, minInclusive - maxExclusive);
        }

        internal static class UInt32Randomizer
        {
            public static uint GetRandomUInt32(IRandomizer random)
            {
                var buffer = new byte[4];
                random.NextBytes(buffer);

                return BitConverter.ToUInt32(buffer, 0);
            }

            public static uint GetRandomUInt32(IRandomizer random, uint maxExclusive) =>
                random.NextUInt(uint.MinValue, maxExclusive);

            public static uint GetRandomUInt32(IRandomizer random, uint minInclusive,
                uint maxExclusive)
            {
                if (minInclusive > maxExclusive)
                {
                    Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
                }

                if (minInclusive == maxExclusive)
                {
                    return minInclusive;
                }

                var range = maxExclusive - minInclusive;
                // ReSharper disable once UselessBinaryOperation
                var bias = uint.MaxValue - uint.MaxValue % range;
                uint result;

                do
                {
                    result = random.NextUInt();
                } while (result >= bias);

                return result % range + minInclusive;
            }
        }
    }
}