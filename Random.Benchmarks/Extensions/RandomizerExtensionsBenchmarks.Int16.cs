using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public short NextShort() => _randomizer.NextShort();

    [Benchmark]
    public short NextShortInRange() => _randomizer.NextShort(short.MinValue, short.MaxValue);
}