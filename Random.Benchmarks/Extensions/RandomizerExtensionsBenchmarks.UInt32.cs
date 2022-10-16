// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public uint NextUInt() => _randomizer.NextUInt();

    [Benchmark]
    public uint NextUIntInRange() => _randomizer.NextUInt(uint.MinValue, uint.MaxValue);
}