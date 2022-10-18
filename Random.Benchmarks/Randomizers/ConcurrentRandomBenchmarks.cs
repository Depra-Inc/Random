// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.System.Randoms;

namespace Depra.Random.Benchmarks.Randomizers;

public class ConcurrentRandomBenchmarks
{
    private System.Random _random;
    private ConcurrentPseudoRandom _concurrentPseudoRandom;

    [GlobalSetup]
    public void Setup()
    {
        _random = new System.Random();
        _concurrentPseudoRandom = new ConcurrentPseudoRandom();
    }
        
    [Benchmark(Baseline = true)]
    public int NextInt32_Manual() => _random.Next();

    [Benchmark]
    public int NextInt32_Concurrent() => _concurrentPseudoRandom.Next();

    [Benchmark]
    public int NextInt32_Manual_InRange() => _random.Next(int.MinValue, int.MaxValue);

    [Benchmark]
    public int NextInt32_Concurrent_InRange() => _concurrentPseudoRandom.Next(int.MinValue, int.MaxValue);

    [Benchmark]
    public double NextDouble_Manual() => _random.NextDouble();

    [Benchmark]
    public double NextDouble_Concurrent() => _concurrentPseudoRandom.NextDouble();

    [Benchmark]
    public void NextBytes_Manual() => _random.NextBytes(new byte[64]);

    [Benchmark]
    public void NextBytes_Concurrent() => _concurrentPseudoRandom.NextBytes(new byte[64]);
}