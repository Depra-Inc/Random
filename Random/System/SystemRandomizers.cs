using System;
using Depra.Random.Randomizers;

namespace Depra.Random.System
{
    /// <summary>
    /// Facade for randomizer used to <see cref="Random"/>.
    /// </summary>
    public sealed class SystemRandomizers : IRandomizer<int>, IRandomizer<double>, IRandomizer<long>
    {
        private readonly Func<global::System.Random> _randomFactory;

        private IntRandomizer _intRandomizer;
        private LongRandomizer _longRandomizer;
        private DoubleRandomizer _doubleRandomizer;

        private IRandomizer<int> Int =>
            _intRandomizer ?? (_intRandomizer = new IntRandomizer(_randomFactory));

        private IRandomizer<long> Long =>
            _longRandomizer ?? (_longRandomizer = new LongRandomizer(_randomFactory));

        private IRandomizer<double> Double =>
            _doubleRandomizer ?? (_doubleRandomizer = new DoubleRandomizer(_randomFactory));

        public SystemRandomizers(Func<global::System.Random> randomFactory) => _randomFactory = randomFactory;

        int IRandomizer<int>.Next() => Int.Next();

        long IRandomizer<long>.Next() => Long.Next();

        double IRandomizer<double>.Next() => Double.Next();

        int IRandomizer<int>.Next(int min, int max) => Int.Next(min, max);

        long IRandomizer<long>.Next(long min, long max) => Long.Next(min, max);

        double IRandomizer<double>.Next(double min, double max) => Double.Next(min, max);

        private abstract class SystemRandomizer
        {
            private readonly Func<global::System.Random> _randomFactory;

            protected global::System.Random GetRandom() => _randomFactory();

            protected SystemRandomizer(Func<global::System.Random> randomFactory) => _randomFactory = randomFactory;
        }

        private class IntRandomizer : SystemRandomizer, INumberRandomizer<int>
        {
            public int Next() => GetRandom().Next();

            public int Next(int minInclusive, int maxExclusive) =>
                GetRandom().Next(minInclusive, maxExclusive);

            public int NextPositive(int maxExclusive) => Next(1, maxExclusive);

            public int NextNegative(int minInclusive) => Next(minInclusive, -1);

            public IntRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class LongRandomizer : SystemRandomizer, INumberRandomizer<long>
        {
            public long Next() => GetRandom().NextLong();

            public long Next(long minInclusive, long maxExclusive) =>
                GetRandom().NextLong(minInclusive, maxExclusive);

            public long NextPositive(long maxExclusive) => Next(1, maxExclusive);

            public long NextNegative(long minInclusive) => Next(minInclusive, -1);

            public LongRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }

        private class DoubleRandomizer : SystemRandomizer, INumberRandomizer<double>
        {
            public double Next() => GetRandom().NextDouble();

            public double Next(double minInclusive, double maxExclusive) =>
                GetRandom().NextDouble(minInclusive, maxExclusive);

            public double NextPositive(double maxExclusive) => Next(1, maxExclusive);

            public double NextNegative(double minInclusive) => Next(minInclusive, -1);

            public DoubleRandomizer(Func<global::System.Random> randomFactory) : base(randomFactory) { }
        }
    }
}