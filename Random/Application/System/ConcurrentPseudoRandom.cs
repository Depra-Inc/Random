// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System
{
    /// <summary>
    /// A random number generator guaranteeing thread safety.
    /// </summary>
    public sealed class ConcurrentPseudoRandom : ITypedRandomizer<int>, ITypedRandomizer<double>,
        IArrayRandomizer<byte[]>
    {
        private static readonly global::System.Random IMPL;
        private static readonly Type[] VALUE_TYPES = {typeof(int), typeof(double), typeof(byte[])};

        public IEnumerable<Type> ValueTypes => VALUE_TYPES;

        public int Next() => IMPL.Next(1, int.MaxValue);
        
        public int Next(int maxExclusive) => IMPL.Next(maxExclusive);

        public int Next(int minInclusive, int maxExclusive) => IMPL.Next(minInclusive, maxExclusive);

        double ITypedRandomizer<double>.Next() => IMPL.NextDouble();

        void IArrayRandomizer<byte[]>.Next(byte[] buffer) => IMPL.NextBytes(buffer);

        static ConcurrentPseudoRandom()
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