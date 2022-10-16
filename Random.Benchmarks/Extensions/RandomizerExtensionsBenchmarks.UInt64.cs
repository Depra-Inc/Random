using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public ulong NextULong() => _randomizer.NextULong();

    [Benchmark]
    public ulong NextULongInRange() => _randomizer.NextULong(ulong.MinValue, ulong.MaxValue);
}