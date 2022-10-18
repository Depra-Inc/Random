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
    internal class CharArray
    {
        private INumberRandomizer<int> _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();

        [Test]
        public void WhenGettingNextChars_AndUsingBuffer_ThenRandomCharArrayIsNotNullOrEmpty(
            [Values(10, 50, 100)] int bufferLenght)
        {
            // Arrange.
            var randomizer = _randomizer;
            var buffer = new char[bufferLenght];

            // Act.
            randomizer.NextChars(buffer);
            ConsoleHelper.PrintCollection(buffer);

            // Assert.
            buffer.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void WhenGettingNextChars_AndNotIncludeLowerCase_ThenResultingCharsCountIsEqualToInitialCount(
            [Values(10, 50, 100)] int charsCount)
        {
            // Arrange.
            var randomizer = _randomizer;

            // Act.
            var randomChars = randomizer.NextChars(charsCount, false).ToArray();
            ConsoleHelper.PrintCollection(randomChars);

            // Assert.
            randomChars.Should().HaveCount(charsCount);
        }
    }
}