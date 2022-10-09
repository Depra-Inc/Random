using System.Collections.Generic;
using System.Threading.Tasks;
using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    public class NumberRandomizerTests
    {
        private static IEnumerable<INumberRandomizer<int>> CreateIntRandomizers()
        {
            yield return new SystemRandomizers(() => new global::System.Random());
            yield return new SystemRandomizers(() => new ThreadSafeRandom());
        }

        [Test]
        public void WhenRandomIntegerIsTaken_AndTakenByRange_ThenResultNumberInRange(
            [ValueSource(nameof(CreateIntRandomizers))]
            INumberRandomizer<int> randomizer)
        {
            // Arrange.
            const int minValue = 0;
            const int maxValue = 100;

            // Act.
            var randomValue = randomizer.Next(minValue, maxValue);
            Helper.PrintRandomizeResult(randomValue, minValue, maxValue);

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }

        [Test]
        public void WhenTwoRandomIntegersAreTaken_AndTakenInALoop_ThenNoDuplicateValuesFound(
            [ValueSource(nameof(CreateIntRandomizers))]
            INumberRandomizer<int> randomizer)
        {
            // Arrange.
            var randomValues = new int[100];

            // Act.
            for (var i = 0; i < randomValues.Length; i++)
            {
                randomValues[i] = randomizer.Next();
                Helper.PrintRandomizeResult(randomValues[i]);
            }

            // Assert.
            randomValues.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public async Task WhenAsyncGettingRandomValue_AndValueTypeIsInteger_ThenResultIsNotZero(
            [ValueSource(nameof(CreateIntRandomizers))]
            INumberRandomizer<int> randomizer)
        {
            // Arrange.
            const int zero = 0;

            // Act.
            var randomValue = await randomizer.NextAsync();
            Helper.PrintRandomizeResult(randomValue);

            // Assert.
            randomValue.Should().NotBe(zero);
        }

        [Test]
        public async Task WhenAsyncGettingRandomValueInRange_AndValueTypeIsInteger_ThenResultInGivenRange(
            [ValueSource(nameof(CreateIntRandomizers))]
            INumberRandomizer<int> randomizer)
        {
            // Arrange.
            const int minValue = 0;
            const int maxValue = 100;

            // Act.
            var randomValue = await randomizer.NextAsync(minValue, maxValue);
            Helper.PrintRandomizeResult(randomValue, minValue, maxValue);
            
            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }
    }
}