using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Float
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new StandardRandomizer();

        [Test]
        public void WhenGettingNextFloat_AndRangeIsDefault_ThenRandomNumbersAreNotTheSame(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const float tolerance = 0.01f;
            var randomizer = _randomizer;
            var randomNumbers = new float[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextFloat();
            }

            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Any(number => Math.Abs(number - randomNumbers.First()) > tolerance).Should().BeTrue();
        }

        [Test]
        public void WhenGettingNextFloat_AndInRangeWithMinAndMax_ThenRandomNumbersAreInGivenRange(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const float minValue = float.MinValue;
            const float maxValue = float.MaxValue;
            var randomizer = _randomizer;
            var randomNumbers = new float[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextFloat(minValue, maxValue);
            }
            
            ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            randomNumbers.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextFloat_AndInPositiveRange_ThenRandomNumbersArePositive(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new float[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextPositiveFloat();
            }

            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Should().AllSatisfy(value => value.Should().BePositive());
        }

        [Test]
        public void WhenGettingNextFloat_AndInNegativeRange_ThenRandomNumbersAreNegative(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new float[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextNegativeFloat();
            }

            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Should().AllSatisfy(value => value.Should().BeNegative());
        }
    }
}