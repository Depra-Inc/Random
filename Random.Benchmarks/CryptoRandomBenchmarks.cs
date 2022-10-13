using BenchmarkDotNet.Attributes;
using Depra.Random.System;

namespace Depra.Random.Benchmarks
{
    [MemoryDiagnoser]
    public class CryptoRandomBenchmarks
    {
        private CryptoRandom _cryptoRandom;
        private global::System.Random _random;

        [GlobalSetup]
        public void SetUp()
        {
            _cryptoRandom = new CryptoRandom();
            _random = new global::System.Random();
        }

        [GlobalCleanup]
        public void TearDown() => _cryptoRandom.Dispose();

        [Benchmark(Baseline = true)]
        public int Manual_GetRandomInt() => _random.Next();

        [Benchmark]
        public int Crypto_GetRandomInt() => _cryptoRandom.Next();

        [Benchmark]
        public int Manual_GetRandomIntInRange() => _random.Next(int.MinValue, int.MaxValue);

        [Benchmark]
        public int Crypto_GetRandomIntInRange() => _cryptoRandom.Next(int.MinValue, int.MaxValue);

        [Benchmark]
        public double Manual_GetRandomDouble() => _random.NextDouble();

        [Benchmark]
        public double Crypto_GetRandomDouble() => _cryptoRandom.NextDouble();

        [Benchmark]
        public void Manual_GetRandomBytes() => _random.NextBytes(new byte[64]);

        [Benchmark]
        public void Crypto_GetRandomBytes() => _cryptoRandom.NextBytes(new byte[64]);
    }
}