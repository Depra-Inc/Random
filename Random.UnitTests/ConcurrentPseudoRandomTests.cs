// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Collections;
using Depra.Random.System;

namespace Depra.Random.UnitTests;

[TestFixture(TestOf = typeof(ConcurrentPseudoRandom))]
internal class ConcurrentPseudoRandomTests
{
    private ConcurrentPseudoRandom _concurrentPseudoRandom = null!;

    [SetUp]
    public void SetUp() => _concurrentPseudoRandom = new ConcurrentPseudoRandom();

    [Test]
    public void WhenGettingNextInt32Parallel_AndRangeIsDefault_ThenZerosNotFound(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        var random = _concurrentPseudoRandom;
        var allThreadIssues = 0;

        // Act.
        Parallel.For(0, 16, body =>
        {
            var randomNumbers = new int[samplesCount];
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = random.Next();
            }

            var threadIssues = randomNumbers.Count(x => x == 0);
            allThreadIssues += threadIssues;

            Console.WriteLine($"Thread {body} issues: {threadIssues}");
        });

        // Assert.
        allThreadIssues.Should().Be(0);
    }

    [Test]
    public void WhenGettingNextInt32Parallel_AndInRangeWithMinAndMax_ThenZerosNotFound(
        [Values(10_000)] int samplesCount)
    {
        // Arrange.
        const int minValue = int.MinValue;
        const int maxValue = int.MaxValue;
        var random = _concurrentPseudoRandom;
        var allThreadIssues = 0;

        // Act.
        Parallel.For(0, 16, body =>
        {
            var randomNumbers = new int[samplesCount];
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = random.Next(minValue, maxValue);
            }

            var threadIssues = randomNumbers.Count(x => x == 0);
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
        var random = _concurrentPseudoRandom;
        var allThreadIssues = 0;

        // Act.
        Parallel.For(0, 16, body =>
        {
            var randomNumbers = new double[samplesCount];
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = random.NextDouble();
            }

            var threadIssues = randomNumbers.Count(x => x == 0);
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
        var random = _concurrentPseudoRandom;
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