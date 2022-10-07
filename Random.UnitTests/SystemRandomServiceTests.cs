using System;
using Depra.Random.System;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    public class SystemRandomServiceTests
    {
        private SystemRandomizers _systemRandomizers;

        [SetUp]
        public void Setup()
        {
            _systemRandomizers = new SystemRandomizers();
        }

        [Test]
        public void WhenTwoRandomIntegersAreTaken_AndInALoop_ThenNumbersAreNotEqual()
        {
            // Arrange.
            var randomValues = new int [100];

            // Act.
            for (var i = 0; i < randomValues.Length; i++)
            {
                randomValues[i] = _systemRandomizers.Int.Next();
                Console.WriteLine(randomValues[i]);
            }

            // Assert.
            randomValues.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void WhenRandomIntegersIsTaken_AndTakenByRange_ThenResultNumberInRange()
        {
            // Arrange.
            const int minValue = 0;
            const int maxValue = 100;

            // Act.
            var randomValue = _systemRandomizers.Int.Next(minValue, maxValue);
            Console.WriteLine($"minInclusive: {minValue}\n" +
                              $"random: {randomValue}\n" +
                              $"maxExclusive: {maxValue}");

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }
    }
}