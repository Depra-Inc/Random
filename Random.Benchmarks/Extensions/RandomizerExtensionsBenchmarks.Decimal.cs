using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public decimal NextDecimal() => _randomizer.NextDecimal();

    [Benchmark]
    public decimal NextDecimalInRange() => _randomizer.NextDecimal(decimal.MinValue, decimal.MaxValue);
}