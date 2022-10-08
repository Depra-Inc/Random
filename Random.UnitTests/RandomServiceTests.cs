using System;
using Depra.Random.Randomizers;
using Depra.Random.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    public class RandomServiceTests
    {
        [Test]
        public void WhenGetRandomizer_AndTypeIsNotDefined_ThenThrowArgumentException()
        {
            // Arrange.
            var randomService = new RandomService();

            // Act.
            Action act = () => randomService.GetRandomizer<int>();

            // Assert.
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void WhenGetRandomizer_AndTypeIsDefined_ThenRandomizerIsNotNull()
        {
            // Arrange.
            var randomService = new RandomService();
            randomService.RegisterRandomizer(randomizer: Substitute.For<IRandomizer<int>>());

            // Act.
            var randomizer = randomService.GetRandomizer<int>();

            // Assert.
            randomizer.Should().NotBeNull();
        }
    }
}