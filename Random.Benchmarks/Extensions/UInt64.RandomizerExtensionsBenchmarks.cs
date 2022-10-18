// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.Extensions;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Extensions;

public class UInt64RandomizerExtensionsBenchmarks
{
    private IArrayRandomizer<byte[]> _byteArrayRandomizer;

    [GlobalSetup]
    public void Setup() => _byteArrayRandomizer = new PseudoRandomizers().GetArrayRandomizer<byte[]>();

    [Benchmark]
    public ulong NextULong() => _byteArrayRandomizer.NextULong();

    [Benchmark]
    public ulong NextULongInRange() => _byteArrayRandomizer.NextULong(ulong.MinValue, ulong.MaxValue);
}