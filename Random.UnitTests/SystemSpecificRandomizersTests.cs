using System.Collections.Generic;
using System.Threading.Tasks;
using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Internal;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture(typeof(bool))]
    public class SystemSpecificRandomizersTests<T>
    {
        private static IEnumerable<IRandomizer<T>> GetRandomizers()
        {
            yield return new SystemRandomizers(() => new global::System.Random())
                .GetRandomizer<T>();

            yield return new SystemRandomizers(() => new ConcurrentRandom())
                .GetRandomizer<T>();
        }

        [Test]
        public void WhenGettingRandomValue_ThenResultIsNotNull(
            [ValueSource(nameof(GetRandomizers))] IRandomizer<T> randomizer)
        {
            // Arrange.

            // Act.
            var randomValue = randomizer.Next();
            Helper.PrintRandomizeResult(randomValue);

            // Assert.
            randomValue.Should().NotBeNull();
        }

        [Test]
        public async Task WhenAsyncGettingRandomValue_ThenResultIsNotNull(
            [ValueSource(nameof(GetRandomizers))] IRandomizer<T> randomizer)
        {
            // Arrange.

            // Act.
            var randomValue = await randomizer.NextAsync();
            Helper.PrintRandomizeResult(randomValue);

            // Assert.
            randomValue.Should().NotBeNull();
        }
    }
}