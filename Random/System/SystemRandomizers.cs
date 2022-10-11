using System;
using System.Collections.Generic;
using Depra.Random.Randomizers;

namespace Depra.Random.System
{
    /// <summary>
    /// Facade for randomizer used to <see cref="Random"/>.
    /// </summary>
    public sealed class SystemRandomizers : IRandomizerCollection
    {
        private readonly RandomizerFactory _randomizerFactory;

        public SystemRandomizers(Func<global::System.Random> randomFactory) =>
            _randomizerFactory = new RandomizerFactory(randomFactory);

        public IRandomizer GetRandomizer(Type valueType) => _randomizerFactory.GetRandomizer(valueType);

        public IEnumerable<IRandomizer> GetAllRandomizers() => _randomizerFactory.GetAllRandomizers();

        private abstract class Helper
        {
            private readonly Func<global::System.Random> _randomFactory;

            protected global::System.Random GetRandom() => _randomFactory();

            protected Helper(Func<global::System.Random> randomFactory) => _randomFactory = randomFactory;
        }

        private class RandomizerFactory : Helper
        {
            public IRandomizer GetRandomizer(Type type)
            {
                switch (Type.GetTypeCode(type))
                {
                    case TypeCode.SByte:
                        return new SByteRandomizer(GetRandom);
                    case TypeCode.Byte:
                        return new ByteRandomizer(GetRandom);
                    case TypeCode.Int16:
                        return new ShortRandomizer(GetRandom);
                    case TypeCode.UInt16:
                        return new UShortRandomizer(GetRandom);
                    case TypeCode.Int32:
                        return new IntRandomizer(GetRandom);
                    case TypeCode.UInt32:
                        return new UIntRandomizer(GetRandom);
                    case TypeCode.Int64:
                        return new LongRandomizer(GetRandom);
                    case TypeCode.UInt64:
                        return new ULongRandomizer(GetRandom);
                    case TypeCode.Single:
                        return new FloatRandomizer(GetRandom);
                    case TypeCode.Double:
                        return new DoubleRandomizer(GetRandom);
                    case TypeCode.Decimal:
                        return new DecimalRandomizer(GetRandom);
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            public IEnumerable<IRandomizer> GetAllRandomizers()
            {
                yield return new SByteRandomizer(GetRandom);
                yield return new ByteRandomizer(GetRandom);
                yield return new ShortRandomizer(GetRandom);
                yield return new UShortRandomizer(GetRandom);
                yield return new IntRandomizer(GetRandom);
                yield return new UIntRandomizer(GetRandom);
                yield return new LongRandomizer(GetRandom);
                yield return new ULongRandomizer(GetRandom);
                yield return new FloatRandomizer(GetRandom);
                yield return new DoubleRandomizer(GetRandom);
                yield return new DecimalRandomizer(GetRandom);
            }

            public RandomizerFactory(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class SByteRandomizer : Helper, ISignedNumberRandomizer<sbyte>
        {
            private static readonly Type VALUE_TYPE = typeof(sbyte);

            public Type ValueType => VALUE_TYPE;

            public sbyte Next() => GetRandom().NextSByte();

            public sbyte Next(sbyte minInclusive, sbyte maxExclusive) =>
                GetRandom().NextSByte(minInclusive, maxExclusive);

            public sbyte NextPositive(sbyte maxExclusive) => GetRandom().NextSByte(1, maxExclusive);

            public sbyte NextNegative(sbyte minInclusive) => GetRandom().NextSByte(minInclusive, -1);

            public SByteRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class ByteRandomizer : Helper, INumberRandomizer<byte>
        {
            private static readonly Type VALUE_TYPE = typeof(byte);

            public Type ValueType => VALUE_TYPE;

            public byte Next() => GetRandom().NextByte();

            public byte Next(byte minInclusive, byte maxExclusive) => 
                GetRandom().NextByte(minInclusive, maxExclusive);

            public byte NextPositive(byte maxExclusive) => GetRandom().NextByte(1, maxExclusive);

            public ByteRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class ShortRandomizer : Helper, ISignedNumberRandomizer<short>
        {
            private static readonly Type VALUE_TYPE = typeof(uint);

            public Type ValueType => VALUE_TYPE;

            public short Next() => GetRandom().NextShort();

            public short Next(short minInclusive, short maxExclusive) =>
                GetRandom().NextShort(minInclusive, maxExclusive);

            public short NextPositive(short maxExclusive) => GetRandom().NextShort(1, maxExclusive);

            public short NextNegative(short minInclusive) => GetRandom().NextShort(minInclusive, -1);

            public ShortRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class UShortRandomizer : Helper, INumberRandomizer<ushort>
        {
            private static readonly Type VALUE_TYPE = typeof(ushort);

            public Type ValueType => VALUE_TYPE;

            public ushort Next() => GetRandom().NextUShort();

            public ushort Next(ushort minInclusive, ushort maxExclusive) =>
                GetRandom().NextUShort(minInclusive, maxExclusive);

            public ushort NextPositive(ushort maxExclusive) => GetRandom().NextUShort(1, maxExclusive);

            public UShortRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class IntRandomizer : Helper, ISignedNumberRandomizer<int>
        {
            private static readonly Type VALUE_TYPE = typeof(int);

            public Type ValueType => VALUE_TYPE;

            public int Next() => GetRandom().Next();

            public int Next(int minInclusive, int maxExclusive) =>
                GetRandom().Next(minInclusive, maxExclusive);

            public int NextPositive(int maxExclusive) => Next(1, maxExclusive);

            public int NextNegative(int minInclusive) => Next(minInclusive, -1);

            public IntRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class UIntRandomizer : Helper, INumberRandomizer<uint>
        {
            private static readonly Type VALUE_TYPE = typeof(uint);

            public Type ValueType => VALUE_TYPE;

            public uint Next() => GetRandom().NextUInt();

            public uint Next(uint minInclusive, uint maxExclusive) =>
                GetRandom().NextUInt(minInclusive, maxExclusive);

            public uint NextPositive(uint maxExclusive) => GetRandom().NextUInt(1, maxExclusive);

            public UIntRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class ULongRandomizer : Helper, INumberRandomizer<ulong>
        {
            private static readonly Type VALUE_TYPE = typeof(ulong);

            public Type ValueType => VALUE_TYPE;

            public ulong Next() => GetRandom().NextULong();

            public ulong Next(ulong minInclusive, ulong maxExclusive) =>
                GetRandom().NextULong(minInclusive, maxExclusive);

            public ulong NextPositive(ulong maxExclusive) => GetRandom().NextULong(maxExclusive);

            public ULongRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class LongRandomizer : Helper, ISignedNumberRandomizer<long>
        {
            private static readonly Type VALUE_TYPE = typeof(long);

            public Type ValueType => VALUE_TYPE;

            public long Next() => GetRandom().NextLong();

            public long Next(long minInclusive, long maxExclusive) =>
                GetRandom().NextLong(minInclusive, maxExclusive);

            public long NextPositive(long maxExclusive) => Next(1, maxExclusive);

            public long NextNegative(long minInclusive) => Next(minInclusive, -1);

            public LongRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class FloatRandomizer : Helper, ISignedNumberRandomizer<float>
        {
            private static readonly Type VALUE_TYPE = typeof(float);

            public Type ValueType => VALUE_TYPE;

            public float Next() => GetRandom().NextFloat();

            public float Next(float minInclusive, float maxExclusive) =>
                GetRandom().NextFloat(minInclusive, maxExclusive);

            public float NextPositive(float maxExclusive) => GetRandom().NextFloat(1, maxExclusive);

            public float NextNegative(float minInclusive) => GetRandom().NextFloat(minInclusive, -1);

            public FloatRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class DoubleRandomizer : Helper, ISignedNumberRandomizer<double>
        {
            private static readonly Type VALUE_TYPE = typeof(double);

            public Type ValueType => VALUE_TYPE;

            public double Next() => GetRandom().NextDouble();

            public double Next(double minInclusive, double maxExclusive) =>
                GetRandom().NextDouble(minInclusive, maxExclusive);

            public double NextPositive(double maxExclusive) => Next(1, maxExclusive);

            public double NextNegative(double minInclusive) => Next(minInclusive, -1);

            public DoubleRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class DecimalRandomizer : Helper, ISignedNumberRandomizer<decimal>
        {
            private static readonly Type VALUE_TYPE = typeof(decimal);

            public Type ValueType => VALUE_TYPE;

            public decimal Next() => GetRandom().NextDecimal();

            public decimal Next(decimal minInclusive, decimal maxExclusive) =>
                GetRandom().NextDecimal(minInclusive, maxExclusive);

            public decimal NextPositive(decimal maxExclusive) => GetRandom().NextDecimal(1, maxExclusive);

            public decimal NextNegative(decimal minInclusive) => GetRandom().NextDecimal(minInclusive, -1);

            public DecimalRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }
    }
}