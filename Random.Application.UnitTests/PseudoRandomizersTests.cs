// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Application.Extensions;
using Depra.Random.Application.System.Collections;
using Depra.Random.Application.UnitTests.Helpers;
using Depra.Random.Domain.Extensions;

namespace Depra.Random.Application.UnitTests;

[TestFixture(TestOf = typeof(PseudoRandomizers))]
internal class PseudoRandomizersTests
{
    private PseudoRandomizers _pseudoRandomizers = null!;

    [SetUp]
    public void SetUp() => _pseudoRandomizers = new PseudoRandomizers();

    [Test]
    public void WhenGettingNextInt32_AndRangeIsDefault_ThenRandomNumbersAreNotTheSame(
        [Values(10)] int samplesCount)
    {
        // Arrange.
        var randomNumbers = new int[samplesCount];
        var randomizer = _pseudoRandomizers.GetNumberRandomizer<int>();

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
        var randomNumbers = new int[samplesCount];
        var randomizer = _pseudoRandomizers.GetNumberRandomizer<int>();

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
        var randomNumbers = new int[samplesCount];
        var randomizer = _pseudoRandomizers.GetNumberRandomizer<int>();

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
        var randomNumbers = new double[samplesCount];
        var randomizer = _pseudoRandomizers.GetTypedRandomizer<double>();

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
        const int bufferLenght = 64;
        var buffer = new byte[bufferLenght];
        var randomizer = _pseudoRandomizers.GetArrayRandomizer<byte[]>();

        // Act.
        randomizer.Next(buffer);
        ConsoleHelper.PrintBytes(buffer);

        // Assert.
        buffer.Should().NotBeNullOrEmpty();
    }
}