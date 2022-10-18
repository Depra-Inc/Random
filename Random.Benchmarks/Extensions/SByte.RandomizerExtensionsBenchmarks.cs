// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Extensions;

public class SByteRandomizerExtensionsBenchmarks
{
    private INumberRandomizer<int> _intRandomizer;

    [GlobalSetup]
    public void Setup() => _intRandomizer = new PseudoRandomizers().GetNumberRandomizer<int>();
    
    [Benchmark]
    public sbyte NextSByte() => _intRandomizer.NextSByte();

    [Benchmark]
    public sbyte NextSByteInRange() => _intRandomizer.NextSByte(sbyte.MinValue, sbyte.MaxValue);
}