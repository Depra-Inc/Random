// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Runtime.CompilerServices;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System.Proxy
{
    internal sealed class ByteArrayRandomProxy : SystemRandomProxy, IArrayRandomizer<byte[]>
    {
        private static readonly Type VALUE_TYPE = typeof(byte[]);

        public Type ValueType => VALUE_TYPE;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void Next(byte[] buffer) => GetRandom().NextBytes(buffer);

        public ByteArrayRandomProxy(global::System.Random random) : base(random) { }
    }
}