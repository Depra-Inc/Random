// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    private const int STRING_LENGTH = 8;
    
    [Benchmark]
    public string NextString() => _random.NextString(STRING_LENGTH, true);
}