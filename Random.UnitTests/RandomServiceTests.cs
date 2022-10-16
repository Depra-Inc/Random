// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Randomizers;
using Depra.Random.Services;
using NSubstitute;

namespace Depra.Random.UnitTests;

[TestFixture(TestOf = typeof(RandomService))]
internal class RandomServiceTests
{
    [Test]
    public void WhenGetRandomizer_AndServiceWasConstructed_ThenResultingRandomizerIsEqualToInitial()
    {
        // Arrange.
        var initialRandomizer = Substitute.For<IRandomizer>();
        var randomService = new RandomService(initialRandomizer);

        // Act.
        var resultingRandomizer = randomService.GetRandomizer();

        // Assert.
        resultingRandomizer.Should().BeSameAs(initialRandomizer);
    }

    [Test]
    public void WhenTryingToCreateService_AndRandomizerIsNull_ThenNullReferenceExceptionWillBeThrown()
    {
        // Arrange.
#pragma warning disable CS8600
        IRandomizer randomizer = null;
#pragma warning restore CS8600

        // Act.
        Action act = () => _ = new RandomService(randomizer);

        // Assert.
        act.Should().Throw<NullReferenceException>();
    }
}