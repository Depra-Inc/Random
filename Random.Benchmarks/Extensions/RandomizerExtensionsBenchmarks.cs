using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;

namespace Depra.Random.Benchmarks.Extensions;

[MemoryDiagnoser]
public partial class RandomizerExtensionsBenchmarks
{
    private IRandomizer _randomizer;

    [GlobalSetup]
    public void Setup() => _randomizer = new PseudoRandom();

    [Benchmark]
    public double NextDoubleInRange() => _randomizer.NextDouble(double.MinValue, double.MaxValue);
}