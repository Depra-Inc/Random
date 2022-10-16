// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public float NextFloat() => _randomizer.NextFloat();

    [Benchmark]
    public float NextFloatInRange() => _randomizer.NextFloat(float.MinValue, float.MaxValue);
}