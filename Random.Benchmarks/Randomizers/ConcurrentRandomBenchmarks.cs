// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.System;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Benchmarks.Randomizers;

[MemoryDiagnoser]
public class ConcurrentRandomBenchmarks
{
    private System.Random _random;
    private ConcurrentPseudoRandom _concurrentRandom;

    [GlobalSetup]
    public void Setup()
    {
        _random = new System.Random();
        _concurrentRandom = new ConcurrentPseudoRandom();
    }
        
    [Benchmark(Baseline = true)]
    public int NextInt32_Pseudo() => _random.Next();

    [Benchmark]
    public int NextInt32_Concurrent() => _concurrentRandom.Next();

    [Benchmark]
    public int NextInt32_Pseudo_InRange() => _random.Next(int.MinValue, int.MaxValue);

    [Benchmark]
    public int NextInt32_Concurrent_InRange() => _concurrentRandom.Next(int.MinValue, int.MaxValue);

    [Benchmark]
    public double NextDouble_Pseudo() => _random.NextDouble();

    [Benchmark]
    public double NextDouble_Concurrent() => _concurrentRandom.NextDouble();

    [Benchmark]
    public void NextBytes_Pseudo() => _random.NextBytes(new byte[64]);

    [Benchmark]
    public void NextBytes_Concurrent() => _concurrentRandom.NextBytes(64);
}