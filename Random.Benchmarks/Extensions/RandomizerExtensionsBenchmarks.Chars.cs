using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    private const int CHAR_ARRAY_LENGTH = 8;
    
    [Benchmark]
    public void NextChars() => _randomizer.NextChars(CHAR_ARRAY_LENGTH, true);
}