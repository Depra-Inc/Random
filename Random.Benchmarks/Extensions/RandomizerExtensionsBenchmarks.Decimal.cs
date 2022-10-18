// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    [Benchmark]
    public decimal NextDecimal() => _random.NextDecimal();

    [Benchmark]
    public decimal NextDecimalInRange() => _random.NextDecimal(decimal.MinValue, decimal.MaxValue);
}