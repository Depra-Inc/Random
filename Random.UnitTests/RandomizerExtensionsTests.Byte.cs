using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Byte
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new StandardRandomizer();

        [Test]
        public void WhenGettingNextByte_AndInRangeWithMax_ThenRandomBytesAreInGivenRange(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const byte minValue = 0;
            const byte maxValue = byte.MaxValue;
            var randomizer = _randomizer;
            var randomBytes = new byte[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomBytes[i] = randomizer.NextByte(maxValue);
            }

            ConsoleHelper.PrintRandomizeResultForBytes(randomBytes, minValue, maxValue);

            // Assert.
            randomBytes.Should().AllSatisfy(@byte => @byte.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextByte_AndInRangeWithMinAndMax_ThenRandomBytesAreInGivenRange(
            [Values(10)] int samplesCount)
        {
            // Arrange.
            const byte minValue = byte.MinValue;
            const byte maxValue = byte.MaxValue;
            var randomizer = _randomizer;
            var randomBytes = new byte[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                randomBytes[i] = randomizer.NextByte(minValue, maxValue);;
            }
            
            ConsoleHelper.PrintRandomizeResultForBytes(randomBytes, minValue, maxValue);

            // Assert.
            randomBytes.Should().AllSatisfy(@byte => @byte.Should().BeInRange(minValue, maxValue));
        }

        [Test]
        public void WhenGettingNextByteArray_ThenResultingArrayLengthIsEqualInitial(
            [Values(8, 32, 64)] int bufferLength)
        {
            // Arrange.
            var randomizer = _randomizer;

            // Act.
            var byteArray = randomizer.NextBytes(bufferLength);
            ConsoleHelper.PrintBytes(byteArray);

            // Assert.
            byteArray.Should().HaveCount(bufferLength);
        }
    }
}