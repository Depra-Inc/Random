// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    private const int BYTE_ARRAY_LENGTH = 8;

    [Benchmark]
    public byte NextByte() => _random.NextByte();

    [Benchmark]
    public byte NextByteInRange() => _random.NextByte(byte.MinValue, byte.MaxValue);

    [Benchmark]
    public byte[] NextByteArray() => _random.NextBytes(BYTE_ARRAY_LENGTH);
}