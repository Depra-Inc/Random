using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Double
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();

        [Test]
        public void WhenGettingNextDouble_AndRangeIsDefault_ThenRandomNumbersAreNotTheSame(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const double tolerance = 0.01;
            var randomizer = _randomizer;
            var randomNumbers = new double[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextDouble();;
            }
            
            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Any(number => Math.Abs(number - randomNumbers.First()) > tolerance).Should().BeTrue();
        }

        [Test]
        public void WhenGettingNextDouble_AndInRangeWithMinAndMax_ThenRandomNubmersAreInGivenRange(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const double minValue = double.MinValue;
            const double maxValue = double.MaxValue;
            var randomizer = _randomizer;
            var randomNumbers = new double[samplesCount];
            
            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextDouble(minValue, maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            randomNumbers.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextDouble_AndInPositiveRange_ThenRandomNumbersArePositive(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomValues = new double[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomValues[i] = randomizer.NextPositiveDouble();;
            }
            
            ConsoleHelper.PrintCollection(randomValues);

            // Assert.
            randomValues.Should().AllSatisfy(value => value.Should().BePositive());
        }

        [Test]
        public void WhenGettingNextDouble_AndInNegativeRange_ThenRandomNumbersAreNegative(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomValues = new double[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomValues[i] = randomizer.NextNegativeDouble();;
            }
            
            ConsoleHelper.PrintCollection(randomValues);

            // Assert.
            randomValues.Should().AllSatisfy(value => value.Should().BeNegative());
        }
    }
}