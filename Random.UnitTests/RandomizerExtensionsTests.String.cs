// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class String
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();

        [Test]
        public void WhenGettingNextString_AndNotIncludeLowerCase_ThenRandomStringIsNotInLowerCase(
            [Values(10, 50, 100)] int stringLength)
        {
            // Arrange.
            var randomizer = _randomizer;
            
            // Act.
            var randomString = randomizer.NextString(stringLength, false);
            Console.WriteLine(randomString);

            // Assert.
            randomString.Should().NotBeLowerCased();
            randomString.Should().HaveLength(stringLength);
        }
        
        [Test]
        public void WhenGettingNextString_AndCharsetIsAAndB_ThenRandomStringContainsOnlyAAndB(
            [Values(10, 50, 100)] int stringLength)
        {
            // Arrange.
            const string charset = "AB";
            var randomizer = _randomizer;

            // Act.
            var randomString = randomizer.NextString(stringLength, charset);
            Console.WriteLine(randomString);
            
            // Assert.
            randomString.Where(@char => @char is 'A' or 'B').Count().Should().Be(stringLength);
        }
    }
}