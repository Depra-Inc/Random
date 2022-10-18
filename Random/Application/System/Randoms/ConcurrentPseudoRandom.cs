// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;

namespace Depra.Random.Application.System.Randoms
{
    /// <summary>
    /// A random number generator guaranteeing thread safety.
    /// </summary>
    public sealed class ConcurrentPseudoRandom : global::System.Random
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