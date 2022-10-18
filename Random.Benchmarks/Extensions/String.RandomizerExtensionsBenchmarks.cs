// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Extensions;

public class StringRandomizerExtensionsBenchmarks
{
    private INumberRandomizer<int> _intRandomizer;

    [Params(10, 100)]
    public int StringLength { get; set; }
    
    [GlobalSetup]
    public void Setup() => _intRandomizer = new PseudoRandomizers().GetNumberRandomizer<int>();

    [Benchmark]
    public string NextString() => _intRandomizer.NextString(StringLength, true);
}