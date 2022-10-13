using System;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using Depra.Random.Internal.Exceptions;

namespace Depra.Random.System
{
    /// <summary>
    /// A random number generator based on the <see cref="RNGCryptoServiceProvider"/>.
    /// </summary>
    public sealed class CryptoRandom : global::System.Random, IDisposable
    {
        private readonly RNGCryptoServiceProvider _rng;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoRandom"/> class with.
        /// </summary>
        public CryptoRandom() => _rng = new RNGCryptoServiceProvider();

        /// <summary>
        /// Initializes a new instance of the <see cref="CryptoRandom"/> class.
        /// This method will disregard whatever value is passed as seed and it's only implemented
        /// in order to be fully backwards compatible with <see cref="Random"/>.
        /// </summary>
        /// <param name="ignoredSeed">The ignored seed.</param>
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "ignoredSeed",
            Justification = "Cannot remove this parameter as we implement the full API of System.Random")]
        public CryptoRandom(int ignoredSeed) : this() { }

        /// <inheritdoc />
        public override int Next()
        {
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER
            return RandomNumberGenerator.GetInt32(0, int.MaxValue);
#else
            return GenerateInt32();
#endif
        }

        /// <inheritdoc />
        public override int Next(int maxExclusive)
        {
            if (maxExclusive < 0)
            {
                Throw.ArgumentMustBeGreaterOrEqual(nameof(maxExclusive), maxExclusive, 0);
            }

            return Next(0, maxExclusive);
        }

        /// <inheritdoc />
        public override int Next(int minInclusive, int maxExclusive)
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

        /// <inheritdoc />
        public override double NextDouble() => GenerateUInt32() / (uint.MaxValue + 1.0);

        /// <inheritdoc />
        public override void NextBytes(byte[] buffer) => _rng.GetBytes(buffer);

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
        private int GenerateInt32(int minInclusive, int maxExclusive) =>
            (int) Math.Floor(minInclusive + ((double) maxExclusive - minInclusive) * NextDouble());

        /// <summary>
        /// Gets one random byte array.
        /// </summary>
        private byte[] GenerateBytes(int size)
        {
            var randomBytes = new byte[size];
            _rng.GetBytes(randomBytes);

            return randomBytes;
        }

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