// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public ushort NextUShort() => _random.NextUShort();

    [Benchmark]
    public ushort NextUShortInRange() => _random.NextUShort(ushort.MinValue, ushort.MaxValue);
}