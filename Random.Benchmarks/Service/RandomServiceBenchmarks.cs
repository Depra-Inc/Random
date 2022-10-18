// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.ServiceBuilder;
using Depra.Random.Application.Services;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Service;

public class RandomServiceBenchmarks
{
    private System.Random _random;
    private IRandomService _randomService;
    private ITypedRandomizer<int> _intRandomizer;
    private ITypedRandomizer<double> _doubleRandomizer;
    private IArrayRandomizer<byte[]> _bytesRandomizer;

    [Params(8)]
    public int BufferSize { get; set; }
    
    [GlobalSetup]
    public void Setup()
    {
        _random = new System.Random();

        var pseudoRandomizers = new PseudoRandomizers();
        _intRandomizer = (ITypedRandomizer<int>) pseudoRandomizers.GetRandomizer(typeof(int));
        _doubleRandomizer = (ITypedRandomizer<double>) pseudoRandomizers.GetRandomizer(typeof(double));
        _bytesRandomizer = (IArrayRandomizer<byte[]>) pseudoRandomizers.GetRandomizer(typeof(byte[]));

        _randomService = new RandomServiceBuilder()
            .With(pseudoRandomizers)
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
    public void NextBytes_Manual() => _random.NextBytes(new byte[BufferSize]);

    [Benchmark]
    public void NextBytes_Depra() =>
        _randomService.GetArrayRandomizer<byte[]>().Next(new byte[BufferSize]);

    [Benchmark]
    public void NextBytes_Depra_WithCache() => _bytesRandomizer.Next(new byte[BufferSize]);
}