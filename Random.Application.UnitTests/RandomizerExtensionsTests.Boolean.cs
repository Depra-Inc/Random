// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Application.Extensions;
using Depra.Random.Application.System.Collections;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Boolean
    {
        private INumberRandomizer<int> _intRandomizer = null!;
        private ITypedRandomizer<double> _doubleRandomizer = null!;

        [SetUp]
        public void SetUp()
        {
            var randomizers = new PseudoRandomizers();
            _intRandomizer = randomizers.GetNumberRandomizer<int>();
            _doubleRandomizer = randomizers.GetTypedRandomizer<double>();
        }

        [Test]
        public void WhenGettingNextBooleans_AndProbabilityIsDefault_ThenRandomBooleansAreNotTheSame(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _intRandomizer;
            var randomBooleans = new bool[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomBooleans[i] = randomizer.NextBoolean();
            }

            // Assert.
            randomBooleans.Should().Contain(true).And.Contain(false);
        }

        [Test]
        public void WhenGettingNextBoolean_AndProbabilityIsOne_ThenRandomBooleansAreAlwaysTrue(
            [Values(1000)] int samplesCount)
        {
            // Arrange.
            const int probability = 1;
            var randomizer = _doubleRandomizer;
            var randomBooleans = new bool[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomBooleans[i] = randomizer.NextBoolean(probability);
            }

            // Assert.
            randomBooleans.Should().AllBeEquivalentTo(true);
        }

        [Test]
        public void WhenGettingNextBoolean_AndProbabilityIsZero_ThenRandomBooleansAreAlwaysFalse(
            [Values(1000)] int samplesCount)
        {
            // Arrange.
            const int probability = 0;
            var randomizer = _doubleRandomizer;
            var randomBooleans = new bool[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomBooleans[i] = randomizer.NextBoolean(probability);
            }

            // Assert.
            randomBooleans.Should().AllBeEquivalentTo(false);
        }
    }
}