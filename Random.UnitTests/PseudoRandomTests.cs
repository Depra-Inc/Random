// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

[TestFixture]
internal class PseudoRandomTests
{
    private PseudoRandom _pseudoRandom = null!;

    [SetUp]
    public void SetUp() => _pseudoRandom = new PseudoRandom();

    [Test]
    public void WhenGettingNextInt32_AndRangeIsDefault_ThenRandomNumbersAreNotTheSame(
        [Values(10)] int samplesCount)
    {
        // Arrange.
        var randomizer = _pseudoRandom;
        var randomNumbers = new int[samplesCount];

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            randomNumbers[i] = randomizer.Next();
        }

        ConsoleHelper.PrintCollection(randomNumbers);

        // Assert.
        randomNumbers.Any(o => o != randomNumbers.First()).Should().BeTrue();
    }

    [Test]
    public void WhenGettingNextInt32_AndInRangeWithMin_ThenRandomNumbersAreInGivenRange(
        [Values(10)] int samplesCount)
    {
        // Arrange.
        const int minValue = 0;
        const int maxValue = int.MaxValue;
        var randomizer = _pseudoRandom;
        var randomNumbers = new int[samplesCount];

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            randomNumbers[i] = randomizer.Next(maxValue);
        }

        ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

        // Assert.
        randomNumbers.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
    }

    [Test]
    public void WhenGettingNextInt32_AndInRangeWithMinAndMax_ThenRandomNumbersAreInGivenRange(
        [Values(10)] int samplesCount)
    {
        // Arrange.
        const int minValue = int.MinValue;
        const int maxValue = int.MaxValue;
        var randomizer = _pseudoRandom;
        var randomNumbers = new int[samplesCount];

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            randomNumbers[i] = randomizer.Next(minValue, maxValue);
        }

        ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

        // Assert.
        randomNumbers.Should()
            .AllSatisfy(randomizationResult => randomizationResult.Should().BeInRange(minValue, maxValue));
    }

    [Test]
    public void WhenGettingNextDouble_AndInDefaultRange_ThenRandomNumbersAreNotTheSame(
        [Values(10)] int samplesCount)
    {
        // Arrange.
        const double tolerance = 0.01;
        var randomizer = _pseudoRandom;
        var randomNumbers = new double[samplesCount];

        // Act.
        for (var i = 0; i < samplesCount; i++)
        {
            randomNumbers[i] = randomizer.NextDouble();
        }

        ConsoleHelper.PrintCollection(randomNumbers);

        // Assert.
        randomNumbers.Any(number => Math.Abs(number - randomNumbers.First()) > tolerance).Should().BeTrue();
    }

    [Test]
    public void WhenGettingNextByteArray_AndBufferWithLenght64_ThenBufferIsNotNullOrEmpty()
    {
        // Arrange.
        var randomizer = _pseudoRandom;
        var buffer = new byte[64];

        // Act.
        randomizer.NextBytes(buffer);
        ConsoleHelper.PrintBytes(buffer);

        // Assert.
        buffer.Should().NotBeNullOrEmpty();
    }
}