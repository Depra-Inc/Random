// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Application.Services;
using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;
using NSubstitute;

namespace Depra.Random.Application.UnitTests;

[TestFixture(TestOf = typeof(RandomService))]
internal class RandomServiceTests
{
    [Test]
    public void WhenGettingRandomizer_AndRandomizerForTypeWasRegistered_ThenResultingRandomizerIsEqualToInitial()
    {
        // Arrange.
        var randomizerValueType = typeof(int);
        var randomService = new RandomService();
        var initialRandomizer = Substitute.For<IRandomizer>();
        randomService.RegisterRandomizer(randomizerValueType, initialRandomizer);

        // Act.
        var resultingRandomizer = randomService.GetRandomizer(randomizerValueType);

        // Assert.
        resultingRandomizer.Should().BeSameAs(initialRandomizer);
    }

    [Test]
    public void WhenGettingRandomizer_AndRandomizerForTypeWasNotRegistered_ThenNotRegisteredExceptionIsThrown()
    {
        // Arrange.
        var randomizerValueType = typeof(int);
        var randomService = new RandomService();

        // Act.
        var act = () => randomService.GetRandomizer(randomizerValueType);

        // Assert.
        act.Should().Throw<RandomizerForTypeNotRegisteredException>();
    }

    [Test]
    public void WhenRegisteringRandomizer_AndRandomizerIsNull_ThenNullReferenceExceptionIsThrown()
    {
        // Arrange.
#pragma warning disable CS8600
        IRandomizer randomizer = null;
#pragma warning restore CS8600
        var randomizerValueType = typeof(int);
        var randomService = new RandomService();

        // Act.
        var act = () => randomService.RegisterRandomizer(randomizerValueType, randomizer);

        // Assert.
        act.Should().Throw<NullReferenceException>();
    }

    [Test]
    public void WhenRegisteringRandomizer_AndRandomizerForTypeIsAlreadyRegistered_ThenAlreadyExceptionIsThrown()
    {
        // Arrange.
        var randomizerValueType = typeof(int);
        var randomService = new RandomService();
        var randomizer = Substitute.For<ITypedRandomizer<int>>();
        randomService.RegisterRandomizer(randomizerValueType, randomizer);
        
        // Act.
        var act = () => randomService.RegisterRandomizer(randomizerValueType, randomizer);
        
        // Assert.
        act.Should().Throw<RandomizerForTypeAlreadyRegisteredException>();
    }

    [Test]
    public void WhenDisposingService_AndServiceContainRandomizers_ThenExceptionNotThrown()
    {
        // Arrange.
        var randomService = new RandomService();
        var randomizer = Substitute.For<ITypedRandomizer<int>>();
        randomService.RegisterRandomizer(typeof(int), randomizer);
        randomService.RegisterRandomizer(typeof(double), randomizer);
        randomService.RegisterRandomizer(typeof(byte[]), randomizer);
        
        // Act.
        var act = () => randomService.Dispose();

        // Assert.
        act.Should().NotThrow();
    }
}