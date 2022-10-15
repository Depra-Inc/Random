using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Helpers;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Chars
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new StandardRandomizer();

        [Test]
        public void WhenGettingNextChars_AndUsingBuffer_ThenRandomCharArrayIsNotNullOrEmpty(
            [Values(10, 50, 100)] int bufferLenght)
        {
            // Arrange.
            var randomizer = _randomizer;
            var buffer = new char[bufferLenght];

            // Act.
            randomizer.NextChars(buffer);
            ConsoleHelper.PrintCollection(buffer);

            // Assert.
            buffer.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void WhenGettingNextChars_AndNotIncludeLowerCase_ThenResultingCharsCountIsEqualToInitialCount(
            [Values(10, 50, 100)] int charsCount)
        {
            // Arrange.
            var randomizer = _randomizer;

            // Act.
            var randomChars = randomizer.NextChars(charsCount, false).ToArray();
            ConsoleHelper.PrintCollection(randomChars);

            // Assert.
            randomChars.Should().HaveCount(charsCount);
        }
    }
}