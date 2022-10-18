// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections;
using Depra.Random.Application.System;
using Depra.Random.Application.UnitTests.Helpers;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.UnitTests;

[TestFixture(TestOf = typeof(CryptoRandomizer))]
internal class CryptoRandomTests
{
    private CryptoRandomizer _cryptoRandomizer = null!;

    [SetUp]
    public void SetUp() => _cryptoRandomizer = new CryptoRandomizer();

    [TearDown]
    public void TearDown() => _cryptoRandomizer.Dispose();

    [Test]
    public void WhenGettingNextInt32_AndRangeIsDefault_ThenRandomNumbersAreUnique(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        var randomizer = _cryptoRandomizer;
        var randomNumbers = new int[samplesCount];

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            randomNumbers[i] = randomizer.Next();
        }

        ConsoleHelper.PrintCollection(randomNumbers);

        // Assert.
        randomNumbers.Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void WhenGettingNextInt32_AndInRangeWithMinAndMax_ThenRandomNumbersAreUnique(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        const int minValue = int.MinValue;
        const int maxValue = int.MaxValue;
        var randomizer = _cryptoRandomizer;
        var randomNumbers = new int[samplesCount];

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            randomNumbers[i] = randomizer.Next(minValue, maxValue);
        }

        ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

        // Assert.
        randomNumbers.Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void WhenGettingNextDouble_AndRangeIsDefault_ThenRandomNumbersAreUnique(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        ITypedRandomizer<double> randomizer = _cryptoRandomizer;
        var randomNumbers = new double[samplesCount];

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            randomNumbers[i] = randomizer.Next();
        }

        ConsoleHelper.PrintCollection(randomNumbers);

        // Assert.
        randomNumbers.Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void WhenGettingNextBytes_AndBufferLength8_ThenRandomByteArraysAreUnique(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        const int bufferLength = 8;
        IArrayRandomizer<byte[]> randomizer = _cryptoRandomizer;
        var bytesStack = new Stack<byte[]>();

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            var buffer = new byte[bufferLength];
            randomizer.Next(buffer);
            bytesStack.Push(buffer);

            ConsoleHelper.PrintBytes(buffer);
        }

        // Assert.
        bytesStack.Should().OnlyHaveUniqueItems();
    }

    [Test]
    public void WhenGettingNextInt32Parallel_AndInRangeWithMinAndMax_ThenZerosNotFound(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        const int minValue = int.MinValue;
        const int maxValue = int.MaxValue;
        var randomizer = _cryptoRandomizer;
        var allThreadIssues = 0;

        // Act.
        Parallel.For(0, 16, body =>
        {
            var numbers = new int[samplesCount];
            for (var i = 0; i < samplesCount; i++)
            {
                numbers[i] = randomizer.Next(minValue, maxValue);
            }

            var threadIssues = numbers.Count(x => x == 0);
            allThreadIssues += threadIssues;

            Console.WriteLine($"Thread {body} issues: {threadIssues}");
        });

        // Assert.
        allThreadIssues.Should().Be(0);
    }

    [Test]
    public void WhenGettingNextDoubleParallel_AndRangeIsDefault_ThenZerosNotFound(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        ITypedRandomizer<double> randomizer = _cryptoRandomizer;
        var allThreadIssues = 0;

        // Act.
        Parallel.For(0, 16, body =>
        {
            var numbers = new double[samplesCount];
            for (var i = 0; i < samplesCount; i++)
            {
                numbers[i] = randomizer.Next();
            }

            var threadIssues = numbers.Count(x => x == 0);
            allThreadIssues += threadIssues;

            Console.WriteLine($"Thread {body} issues: {threadIssues}");
        });

        // Assert.
        allThreadIssues.Should().Be(0);
    }

    [Test]
    public void WhenGettingNextBytesParallel_AndBufferLength8_ThenZerosNotFound(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        const int bufferLength = 8;
        IArrayRandomizer<byte[]> randomizer = _cryptoRandomizer;
        var sourceBuffer = new byte[bufferLength];
        var allThreadIssues = 0;

        // Act.
        Parallel.For(0, 16, body =>
        {
            var results = new List<byte[]>();
            for (var i = 0; i < samplesCount; i++)
            {
                var bufferCopy = sourceBuffer.ToArray();
                randomizer.Next(bufferCopy);
                results.Add(bufferCopy);
            }

            var threadIssues = results.Count(buffer => byteArrayCompare(buffer, sourceBuffer));
            allThreadIssues += threadIssues;

            Console.WriteLine($"Thread {body} issues: {threadIssues}");
        });

        static bool byteArrayCompare(byte[] a1, byte[] a2) =>
            StructuralComparisons.StructuralEqualityComparer.Equals(a1, a2);

        // Assert.
        allThreadIssues.Should().Be(0);
    }
}