using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Int16
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new StandardRandomizer();

        [Test]
        public void WhenGettingNextInt16_AndRangeIsDefault_ThenRandomNumbersAreNotTheSame(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new short[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextShort();
            }

            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Any(number => number != randomNumbers.First()).Should().BeTrue();
        }

        [Test]
        public void WhenGettingNextInt16_AndInRangeWithMax_ThenRandomNumbersAreInGivenRange(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const short minValue = 0;
            const short maxValue = short.MaxValue;
            var randomizer = _randomizer;
            var randomNumbers = new short[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextShort(maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            randomNumbers.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextInt16_AndInRangeWithMinAndMax_ThenRandomNumbersAreInGivenRange(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const short minValue = short.MinValue;
            const short maxValue = short.MaxValue;
            var randomizer = _randomizer;
            var randomNumbers = new short[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextShort(minValue, maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);
        }

        [Test]
        public void WhenGettingNextInt16_AndInPositiveRange_ThenRandomNumbersArePositive(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new short[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextPositiveShort();
            }

            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Should().AllSatisfy(value => value.Should().BePositive());
        }

        [Test]
        public void WhenGettingNextInt16_AndInNegativeRange_ThenRandomNumbersAreNegative(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new short[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextNegativeShort();
            }

            ConsoleHelper.PrintCollection(randomNumbers);

            // Assert.
            randomNumbers.Should().AllSatisfy(value => value.Should().BeNegative());
        }
    }
}