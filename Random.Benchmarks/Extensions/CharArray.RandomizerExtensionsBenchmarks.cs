// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Extensions;

public class CharArrayRandomizerExtensionsBenchmarks
{
    private const int CHAR_ARRAY_LENGTH = 8;
    
    private INumberRandomizer<int> _intRandomizer;

    [GlobalSetup]
    public void Setup() => _intRandomizer = new PseudoRandomizers().GetNumberRandomizer<int>();
        
    [Benchmark]
    public void NextChars() => _intRandomizer.NextChars(CHAR_ARRAY_LENGTH, true);
}