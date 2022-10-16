// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public sbyte NextSByte() => _randomizer.NextSByte();

    [Benchmark]
    public sbyte NextSByteInRange() => _randomizer.NextSByte(sbyte.MinValue, sbyte.MaxValue);
}