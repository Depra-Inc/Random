// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Depra.Random.Application.System.Mapping;
using Depra.Random.Application.System.Randoms;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System.Collections
{
    public sealed class CryptoRandomizers : IRandomizerCollection
    {
        private readonly SystemRandomizersMapper _randomizersMapper;

        public CryptoRandomizers()
        {
            var random = new CryptoRandom();
            _randomizersMapper = new SystemRandomizersMapper(
                new IntRandomProxy(random),
                new DoubleRandomProxy(random),
                new ByteArrayRandomProxy(random));
        }

        public IRandomizer GetRandomizer(Type valueType) => _randomizersMapper.GetRandomizer(valueType);

        public IEnumerable<IRandomizer> GetAllRandomizers() => _randomizersMapper.GetAllRandomizers();

        private abstract class CryptoRandomProxy : IDisposable
        {
            private readonly CryptoRandom _cryptoRandom;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            protected CryptoRandom GetRandom() => _cryptoRandom;

            protected CryptoRandomProxy(CryptoRandom cryptoRandom) => _cryptoRandom = cryptoRandom;

            public void Dispose() => _cryptoRandom.Dispose();
        }

        private class IntRandomProxy : CryptoRandomProxy, INumberRandomizer<int>
        {
            private static readonly Type VALUE_TYPE = typeof(int);

            public Type ValueType => VALUE_TYPE;

            public int Next() => GetRandom().Next();

            public int Next(int maxExclusive) => GetRandom().Next(maxExclusive);

            public int Next(int minInclusive, int maxExclusive) => GetRandom().Next(minInclusive, maxExclusive);
            
            public IntRandomProxy(CryptoRandom cryptoRandom) : base(cryptoRandom) { }
        }

        private class DoubleRandomProxy : CryptoRandomProxy, ITypedRandomizer<double>
        {
            private static readonly Type VALUE_TYPE = typeof(double);

            public Type ValueType => VALUE_TYPE;

            public double Next() => GetRandom().NextDouble();
            
            public DoubleRandomProxy(CryptoRandom cryptoRandom) : base(cryptoRandom) { }
        }

        private class ByteArrayRandomProxy : CryptoRandomProxy, IArrayRandomizer<byte[]>
        {
            private static readonly Type VALUE_TYPE = typeof(byte[]);

            public Type ValueType => VALUE_TYPE;

            public void Next(byte[] buffer) => GetRandom().NextBytes(buffer);

            public ByteArrayRandomProxy(CryptoRandom cryptoRandom) : base(cryptoRandom) { }
        }
    }
}