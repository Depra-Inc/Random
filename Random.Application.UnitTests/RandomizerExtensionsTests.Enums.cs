// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Application.System;
using Depra.Random.Domain.Extensions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.UnitTests;

internal static partial class RandomizerExtensionsTests
{
    [TestFixture]
    internal class Enums
    {
        private INumberRandomizer<int> _randomizer = null!;

        [SetUp]
        public void SetUp() => _randomizer = new PseudoRandom();

        [Test]
        public void WhenGettingNextEnum_AndEnumTypeIsTestEnum_ThenRandomEnumIsDefined()
        {
            // Arrange.
            var randomizer = _randomizer;

            // Act.
            var randomEnum = randomizer.NextEnum<TestEnum>();

            // Assert.
            randomEnum.Should().BeDefined();
        }

        private enum TestEnum
        {
            A1,
            A2,
            A3
        }
    }
}