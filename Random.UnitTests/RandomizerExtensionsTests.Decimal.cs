using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Decimal
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();

        [Test]
        public void WhenGettingNextDecimal_AndRangeIsDefault_ThenRandomNumbersAreNotTheSame()
        {
            // Arrange.
            const int samplesCount = 100;
            var randomizer = _randomizer;
            var randomNumbers = new decimal[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextDecimal();
            }

            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Any(number => number != randomNumbers.First()).Should().BeTrue();
        }

        [Test]
        public void WhenGettingNextDecimal_AndInRangeWithMinAndMax_ThenRandomNumbersAreInGivenRange(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const decimal minValue = decimal.MinValue;
            const decimal maxValue = decimal.MaxValue;
            var randomizer = _randomizer;
            var randomNumbers = new decimal[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextDecimal(minValue, maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            randomNumbers.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextDecimal_AndInPositiveRange_ThenRandomNumbersArePositive(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new decimal[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextPositiveDecimal();
            }
            
            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Should().AllSatisfy(value => value.Should().BePositive());
        }

        [Test]
        public void WhenGettingNextDecimal_AndInNegativeRange_ThenRandomNumbersAreNegative(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new decimal[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextNegativeDecimal();;
            }
            
            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Should().AllSatisfy(value => value.Should().BeNegative());
        }
    }
}