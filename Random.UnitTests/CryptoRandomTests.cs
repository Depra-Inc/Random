// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

[TestFixture(TestOf = typeof(CryptoRandom))]
internal class CryptoRandomTests
{
    private CryptoRandom _cryptoRandom = null!;

    [SetUp]
    public void SetUp() => _cryptoRandom = new CryptoRandom();

    [TearDown]
    public void TearDown() => _cryptoRandom.Dispose();

    [Test]
    public void WhenGettingNextInt32_AndRangeIsDefault_ThenRandomNumbersAreUnique(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        var randomizer = _cryptoRandom;
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
        var random = _cryptoRandom;
        var randomNumbers = new int[samplesCount];

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            randomNumbers[i] = random.Next(minValue, maxValue);
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
        var random = _cryptoRandom;
        var randomNumbers = new double[samplesCount];

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            randomNumbers[i] = random.NextDouble();
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
        var random = _cryptoRandom;
        var bytesStack = new Stack<byte[]>();

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            var buffer = new byte[bufferLength];
            random.NextBytes(buffer);
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
        var random = _cryptoRandom;
        var allThreadIssues = 0;

        // Act.
        Parallel.For(0, 16, body =>
        {
            var numbers = new int[samplesCount];
            for (var i = 0; i < samplesCount; i++)
            {
                numbers[i] = random.Next(minValue, maxValue);
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
        var random = _cryptoRandom;
        var allThreadIssues = 0;

        // Act.
        Parallel.For(0, 16, body =>
        {
            var numbers = new double[samplesCount];
            for (var i = 0; i < samplesCount; i++)
            {
                numbers[i] = random.NextDouble();
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
        var random = _cryptoRandom;
        var sourceBuffer = new byte[bufferLength];
        var allThreadIssues = 0;

        // Act.
        Parallel.For(0, 16, body =>
        {
            var results = new List<byte[]>();
            for (var i = 0; i < samplesCount; i++)
            {
                var bufferCopy = sourceBuffer.ToArray();
                random.NextBytes(bufferCopy);
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