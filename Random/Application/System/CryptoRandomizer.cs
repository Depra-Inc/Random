// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System
{
    /// <summary>
    /// A random number generator based on the <see cref="RNGCryptoServiceProvider"/>.
    /// </summary>
    public sealed class CryptoRandomizer : ITypedRandomizer<int>, ITypedRandomizer<double>, IArrayRandomizer<byte[]>,
        IDisposable
    {
        private static readonly Type[] VALUE_TYPES = {typeof(int), typeof(double), typeof(byte[])};

        private readonly RNGCryptoServiceProvider _rng;
        private bool _disposed;

        public IEnumerable<Type> ValueTypes => VALUE_TYPES;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoRandomizer"/> class.
        /// </summary>
        public CryptoRandomizer() => _rng = new RNGCryptoServiceProvider();

        public int Next()
        {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            return RandomNumberGenerator.GetInt32(0, int.MaxValue);
#else
            return GenerateInt32();
#endif
        }

        public int Next(int maxExclusive)
        {
            if (maxExclusive < 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            return Next(0, maxExclusive);
        }

        public int Next(int minInclusive, int maxExclusive)
        {
            if (minInclusive > maxExclusive)
            {
                Throw.ArgumentMustBeSmallerOrEqual(nameof(minInclusive), minInclusive, maxExclusive);
            }

            if (minInclusive == maxExclusive)
            {
                return minInclusive;
            }

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            return RandomNumberGenerator.GetInt32(minInclusive, maxExclusive);
#else
            return GenerateInt32(minInclusive, maxExclusive);
#endif
        }

        double ITypedRandomizer<double>.Next() => GenerateUInt32() / (uint.MaxValue + 1.0);

        void IArrayRandomizer<byte[]>.Next(byte[] buffer) => _rng.GetBytes(buffer);

        /// <summary>
        /// Gets one random unsigned 32bit integer.
        /// </summary>
        private uint GenerateUInt32() => BitConverter.ToUInt32(GenerateBytes(sizeof(uint)), 0);

        /// <summary>
        /// Gets one random signed 32bit integer.
        /// </summary>
        private int GenerateInt32() => BitConverter.ToInt32(GenerateBytes(sizeof(int)), 0) & (int.MaxValue - 1);

        /// <summary>
        /// Gets one random signed 32bit integer in range.
        /// </summary>
        private int GenerateInt32(int minInclusive, int maxExclusive) => (int) Math.Floor(minInclusive +
            ((double) maxExclusive - minInclusive) * (this as ITypedRandomizer<double>).Next());

        /// <summary>
        /// Gets one random byte array.
        /// </summary>
        private byte[] GenerateBytes(int size)
        {
            var randomBytes = new byte[size];
            _rng.GetBytes(randomBytes);

            return randomBytes;
        }

        ~CryptoRandomizer() => Dispose(false);

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Private implementation of Dispose pattern.
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _rng?.Dispose();
            }

            _disposed = true;
        }
    }
}