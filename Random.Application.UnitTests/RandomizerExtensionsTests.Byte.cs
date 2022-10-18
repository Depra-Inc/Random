// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Application.System;
using Depra.Random.Application.UnitTests.Helpers;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Byte
    {
        private INumberRandomizer<int> _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();

        [Test]
        public void WhenGettingNextByte_AndInRangeWithMax_ThenRandomBytesAreInGivenRange(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const byte minValue = 0;
            const byte maxValue = byte.MaxValue;
            var randomizer = _randomizer;
            var randomBytes = new byte[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomBytes[i] = randomizer.NextByte(maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForBytes(randomBytes, minValue, maxValue);

            // Assert.
            randomBytes.Should().AllSatisfy(@byte => @byte.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextByte_AndInRangeWithMinAndMax_ThenRandomBytesAreInGivenRange(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const byte minValue = byte.MinValue;
            const byte maxValue = byte.MaxValue;
            var randomizer = _randomizer;
            var randomBytes = new byte[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomBytes[i] = randomizer.NextByte(minValue, maxValue);;
            }
            
            ConsoleHelper.PrintRandomizeResultForBytes(randomBytes, minValue, maxValue);

            // Assert.
            randomBytes.Should().AllSatisfy(@byte => @byte.Should().BeInRange(minValue, maxValue));
        }
    }
}