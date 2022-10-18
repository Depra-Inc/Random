// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Application.Extensions;
using Depra.Random.Application.System.Collections;
using Depra.Random.Application.UnitTests.Helpers;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Int32
    {
        private INumberRandomizer<int> _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandomizers().GetNumberRandomizer<int>();

        [Test]
        public void WhenGettingNextInt32_AndInPositiveRange_ThenRandomNumbersArePositive(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new int[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextPositiveInt();
            }

            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Should().AllSatisfy(value => value.Should().BePositive());
        }

        [Test]
        public void WhenGettingNextInt32_AndInNegativeRange_ThenRandomNumbersAreNegative(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new int[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextNegativeInt();
            }

            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Should().AllSatisfy(value => value.Should().BeNegative());
        }
    }
}