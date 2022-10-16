// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public long NextLong() => _randomizer.NextLong();

    [Benchmark]
    public long NextLongInRange() => _randomizer.NextLong(long.MinValue, long.MaxValue);
}