// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Runtime.CompilerServices;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System.Proxy
{
    internal sealed class IntRandomProxy : SystemRandomProxy, INumberRandomizer<int>
    {
        private static readonly Type VALUE_TYPE = typeof(int);

        public Type ValueType => VALUE_TYPE;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Next() => GetRandom().Next();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Next(int maxExclusive) => GetRandom().Next(maxExclusive);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public int Next(int minInclusive, int maxExclusive) => GetRandom().Next(minInclusive, maxExclusive);

        public IntRandomProxy(global::System.Random random) : base(random) { }
    }
}