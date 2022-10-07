using System;
using System.Collections.Generic;
using Depra.Random.Randomizers;
using Depra.Random.System;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    public class RandomizerTests
    {
        private static IEnumerable<IRandomizer<int>> CreateIntRandomizers()
        {
            yield return new SystemRandomizers(() => new global::System.Random());
            yield return new SystemRandomizers(() => new ThreadSafeRandom());
        }

        [Test]
        public void WhenRandomIntegerIsTaken_AndTakenByRange_ThenResultNumberInRange(
            [ValueSource(nameof(CreateIntRandomizers))]
            IRandomizer<int> randomizer)
        {
            // Arrange.
            const int minValue = 0;
            const int maxValue = 100;

            // Act.
            var randomValue = randomizer.Next(minValue, maxValue);
            Console.WriteLine($"minInclusive: {minValue}\n" +
                              $"random: {randomValue}\n" +
                              $"maxExclusive: {maxValue}");

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }

        [Test]
        public void WhenTwoRandomIntegersAreTaken_AndTakenInALoop_ThenNoDuplicateValuesFound(
            [ValueSource(nameof(CreateIntRandomizers))]
            IRandomizer<int> randomizer)
        {
            // Arrange.
            var randomValues = new int[100];

            // Act.
            for (var i = 0; i < randomValues.Length; i++)
            {
                randomValues[i] = randomizer.Next();
                Console.WriteLine(randomValues[i]);
            }

            // Assert.
            randomValues.Should().OnlyHaveUniqueItems();
        }
    }
}