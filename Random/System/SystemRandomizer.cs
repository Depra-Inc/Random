using System;
using Depra.Random.Randomizers;

namespace Depra.Random.System
{
    /// <summary>
    /// Facade for randomizer used to <see cref="Random"/>.
    /// </summary>
    public sealed class SystemRandomizer : IRandomizer
    {
        public int Next() => GetRandom().Next();

        public int Next(int maxExclusive) => GetRandom().Next(maxExclusive);

        public int Next(int minInclusive, int maxExclusive) => GetRandom().Next(minInclusive, maxExclusive);

        public double NextDouble() => GetRandom().NextDouble();

        public void NextBytes(byte[] buffer) => GetRandom().NextBytes(buffer);

        private static global::System.Random GetRandom() => new global::System.Random();
    }
}