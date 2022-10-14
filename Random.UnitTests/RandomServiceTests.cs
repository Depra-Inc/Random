using Depra.Random.Randomizers;
using Depra.Random.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    internal class RandomServiceTests
    {
        [Test]
        public void WhenGetRandomizer_AndServiceConstructed_ThenRandomizerIsNotNull()
        {
            // Arrange.
            var randomService = new RandomService(Substitute.For<IRandomizer>());

            // Act.
            var randomizer = randomService.GetRandomizer();

            // Assert.
            randomizer.Should().NotBeNull();
        }
    }
}