using System;
using Depra.Random.Randomizers;

namespace Depra.Random.System
{
    public sealed class ConcurrentRandom : global::System.Random, IRandomizer
    {
        private static readonly global::System.Random IMPL;

        /// <inheritdoc cref="Random.Next()" />
        public override int Next() => Next(1, int.MaxValue);

        /// <inheritdoc cref="Random.Next(int)" />
        public override int Next(int maxExclusive) => Next(1, maxExclusive);

        /// <inheritdoc cref="Random.Next(int,int)" />
        public override int Next(int minInclusive, int maxExclusive) => IMPL.Next(minInclusive, maxExclusive);

        /// <inheritdoc cref="Random.NextDouble" />
        public override double NextDouble() => IMPL.NextDouble();

        /// <inheritdoc cref="Random.NextBytes" />
        public override void NextBytes(byte[] buffer) => IMPL.NextBytes(buffer);

        static ConcurrentRandom()
        {
            IMPL =
#if NET6_0_OR_GREATER
                new global::System.Random();
#else
                new ConcurrentRandomImpl();
#endif
        }

        private class ConcurrentRandomImpl : global::System.Random
        {
            private static readonly global::System.Random GLOBAL = new global::System.Random();

            [ThreadStatic] private static global::System.Random _local;

            public override int Next() => Next(1, int.MaxValue);

            public override int Next(int maxExclusive) => Next(1, maxExclusive);

            public override int Next(int minInclusive, int maxExclusive)
            {
                var inst = _local;
                if (inst != null)
                {
                    return inst.Next(minInclusive, maxExclusive);
                }
                
                _local = inst = CreateRandom();
                return inst.Next(minInclusive, maxExclusive);
            }

            public override double NextDouble()
            {
                var inst = _local;
                if (inst != null)
                {
                    return inst.NextDouble();
                }
                
                _local = inst = CreateRandom();
                return inst.NextDouble();
            }

            public override void NextBytes(byte[] buffer)
            {
                var inst = _local;
                if (inst != null)
                {
                    inst.NextBytes(buffer);
                    return;
                }
                
                _local = inst = CreateRandom();
                inst.NextBytes(buffer);
            }

            private static global::System.Random CreateRandom()
            {
                int seed;

                lock (GLOBAL)
                {
                    seed = GLOBAL.Next();
                }
                
                return new global::System.Random(seed);
            }
        }
    }
}