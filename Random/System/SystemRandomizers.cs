using System;
using Depra.Random.Domain;

namespace Depra.Random.System
{
    /// <summary>
    /// Facade for randomizer used to <see cref="Random"/>.
    /// </summary>
    public sealed class SystemRandomizers : IRandomizer<int>, IRandomizer<double>, IRandomizer<long>
    {
        private const int DEFAULT_SEED = 666;

        private readonly global::System.Random _random;

        private IRandomizer<int> _intRandomizer;
        private IRandomizer<long> _longRandomizer;
        private IRandomizer<double> _doubleRandomizer;

        internal IRandomizer<int> Int => _intRandomizer ?? (_intRandomizer = new IntRandomizer(_random));
        internal IRandomizer<long> Long => _longRandomizer ?? (_longRandomizer = new LongRandomizer(_random));
        internal IRandomizer<double> Double => _doubleRandomizer ?? (_doubleRandomizer = new DoubleRandomizer(_random));

        public SystemRandomizers(global::System.Random random) => _random = random;

        public SystemRandomizers(int seed = DEFAULT_SEED) : this(new global::System.Random(seed)) { }

        int IRandomizer<int>.Next() => Int.Next();

        long IRandomizer<long>.Next() => Long.Next();

        double IRandomizer<double>.Next() => Double.Next();

        int IRandomizer<int>.Next(int min, int max) => Int.Next(min, max);

        long IRandomizer<long>.Next(long min, long max) => Long.Next(min, max);

        double IRandomizer<double>.Next(double min, double max) => Double.Next(min, max);

        private class IntRandomizer : INumberRandomizer<int>
        {
            private readonly global::System.Random _random;

            public int Next() => _random.Next();

            public int Next(int minInclusive, int maxExclusive) => _random.Next(minInclusive, maxExclusive);

            public int NextPositive(int maxExclusive) => _random.Next(1, maxExclusive);

            public int NextNegative(int minInclusive) => _random.Next(minInclusive, -1);

            public IntRandomizer(global::System.Random random) => _random = random;
        }

        private class LongRandomizer : INumberRandomizer<long>
        {
            private readonly global::System.Random _random;

            public long Next() => _random.NextLong();

            public long Next(long minInclusive, long maxExclusive) => _random.NextLong(minInclusive, maxExclusive);

            public long NextPositive(long maxExclusive) => _random.NextLong(1, maxExclusive);

            public long NextNegative(long minInclusive) => _random.NextLong(minInclusive, -1);

            public LongRandomizer(global::System.Random random) => _random = random;
        }

        private class DoubleRandomizer : INumberRandomizer<double>
        {
            private readonly global::System.Random _random;

            public double Next() => _random.NextDouble();

            public double Next(double minInclusive, double maxExclusive) =>
                _random.NextDouble(minInclusive, maxExclusive);

            public double NextPositive(double maxExclusive) => Next(1, maxExclusive);

            public double NextNegative(double minInclusive) => Next(minInclusive, -1);

            public DoubleRandomizer(global::System.Random random) => _random = random;
        }
    }
}