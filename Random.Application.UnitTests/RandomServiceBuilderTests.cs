using Depra.Random.Application.ServiceBuilder;
using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;
using NSubstitute;

namespace Depra.Random.Application.UnitTests;

[TestFixture(TestOf = typeof(RandomServiceBuilder))]
public class RandomServiceBuilderTests
{
    private IRandomServiceBuilder _randomServiceBuilder = null!;

    [SetUp]
    public void SetUp() => _randomServiceBuilder = new RandomServiceBuilder();

    [Test]
    public void WhenBuildingRandomService_AndRegisteringRandomizerByType_ThenServiceIsBuiltAndIsNotNull()
    {
        // Arrange.
        var valueType = typeof(int);
        var intRandomizer = Substitute.For<IRandomizer>();

        // Act.
        var randomService = _randomServiceBuilder.With(valueType, intRandomizer).Build();

        // Assert.
        randomService.Should().NotBeNull();
    }

    [Test]
    public void WhenBuildingRandomService_AndRegisteringRandomizerByGenericType_ThenServiceIsBuiltAndIsNotNull()
    {
        // Arrange.
        var intRandomizer = Substitute.For<ITypedRandomizer<int>>();

        // Act.
        var randomService = _randomServiceBuilder.With(intRandomizer).Build();

        // Assert.
        randomService.Should().NotBeNull();
    }

    [Test]
    public void WhenBuildingRandomService_AndRegisteringRandomizersFromCollection_ThenServiceIsBuiltAndIsNotNull()
    {
        // Arrange.
        var randomizersCollection = Substitute.For<IRandomizerCollection>();

        // Act.
        var randomService = _randomServiceBuilder.With(randomizersCollection).Build();

        // Assert.
        randomService.Should().NotBeNull();
    }

    [Test]
    public void
        WhenBuildingRandomService_AndRegisteringRandomizerFromCollectionByType_ThenServiceIsBuiltAndIsNotNull()
    {
        // Arrange.
        var randomizerValueType = typeof(int);
        var randomizersCollection = Substitute.For<IRandomizerCollection>();

        // Act.
        var randomService = _randomServiceBuilder.With(randomizerValueType, randomizersCollection).Build();

        // Assert.
        randomService.Should().NotBeNull();
    }

    [Test]
    public void
        WhenBuildingRandomService_AndRegisteringRandomizerFromCollectionByGenericType_ThenServiceIsBuiltAndIsNotNull()
    {
        // Arrange.
        var randomizersCollection = Substitute.For<IRandomizerCollection>();

        // Act.
        var randomService = _randomServiceBuilder.With<int>(randomizersCollection).Build();

        // Assert.
        randomService.Should().NotBeNull();
    }

    [Test]
    public void WhenBuildingRandomService_AndReRegisteringRandomizerByType_ThenThrowReRegistrationException()
    {
        // Arrange.
        var randomizerValueType = typeof(int);
        var intRandomizer = Substitute.For<IRandomizer>();

        // Act.
        Action act = () => _randomServiceBuilder
            .With(randomizerValueType, intRandomizer)
            .With(randomizerValueType, intRandomizer)
            .Build();

        // Assert.
        act.Should().Throw<RandomizerForTypeAlreadyRegisteredException>();
    }

    [Test]
    public void WhenBuildingRandomService_AndReRegisteringRandomizerByGenericType_ThenThrowReRegistrationException()
    {
        // Arrange.
        var intRandomizer = Substitute.For<ITypedRandomizer<int>>();

        // Act.
        Action act = () => _randomServiceBuilder
            .With(intRandomizer)
            .With(intRandomizer)
            .Build();

        // Assert.
        act.Should().Throw<RandomizerForTypeAlreadyRegisteredException>();
    }

    [Test]
    public void
        WhenBuildingRandomService_AndReRegisteringRandomizerByTypeFromCollection_ThenThrowReRegistrationException()
    {
        // Arrange.
        var valueType = typeof(int);
        var randomizersCollection = Substitute.For<IRandomizerCollection>();

        // Act.
        Action act = () => _randomServiceBuilder
            .With(valueType, randomizersCollection)
            .With(valueType, randomizersCollection)
            .Build();

        // Assert.
        act.Should().Throw<RandomizerForTypeAlreadyRegisteredException>();
    }

    [Test]
    public void
        WhenBuildingRandomService_AndReRegisteringRandomizerByGenericTypeFromCollection_ThenThrowReRegistrationException()
    {
        // Arrange.
        var randomizersCollection = Substitute.For<IRandomizerCollection>();

        // Act.
        Action act = () => _randomServiceBuilder
            .With<int>(randomizersCollection)
            .With<int>(randomizersCollection)
            .Build();

        // Assert.
        act.Should().Throw<RandomizerForTypeAlreadyRegisteredException>();
    }
}