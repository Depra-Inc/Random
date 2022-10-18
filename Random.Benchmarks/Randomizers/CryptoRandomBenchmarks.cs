// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using BenchmarkDotNet.Attributes;
using Depra.Random.Application.System;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Benchmarks.Randomizers;

[MemoryDiagnoser]
public class CryptoRandomBenchmarks
{
    private CryptoRandomizer _cryptoRandomizer;
    private System.Random _random;

    [GlobalSetup]
    public void SetUp()
    {
        _cryptoRandomizer = new CryptoRandomizer();
        _random = new System.Random();
    }

    [GlobalCleanup]
    public void TearDown() => _cryptoRandomizer.Dispose();

    [Benchmark(Baseline = true)]
    public int NextInt32_Pseudo() => _random.Next();

    [Benchmark]
    public int NextInt32_Crypto() => _cryptoRandomizer.Next();

    [Benchmark]
    public int NextInt32_Pseudo_InRange() => _random.Next(int.MinValue, int.MaxValue);

    [Benchmark]
    public int NextInt32_Crypto_InRange() => _cryptoRandomizer.Next(int.MinValue, int.MaxValue);

    [Benchmark]
    public double NextDouble_Pseudo() => _random.NextDouble();

    [Benchmark]
    public double NextDouble_Crypto() => ((ITypedRandomizer<double>)_cryptoRandomizer).Next();

    [Benchmark]
    public void NextBytes_Pseudo() => _random.NextBytes(new byte[64]);

    [Benchmark]
    public void NextBytes_Crypto() => ((IArrayRandomizer<byte[]>)_cryptoRandomizer).Next(new byte[64]);
}