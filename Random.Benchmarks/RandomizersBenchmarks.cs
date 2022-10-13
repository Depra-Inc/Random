using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;
using Depra.Random.Services;
using Depra.Random.System;

namespace Depra.Random.Benchmarks
{
    [MemoryDiagnoser]
    public class RandomizersBenchmarks
    {
        private global::System.Random _random;
        private IRandomService _randomService;

        [GlobalSetup]
        public void Setup()
        {
            _random = new global::System.Random();
            _randomService = new RandomServiceBuilder()
                .With(new SystemRandomizers(() => new global::System.Random()))
                .Build();
        }

        [Benchmark(Baseline = true)]
        public int Manual_GetRandomInt() => _random.Next();

        [Benchmark]
        public double Manual_GetRandomDouble() => _random.NextDouble();

        [Benchmark]
        public int Depra_GetRandomInt() => _randomService.GetRandomizer<int>().Next();

        [Benchmark]
        public long Depra_GetRandomLong() => _randomService.GetRandomizer<long>().Next();

        [Benchmark]
        public double Depra_GetRandomDouble() => _randomService.GetRandomizer<double>().Next();

        [Benchmark]
        public int Manual_GetRandomInt_Async() =>
            Task.Run(() => _random.Next())
                .GetAwaiter()
                .GetResult();

        [Benchmark]
        public int Depra_GetRandomInt_Async() =>
            _randomService.GetRandomizer<int>().NextAsync()
                .GetAwaiter()
                .GetResult();

        [Benchmark]
        public long Depra_GetRandomLong_Async() =>
            _randomService.GetRandomizer<long>().NextAsync()
                .GetAwaiter()
                .GetResult();

        [Benchmark]
        public double Depra_GetRandomDouble_Async() =>
            _randomService.GetRandomizer<double>().NextAsync()
                .GetAwaiter()
                .GetResult();
    }
}