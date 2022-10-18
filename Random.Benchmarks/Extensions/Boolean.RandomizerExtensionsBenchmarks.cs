// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.Extensions;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Extensions;

public class BooleanRandomizerExtensionsBenchmarks
{
    private INumberRandomizer<int> _doubleRandomizer;

    [GlobalSetup]
    public void Setup() => _doubleRandomizer = new PseudoRandomizers().GetNumberRandomizer<int>();

    [Benchmark]
    public bool NextBool() => _doubleRandomizer.NextBoolean();
}