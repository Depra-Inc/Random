// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.System;

namespace Depra.Random.Benchmarks.Randomizers;

[MemoryDiagnoser]
public class CryptoRandomBenchmarks
{
    private CryptoRandom _cryptoRandom;
    private global::System.Random _random;

    [GlobalSetup]
    public void SetUp()
    {
        _cryptoRandom = new CryptoRandom();
        _random = new global::System.Random();
    }

    [GlobalCleanup]
    public void TearDown() => _cryptoRandom.Dispose();

    [Benchmark(Baseline = true)]
    public int NextInt32_Pseudo() => _random.Next();

    [Benchmark]
    public int NextInt32_Crypto() => _cryptoRandom.Next();

    [Benchmark]
    public int NextInt32_Pseudo_InRange() => _random.Next(int.MinValue, int.MaxValue);

    [Benchmark]
    public int NextInt32_Crypto_InRange() => _cryptoRandom.Next(int.MinValue, int.MaxValue);

    [Benchmark]
    public double NextDouble_Pseudo() => _random.NextDouble();

    [Benchmark]
    public double NextDouble_Crypto() => _cryptoRandom.NextDouble();

    [Benchmark]
    public void NextBytes_Pseudo() => _random.NextBytes(new byte[64]);

    [Benchmark]
    public void NextBytes_Crypto() => _cryptoRandom.NextBytes(new byte[64]);
}