using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Depra.Random.System;
using FluentAssertions;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    [TestOf(typeof(ConcurrentRandom))]
    internal class ConcurrentRandomTests
    {
        private ConcurrentRandom _concurrentRandom;

        [SetUp]
        public void SetUp() => _concurrentRandom = new ConcurrentRandom();

        [Test]
        public void WhenGettingRandomIntegerParallel_AndNumberOfSamplesIs1000_ThenZeroesNotFound()
        {
            // Arrange.
            const int samplesCount = 10_000;
            var random = _concurrentRandom;
            var allThreadIssues = 0;

            // Act.
            Parallel.For(0, 16, body =>
            {
                var numbers = new int[samplesCount];
                for (var i = 0; i < samplesCount; i++)
                {
                    numbers[i] = random.Next(int.MinValue, int.MaxValue);
                }

                var threadIssues = numbers.Count(x => x == 0);
                allThreadIssues += threadIssues;

                Console.WriteLine($"Thread {body} issues: {threadIssues}");
            });

            // Assert.
            allThreadIssues.Should().Be(0);
        }

        [Test]
        public void WhenGettingRandomDoubleParallel_AndNumberOfSamplesIs1000_ThenZeroesNotFound()
        {
            // Arrange.
            const int samplesCount = 10_000;
            var random = _concurrentRandom;
            var allThreadIssues = 0;

            // Act.
            Parallel.For(0, 16, body =>
            {
                var numbers = new double[samplesCount];
                for (var i = 0; i < samplesCount; i++)
                {
                    numbers[i] = random.NextDouble();
                }

                var threadIssues = numbers.Count(x => x == 0);
                allThreadIssues += threadIssues;

                Console.WriteLine($"Thread {body} issues: {threadIssues}");
            });

            // Assert.
            allThreadIssues.Should().Be(0);
        }

        [Test]
        public void WhenGettingRandomBytesParallel_AndNumberOfSamplesIs1000_ThenZeroesNotFound()
        {
            // Arrange.
            const int bufferLength = 8;
            const int samplesCount = 10_000;
            var random = _concurrentRandom;
            var sourceBuffer = new byte[bufferLength];
            var allThreadIssues = 0;

            // Act.
            Parallel.For(0, 16, body =>
            {
                var results = new List<byte[]>();
                for (var i = 0; i < samplesCount; i++)
                {
                    var bufferCopy = sourceBuffer.ToArray();
                    random.NextBytes(bufferCopy);
                    results.Add(bufferCopy);
                }

                var threadIssues = results.Count(buffer => byteArrayCompare(buffer, sourceBuffer));
                allThreadIssues += threadIssues;

                Console.WriteLine($"Thread {body} issues: {threadIssues}");
            });

            static bool byteArrayCompare(byte[] a1, byte[] a2) =>
                StructuralComparisons.StructuralEqualityComparer.Equals(a1, a2);

            // Assert.
            allThreadIssues.Should().Be(0);
        }
    }
}