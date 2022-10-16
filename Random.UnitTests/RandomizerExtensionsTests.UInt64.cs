using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class UInt64
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();

        [Test]
        public void WhenGettingNextUInt64_AndNumberOfSamplesIs100_ThenRandomNumbersAreNotTheSame(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            var randomizer = _randomizer;
            var randomValues = new ulong[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomValues[i] = randomizer.NextULong();;
            }
            
            ConsoleHelper.PrintCollection(randomValues);

            // Assert.
            randomValues.Any(value => value != randomValues.First()).Should().BeTrue();
        }

        [Test]
        public void WhenGettingNextUInt64_AndInRangeWithMinAndMax_ThenRandomNumbersAreInGivenRange(
            [Values(100)] int samplesCount)
        {
            // Arrange.
            const ulong minValue = ulong.MinValue;
            const ulong maxValue = ulong.MaxValue;
            var randomizer = _randomizer;
            var randomNumbers = new ulong[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomNumbers[i] = randomizer.NextULong(minValue, maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForCollection(randomNumbers, minValue, maxValue);

            // Assert.
            randomNumbers.Should().AllSatisfy(randomNumber => randomNumber.Should().BeInRange(minValue, maxValue));
        }
    }
}