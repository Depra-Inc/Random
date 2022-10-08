using System;
using Depra.Random.Randomizers;
using Depra.Random.Services;
using Depra.Random.System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    public class RandomServiceTests
    {
        private IRandomizer<int> _randomizer;
        private RandomService _randomService;

        [SetUp]
        public void Setup()
        {
            _randomizer = Substitute.For<IRandomizer<int>>();
            _randomService = new RandomService();
        }

        [Test]
        public void WhenGetRandomizer_AndTypeIsNotDefined_ThenThrowArgumentException()
        {
            // Arrange.

            // Act.
            Action act = () => _randomService.GetRandomizer<int>();

            // Assert.
            act.Should().Throw<ArgumentException>();
        }

        [Test]
        public void WhenGetRandomizer_AndTypeIsDefined_ThenRandomizerIsNotNull()
        {
            // Arrange.
            _randomService.RegisterRandomizer(_randomizer);

            // Act.
            var randomizer = _randomService.GetRandomizer<int>();

            // Assert.
            randomizer.Should().NotBeNull();
        }
    }
}