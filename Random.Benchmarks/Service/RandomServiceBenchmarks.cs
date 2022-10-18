// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.ServiceBuilder;
using Depra.Random.Application.Services;
using Depra.Random.Application.System;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Service;

[MemoryDiagnoser]
public class RandomServiceBenchmarks
{
    private const int BYTE_BUFFER_SIZE = 32;

    private global::System.Random _random;
    private IRandomService _randomService;
    private ITypedRandomizer<int> _intRandomizer;
    private ITypedRandomizer<double> _doubleRandomizer;
    private IArrayRandomizer<byte[]> _bytesRandomizer;

    [GlobalSetup]
    public void Setup()
    {
        _random = new global::System.Random();

        var randomizer = new PseudoRandom();
        _intRandomizer = randomizer;
        _doubleRandomizer = randomizer;
        _bytesRandomizer = randomizer;

        _randomService = new RandomServiceBuilder()
            .With<int>(_intRandomizer)
            .With<double>(_doubleRandomizer)
            .With<byte[]>(_bytesRandomizer)
            .Build();
    }

    [Benchmark(Baseline = true)]
    public int NextInt_Manual() => _random.Next();

    [Benchmark]
    public int NextInt_Depra() => _randomService.GetTypedRandomizer<int>().Next();

    [Benchmark]
    public int NextInt_Depra_WithCache() => _intRandomizer.Next();

    [Benchmark]
    public double NextDouble_Manual() => _random.NextDouble();

    [Benchmark]
    public double NextDouble_Depra() => _randomService.GetTypedRandomizer<double>().Next();

    [Benchmark]
    public double NextDouble_Depra_WithCache() => _doubleRandomizer.Next();

    [Benchmark]
    public void NextBytes_Manual() => _random.NextBytes(new byte[BYTE_BUFFER_SIZE]);

    [Benchmark]
    public void NextBytes_Depra() => _randomService.GetArrayRandomizer<byte[]>().Next(new byte[BYTE_BUFFER_SIZE]);

    [Benchmark]
    public void NextBytes_Depra_WithCache() => _bytesRandomizer.Next(new byte[BYTE_BUFFER_SIZE]);
}