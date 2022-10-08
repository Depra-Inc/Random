using BenchmarkDotNet.Attributes;
using Depra.Random.Services;
using Depra.Random.System;

namespace Depra.Random.Benchmarks
{
    [MemoryDiagnoser]
    public class RandomBenchmarks
    {
        private IRandomService _randomService;

        [GlobalSetup]
        public void Setup()
        {
            var randomService = new RandomService();
            var systemRandomizers = new SystemRandomizers(() => new global::System.Random());
            randomService.RegisterRandomizer<int>(systemRandomizers);
            _randomService = randomService;
        }

        [Benchmark]
        public int ManualRandom() => new global::System.Random().Next();

        [Benchmark]
        public int DepraRandom() => _randomService.GetRandomizer<int>().Next();

        [Benchmark]
        public int ManualRandomInRange() => new global::System.Random().Next(int.MinValue, int.MaxValue);

        [Benchmark]
        public int DepraRandomInRange() => _randomService.GetRandomizer<int>().Next(int.MinValue, int.MaxValue);
    }
}