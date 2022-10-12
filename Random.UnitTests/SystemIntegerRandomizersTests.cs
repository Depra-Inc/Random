using System;
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
    [TestFixture(sbyte.MinValue, sbyte.MaxValue, sbyte.MinValue + sbyte.MaxValue, TypeArgs = new[] { typeof(sbyte) })]
    [TestFixture(byte.MinValue, byte.MaxValue, byte.MinValue + byte.MaxValue, TypeArgs = new[] { typeof(byte) })]
    [TestFixture(short.MinValue, short.MaxValue, short.MinValue + short.MaxValue, TypeArgs = new[] { typeof(short) })]
    [TestFixture(ushort.MinValue, ushort.MaxValue, ushort.MinValue + ushort.MaxValue, TypeArgs = new[] { typeof(ushort) })]
    [TestFixture(int.MinValue, int.MaxValue, int.MinValue + int.MaxValue, TypeArgs = new[] { typeof(int) })]
    [TestFixture(uint.MinValue, uint.MaxValue, uint.MinValue + uint.MaxValue, TypeArgs = new[] { typeof(uint) })]
    [TestFixture(long.MinValue, long.MaxValue, long.MinValue + long.MaxValue, TypeArgs = new[] { typeof(long) })]
    [TestFixture(ulong.MinValue, ulong.MaxValue, ulong.MinValue + ulong.MaxValue, TypeArgs = new[] { typeof(ulong) })]
    [TestFixture(float.MinValue, float.MaxValue, float.MinValue + float.MaxValue, TypeArgs = new[] { typeof(float) })]
    [TestFixture(double.MinValue, double.MaxValue, double.MinValue + double.MaxValue, TypeArgs = new[] { typeof(double) })]
    public class SystemIntegerRandomizersTests<T> where T : IComparable<T>
    {
        private readonly T _minValue;
        private readonly T _maxValue;
        private readonly double _numberOfPossibleValues;

        public SystemIntegerRandomizersTests(T minValue, T maxValue, double numberOfPossibleValues)
        {
            _minValue = minValue;
            _maxValue = maxValue;
            _numberOfPossibleValues = numberOfPossibleValues;
        }

        private static IEnumerable<INumberRandomizer<T>> GetRandomizers()
        {
            yield return new SystemRandomizers(() => new global::System.Random())
                .GetNumberRandomizer<T>();

            yield return new SystemRandomizers(() => new ConcurrentRandom())
                .GetNumberRandomizer<T>();
        }

        [Test]
        public void WhenGettingRandomValue_AndRanging_ThenResultInGivenRange(
            [ValueSource(nameof(GetRandomizers))] INumberRandomizer<T> randomizer)
        {
            // Arrange.
            var minValue = _minValue;
            var maxValue = _maxValue;

            // Act.
            var randomValue = randomizer.Next(_minValue, _maxValue);
            Helper.PrintRandomizeResult(randomValue, minValue, maxValue);

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }

        [Test]
        public async Task WhenAsyncGettingRandomValue_ThenResultIsNotNull(
            [ValueSource(nameof(GetRandomizers))] INumberRandomizer<T> randomizer)
        {
            // Arrange.

            // Act.
            var randomValue = await randomizer.NextAsync();
            Helper.PrintRandomizeResult(randomValue);

            // Assert.
            randomValue.Should().NotBeNull();
        }

        [Test]
        public async Task WhenAsyncGettingRandomValue_AndRanging_ThenResultInGivenRange(
            [ValueSource(nameof(GetRandomizers))] INumberRandomizer<T> randomizer)
        {
            // Arrange.
            var minValue = _minValue;
            var maxValue = _maxValue;

            // Act.
            var randomValue = await randomizer.NextAsync(minValue, maxValue);
            Helper.PrintRandomizeResult(randomValue, minValue, maxValue);

            // Assert.
            randomValue.Should().BeInRange(minValue, maxValue);
        }
    }
}