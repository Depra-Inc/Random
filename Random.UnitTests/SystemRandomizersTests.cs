using System.Collections.Generic;
using System.Threading.Tasks;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Internal;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    internal class SystemRandomizersTests
    {
        private static IEnumerable<IRandomizer> GetRandomizers()
        {
            yield return new SystemRandomizer();
            yield return new ConcurrentRandom();
        }
        
        [Test]
        public void WhenGettingRandomValue_ThenResultInGivenRange(
            [ValueSource(nameof(GetRandomizers))] IRandomizer randomizer)
        {
            // Arrange.

            // Act.
            var randomValue = randomizer.Next();
            Helper.PrintRandomizeResult(randomValue);

            // Assert.
        }

        [Test]
        public void WhenGettingRandomValue_AndRanging_ThenResultInGivenRange(
            [ValueSource(nameof(GetRandomizers))] IRandomizer randomizer)
        {
            // Arrange.
            var minValue = int.MinValue;
            var maxValue = int.MaxValue;

            // Act.
            var randomValue = randomizer.Next(minValue, maxValue);
            Helper.PrintRandomizeResult(randomValue, minValue, maxValue);

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }

        // [Test]
        // public async Task WhenAsyncGettingRandomValue_ThenResultIsNotNull(
        //     [ValueSource(nameof(GetRandomizers))] IRandomizer randomizer)
        // {
        //     // Arrange.
        //
        //     // Act.
        //     var randomValue = await randomizer.NextAsync();
        //     Helper.PrintRandomizeResult(randomValue);
        //
        //     // Assert.
        //     randomValue.Should().NotBeNull();
        // }

        // [Test]
        // public async Task WhenAsyncGettingRandomValue_AndRanging_ThenResultInGivenRange(
        //     [ValueSource(nameof(GetRandomizers))] IRandomizer randomizer)
        // {
        //     // Arrange.
        //     var minValue = int.MinValue;
        //     var maxValue = int.MaxValue;
        //
        //     // Act.
        //     var randomValue = await randomizer.NextAsync(minValue, maxValue);
        //     Helper.PrintRandomizeResult(randomValue, minValue, maxValue);
        //
        //     // Assert.
        //     randomValue.Should().BeInRange(minValue, maxValue);
        // }
    }
}