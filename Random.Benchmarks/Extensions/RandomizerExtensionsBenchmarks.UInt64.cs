// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public ulong NextULong() => _random.NextULong();

    [Benchmark]
    public ulong NextULongInRange() => _random.NextULong(ulong.MinValue, ulong.MaxValue);
}