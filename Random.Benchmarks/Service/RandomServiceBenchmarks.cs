// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Services;
using Depra.Random.System;

namespace Depra.Random.Benchmarks.Service;

[MemoryDiagnoser]
public class RandomServiceBenchmarks
{
    private global::System.Random _random;
    private IRandomService _randomService;

    [GlobalSetup]
    public void Setup()
    {
        _random = new global::System.Random();
        _randomService = new RandomService(new PseudoRandom());
    }

    [Benchmark(Baseline = true)]
    public int NextInt_Manual() => _random.Next();

    [Benchmark]
    public int NextInt_Depra() => _randomService.GetRandomizer().Next();

    [Benchmark]
    public double NextDouble_Manual() => _random.NextDouble();

    [Benchmark]
    public double NextDouble_Depra() => _randomService.GetRandomizer().NextDouble();
}