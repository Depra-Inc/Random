using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Int32
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new StandardRandomizer();

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