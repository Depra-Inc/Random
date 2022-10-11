using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Depra.Random.Extensions;
using Depra.Random.Randomizers;
using Depra.Random.System;
using Depra.Random.UnitTests.Internal;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture(sbyte.MinValue, sbyte.MaxValue, sbyte.MinValue + sbyte.MaxValue, TypeArgs = new[] {typeof(sbyte)})]
    [TestFixture(byte.MinValue, byte.MaxValue, byte.MinValue + byte.MaxValue, TypeArgs = new[] {typeof(byte)})]
    [TestFixture(short.MinValue, short.MaxValue, short.MinValue + short.MaxValue, TypeArgs = new[] {typeof(short)})]
    [TestFixture(ushort.MinValue, ushort.MaxValue, ushort.MinValue + ushort.MaxValue, TypeArgs = new[] {typeof(ushort)})]
    [TestFixture(int.MinValue, int.MaxValue, int.MinValue + int.MaxValue, TypeArgs = new[] {typeof(int)})]
    [TestFixture(uint.MinValue, uint.MaxValue, uint.MinValue + uint.MaxValue, TypeArgs = new[] {typeof(uint)})]
    [TestFixture(long.MinValue, long.MaxValue, long.MinValue + long.MaxValue, TypeArgs = new[] {typeof(long)})]
    [TestFixture(ulong.MinValue, ulong.MaxValue, ulong.MinValue + ulong.MaxValue, TypeArgs = new[] {typeof(ulong)})]
    [TestFixture(float.MinValue, float.MaxValue, float.MinValue + float.MaxValue, TypeArgs = new[] {typeof(float)})]
    [TestFixture(double.MinValue, double.MaxValue, double.MinValue + double.MaxValue, TypeArgs = new[] {typeof(double)})]
    //[TestFixture(decimal.MinValue, decimal.MaxValue, TypeArgs = new []{typeof(decimal)})]
    public class SystemNumberRandomizersTests<T> where T : IComparable<T>
    {
        private readonly T _minValue;
        private readonly T _maxValue;
        private readonly double _numberOfPossibleValues;

        public SystemNumberRandomizersTests(T minValue, T maxValue, double numberOfPossibleValues)
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
        public void WhenGettingOneThousandRandomValues_ThenNoDuplicateValuesFound(
            [ValueSource(nameof(GetRandomizers))] INumberRandomizer<T> randomizer)
        {
            // Arrange.
            const int valuesCount = 1000;
            var randomValues = new T[valuesCount];

            // Act.
            for (var i = 0; i < randomValues.Length; i++)
            {
                randomValues[i] = randomizer.Next();
            }

            // TODO: Finalize
            var collisionsCount = FindCollisionsCount(randomValues);
            var collisionsProbability = collisionsCount / (double) valuesCount;
            var expectedCollisionProbability =
                BirthdayProblemHelper.GetCollisionProbability(_numberOfPossibleValues, valuesCount);

            // Assert.
            Console.WriteLine(collisionsProbability);
            Console.WriteLine(expectedCollisionProbability);
            randomValues.Should().OnlyHaveUniqueItems();
        }

        private static int FindCollisionsCount(IEnumerable<T> values) =>
            values.GroupBy(x => x).Where(g => g.Count() > 1).Count();

        private static IDictionary<T, int> FindCollisions(IEnumerable<T> values) => values.GroupBy(x => x)
            .Where(g => g.Count() > 1)
            .ToDictionary(x => x.Key, y => y.Count());

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