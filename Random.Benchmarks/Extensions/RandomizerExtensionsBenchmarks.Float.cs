// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public float NextFloat() => _random.NextFloat();

    [Benchmark]
    public float NextFloatInRange() => _random.NextFloat(float.MinValue, float.MaxValue);
}