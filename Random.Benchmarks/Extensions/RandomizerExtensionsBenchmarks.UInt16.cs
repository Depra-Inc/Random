using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public ushort NextUShort() => _randomizer.NextUShort();

    [Benchmark]
    public ushort NextUShortInRange() => _randomizer.NextUShort(ushort.MinValue, ushort.MaxValue);
}