// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.Extensions;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Extensions;

[MemoryDiagnoser]
public class ByteArrayRandomizerExtensionsBenchmarks
{
    private const int BYTE_ARRAY_LENGTH = 8;
        
    private IArrayRandomizer<byte[]> _bytesRandomizer;

    [GlobalSetup]
    public void Setup() => _bytesRandomizer = new PseudoRandomizers().GetArrayRandomizer<byte[]>();
        
    [Benchmark]
    public byte[] NextByteArray() => _bytesRandomizer.NextBytes(BYTE_ARRAY_LENGTH);
}