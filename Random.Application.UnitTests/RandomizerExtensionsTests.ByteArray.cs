using Depra.Random.Application.System;
using Depra.Random.Application.UnitTests.Helpers;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class ByteArray
    {
        private IArrayRandomizer<byte[]> _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();
        
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