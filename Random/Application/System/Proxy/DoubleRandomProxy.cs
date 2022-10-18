// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Runtime.CompilerServices;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System.Proxy
{
    internal sealed class DoubleRandomProxy : SystemRandomProxy, ITypedRandomizer<double>
    {
        private static readonly Type VALUE_TYPE = typeof(double);

        public Type ValueType => VALUE_TYPE;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Next() => GetRandom().NextDouble();

        public DoubleRandomProxy(global::System.Random random) : base(random) { }
    }
}