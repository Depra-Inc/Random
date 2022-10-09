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
    public class DoubleRandomizersTests
    {
        private static IEnumerable<INumberRandomizer<double>> GetDoubleRandomizers()
        {
            yield return new SystemRandomizers(() => new global::System.Random());
            yield return new SystemRandomizers(() => new ThreadSafeRandom());
        }

        [Test]
        public void WhenGettingRandomValue_AndRangingFromZeroToOneHundred_ThenResultInGivenRange(
            [ValueSource(nameof(GetDoubleRandomizers))]
            INumberRandomizer<double> randomizer)
        {
            // Arrange.
            const double minValue = 0.0;
            const double maxValue = 100.0;

            // Act.
            var randomValue = randomizer.Next(minValue, maxValue);
            Helper.PrintRandomizeResult(randomValue, minValue, maxValue);

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }

        [Test]
        public void WhenGettingOneThousandRandomValues_ThenNoDuplicateValuesFound(
            [ValueSource(nameof(GetDoubleRandomizers))]
            INumberRandomizer<int> randomizer)
        {
            // Arrange.
            const int valuesCount = 1000;
            var randomValues = new int[valuesCount];

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
        public async Task WhenAsyncGettingRandomValue_ThenResultIsNotZeroOrNaN(
            [ValueSource(nameof(GetDoubleRandomizers))]
            INumberRandomizer<double> randomizer)
        {
            // Arrange.
            const double zero = 0.0;

            // Act.
            var randomValue = await randomizer.NextAsync();
            Helper.PrintRandomizeResult(randomValue);

            // Assert.
            randomValue.Should().NotBe(zero);
            randomValue.Should().NotBe(double.NaN);
        }

        [Test]
        public async Task WhenAsyncGettingRandomValueInRange_AndRangingFromZeroToOneHundred_ThenResultInGivenRange(
            [ValueSource(nameof(GetDoubleRandomizers))]
            INumberRandomizer<double> randomizer)
        {
            // Arrange.
            const double minValue = 0.0;
            const double maxValue = 100.0;

            // Act.
            var randomValue = await randomizer.NextAsync(minValue, maxValue);
            Helper.PrintRandomizeResult(randomValue, minValue, maxValue);

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }
    }
}