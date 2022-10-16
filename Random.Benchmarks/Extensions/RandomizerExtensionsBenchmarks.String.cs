using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    private const int STRING_LENGTH = 8;
    
    [Benchmark]
    public string NextString() => _randomizer.NextString(STRING_LENGTH, true);
}