using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Internal;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    internal static partial class RandomizerExtensionsTests
    {
        [TestFixture]
        public class Double
        {
            private IRandomizer _random;

            [SetUp]
            public void SetUp() => _random = new SystemRandomizer();
            
            [Test]
            public void WhenGettingRandomDouble_AndRanging_ThenResultIsInRange()
            {
                // Arrange.
                var minValue = int.MinValue;
                var maxValue = int.MaxValue;

                // Act.
                var randomValue = _random.Next(minValue, maxValue);
                Helper.PrintRandomizeResult(randomValue, minValue, maxValue);

                // Assert.
                randomValue.Should().BeInRange(minValue, maxValue);
            }
        }
    }
}