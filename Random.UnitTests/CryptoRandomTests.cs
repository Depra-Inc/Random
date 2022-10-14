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
    [TestOf(typeof(CryptoRandom))]
    internal class CryptoRandomTests
    {
        private CryptoRandom _cryptoRandom;

        [SetUp]
        public void SetUp() => _cryptoRandom = new CryptoRandom();

        [TearDown]
        public void TearDown() => _cryptoRandom.Dispose();
        
        [Test]
        public void WhenGettingRandomInteger_AndNumberOfSamplesIs1000_ThenAllValuesIsUnique()
        {
            // Arrange.
            const int samplesCount = 10_000;
            var random = _cryptoRandom;
            var numbers = new int[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                numbers[i] = random.Next(int.MinValue, int.MaxValue);
            }

            // Assert.
            numbers.Should().OnlyHaveUniqueItems();
            
        }

        [Test]
        public void WhenGettingRandomDouble_AndNumberOfSamplesIs1000_ThenAllValuesIsUnique()
        {
            // Arrange.
            const int samplesCount = 10_000;
            var random = _cryptoRandom;
            var numbers = new double[samplesCount];

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                numbers[i] = random.NextDouble();
            }

            // Assert.
            numbers.Should().OnlyHaveUniqueItems();
        }

        [Test]
        public void WhenGettingRandomBytes_AndNumberOfSamplesIs1000_ThenAllValuesIsUnique()
        {
            // Arrange.
            const int bufferLength = 8;
            const int samplesCount = 10_000;
            var random = _cryptoRandom;
            var bytesStack = new Stack<byte[]>();

            // Act.
            for (var i = 0; i < samplesCount; i++)
            {
                var buffer = new byte[bufferLength];
                random.NextBytes(buffer);
                bytesStack.Push(buffer);
            }

            // Assert.
            bytesStack.Should().OnlyHaveUniqueItems();
        }
        
        [Test]
        public void WhenGettingRandomIntegerParallel_AndNumberOfSamplesIs1000_ThenZeroesNotFound()
        {
            // Arrange.
            const int samplesCount = 10_000;
            var random = new global::System.Random();
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
            var random = _cryptoRandom;
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
            var random = _cryptoRandom;
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