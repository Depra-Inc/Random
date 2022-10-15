using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class SByte
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new StandardRandomizer();

        [Test]
        public void WhenGettingNextSByte_AndRangeIsDefault_ThenRandomBytesAreNotTheSame(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomNumbers = new sbyte[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextSByte();
            }

            ConsoleHelper.PrintSBytes(randomNumbers);

            // Assert.
            randomNumbers.Any(value => value != randomNumbers.First()).Should().BeTrue();
        }

        [Test]
        public void WhenGettingNextSByte_AndInRangeWithMax_ThenRandomBytesAreInGivenRange(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const sbyte minValue = 0;
            const sbyte maxValue = sbyte.MaxValue;
            var randomizer = _randomizer;
            var randomSBytes = new sbyte[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomSBytes[i] = randomizer.NextSByte(maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForSBytes(randomSBytes, minValue, maxValue);

            // Assert.
            randomSBytes.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextSByte_AndInRangeWithMinAndMax_ThenRandomBytesAreInGivenRange(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const sbyte minValue = sbyte.MinValue;
            const sbyte maxValue = sbyte.MaxValue;
            var randomizer = _randomizer;
            var randomSBytes = new sbyte[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomSBytes[i] = randomizer.NextSByte(minValue, maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForSBytes(randomSBytes, minValue, maxValue);

            // Assert.
            randomSBytes.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextSByte_AndInPositiveRange_ThenRandomBytesArePositive(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomSBytes = new sbyte[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomSBytes[i] = randomizer.NextPositiveSByte();
            }

            ConsoleHelper.PrintSBytes(randomSBytes);

            // Assert.
            randomSBytes.Should().AllSatisfy(value => value.Should().BePositive());
        }

        [Test]
        public void WhenGettingNextSByte_AndInNegativeRange_ThenRandomBytesAreNegative(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomSBytes = new sbyte[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomSBytes[i] = randomizer.NextNegativeSByte();
            }

            ConsoleHelper.PrintSBytes(randomSBytes);

            // Assert.
            randomSBytes.Should().AllSatisfy(value => value.Should().BeNegative());
        }
    }
}