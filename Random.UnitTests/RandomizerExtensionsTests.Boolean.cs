using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Boolean
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();

        [Test]
        public void WhenGettingNextBooleans_AndProbabilityIsDefault_ThenRandomBooleansAreNotTheSame(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
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
            var randomizer = _randomizer;
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
            var randomizer = _randomizer;
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