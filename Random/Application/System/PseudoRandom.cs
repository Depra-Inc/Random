// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System
{
    /// <summary>
    /// Decorator for <see cref="Random"/>, to support the <see cref="IRandomizer"/> contract.
    /// </summary>
    public sealed class PseudoRandom : global::System.Random, INumberRandomizer<int>, ITypedRandomizer<double>,
        IArrayRandomizer<byte[]>
    {
        private static readonly Type[] VALUE_TYPES = {typeof(int), typeof(double), typeof(byte[])};

        public IEnumerable<Type> ValueTypes => VALUE_TYPES;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int ITypedRandomizer<int>.Next() => base.Next();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int INumberRandomizer<int>.Next(int maxExclusive) => base.Next(maxExclusive);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        int INumberRandomizer<int>.Next(int minInclusive, int maxExclusive) => base.Next(minInclusive, maxExclusive);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        double ITypedRandomizer<double>.Next() => NextDouble();

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        void IArrayRandomizer<byte[]>.Next(byte[] buffer) => NextBytes(buffer);
    }
}