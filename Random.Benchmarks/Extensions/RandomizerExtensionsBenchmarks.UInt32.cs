// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public uint NextUInt() => _random.NextUInt();

    [Benchmark]
    public uint NextUIntInRange() => _random.NextUInt(uint.MinValue, uint.MaxValue);
}