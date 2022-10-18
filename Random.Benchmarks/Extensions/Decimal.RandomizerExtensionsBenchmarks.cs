// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Extensions;

public class DecimalRandomizerExtensionsBenchmarks
{
    private INumberRandomizer<int> _intRandomizer;

    [GlobalSetup]
    public void Setup() => _intRandomizer = new PseudoRandomizers().GetNumberRandomizer<int>();

    [Benchmark]
    public decimal NextDecimal() => _intRandomizer.NextDecimal();

    [Benchmark]
    public decimal NextDecimalInRange() => _intRandomizer.NextDecimal(decimal.MinValue, decimal.MaxValue);
}