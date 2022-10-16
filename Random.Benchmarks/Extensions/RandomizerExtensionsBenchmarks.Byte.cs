using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    private const int BYTE_ARRAY_LENGTH = 8;

    [Benchmark]
    public byte NextByte() => _randomizer.NextByte();

    [Benchmark]
    public byte NextByteInRange() => _randomizer.NextByte(byte.MinValue, byte.MaxValue);

    [Benchmark]
    public byte[] NextByteArray() => _randomizer.NextBytes(BYTE_ARRAY_LENGTH);
}