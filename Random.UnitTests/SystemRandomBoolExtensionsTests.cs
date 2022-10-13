using Depra.Random.System;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    public class SystemRandomBoolExtensionsTests
    {
        private global::System.Random _random;

        [SetUp]
        public void SetUp() => _random = new global::System.Random();

        [Test]
        public void WhenGettingRandomBoolean_AndProbabilityIsOne_ThenResultIsAlwaysTrue()
        {
            // Arrange.
            const int probability = 1;
            const int samplesCount = 1000;
            var randomValues = new bool[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomValues[i] = _random.NextBoolean(probability);
            }

            // Assert.
            randomValues.Should().AllBeEquivalentTo(true);
        }

        [Test]
        public void WhenGettingRandomBoolean_AndProbabilityIsZero_ThenResultIsAlwaysFalse()
        {
            // Arrange.
            const int probability = 0;
            const int samplesCount = 1000;
            var randomValues = new bool[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomValues[i] = _random.NextBoolean(probability);
            }

            // Assert.
            randomValues.Should().AllBeEquivalentTo(false);
        }
    }
}