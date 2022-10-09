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
    public class LongRandomizersTests
    {
        private static IEnumerable<INumberRandomizer<long>> GetLongRandomizers()
        {
            yield return new SystemRandomizers(() => new global::System.Random());
            yield return new SystemRandomizers(() => new ThreadSafeRandom());
        }

        [Test]
        public void WhenGettingRandomValue_AndRangingFromZeroToOneHundred_ThenResultInGivenRange(
            [ValueSource(nameof(GetLongRandomizers))]
            INumberRandomizer<long> randomizer)
        {
            // Arrange.
            const long minValue = 0_0L;
            const long maxValue = 100_0L;

            // Act.
            var randomValue = randomizer.Next(minValue, maxValue);
            Helper.PrintRandomizeResult(randomValue, minValue, maxValue);

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }

        [Test]
        public void WhenGettingOneThousandRandomValues_ThenNoDuplicateValuesFound(
            [ValueSource(nameof(GetLongRandomizers))]
            INumberRandomizer<long> randomizer)
        {
            // Arrange.
            const int valuesCount = 1000;
            var randomValues = new long[valuesCount];

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
            [ValueSource(nameof(GetLongRandomizers))]
            INumberRandomizer<long> randomizer)
        {
            // Arrange.
            const long zero = 0;

            // Act.
            var randomValue = await randomizer.NextAsync();
            Helper.PrintRandomizeResult(randomValue);

            // Assert.
            randomValue.Should().NotBe(zero);
        }

        [Test]
        public async Task WhenAsyncGettingRandomValue_AndRangingFromZeroToOneHundred_ThenResultInGivenRange(
            [ValueSource(nameof(GetLongRandomizers))]
            INumberRandomizer<long> randomizer)
        {
            // Arrange.
            const long minValue = 0_0L;
            const long maxValue = 100_0L;

            // Act.
            var randomValue = await randomizer.NextAsync(minValue, maxValue);
            Helper.PrintRandomizeResult(randomValue, minValue, maxValue);

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }
    }
}