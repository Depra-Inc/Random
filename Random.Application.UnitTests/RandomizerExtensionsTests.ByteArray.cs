// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Application.Extensions;
using Depra.Random.Application.System.Collections;
using Depra.Random.Application.UnitTests.Helpers;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class ByteArray
    {
        private IArrayRandomizer<byte[]> _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandomizers().GetArrayRandomizer<byte[]>();
        
        [Test]
        public void WhenGettingNextByteArray_ThenResultingArrayLengthIsEqualInitial(
            [Values(8, 32, 64)] int bufferLength)
        {
            // Arrange.
            var randomizer = _randomizer;

            // Act.
            var byteArray = randomizer.NextBytes(bufferLength);
            ConsoleHelper.PrintBytes(byteArray);

            // Assert.
            byteArray.Should().HaveCount(bufferLength);
        }
    }
}