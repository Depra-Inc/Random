// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Domain.Extensions;
using Depra.Random.Extensions;

namespace Depra.Random.Benchmarks.Extensions;

public partial class RandomizerExtensionsBenchmarks
{
    private const int CHAR_ARRAY_LENGTH = 8;
    
    [Benchmark]
    public void NextChars() => _random.NextChars(CHAR_ARRAY_LENGTH, true);
}