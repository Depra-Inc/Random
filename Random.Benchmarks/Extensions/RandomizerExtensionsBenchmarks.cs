// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.System;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

[MemoryDiagnoser]
public partial class RandomizerExtensionsBenchmarks
{
    private PseudoRandom _random;

    [GlobalSetup]
    public void Setup() => _random = new PseudoRandom();

    [Benchmark]
    public double NextDoubleInRange() => _random.NextDouble(double.MinValue, double.MaxValue);
}