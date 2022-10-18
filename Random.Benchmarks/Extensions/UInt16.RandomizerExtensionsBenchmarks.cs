// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Extensions;

public class UInt16RandomizerExtensionsBenchmarks
{
    private INumberRandomizer<int> _intRandomizer;

    [GlobalSetup]
    public void Setup() => _intRandomizer = new PseudoRandomizers().GetNumberRandomizer<int>();
    
    [Benchmark]
    public ushort NextUShort() => _intRandomizer.NextUShort();

    [Benchmark]
    public ushort NextUShortInRange() => _intRandomizer.NextUShort(ushort.MinValue, ushort.MaxValue);
}