using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;

namespace Depra.Random.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Enums
    {
        private IRandomizer _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();

        [Test]
        public void WhenGettingNextEnum_AndEnumTypeIsTestEnum_ThenRandomEnumIsDefined()
        {
            // Arrange.
            var randomizer = _randomizer;
            
            // Act.
            var randomEnum = randomizer.NextEnum<TestEnum>();
            
            // Assert.
            randomEnum.Should().BeDefined();
        }
        
        private enum TestEnum
        {
            A1,
            A2,
            A3
        }
    }
}