using System;
using Depra.Random.Internal.Exceptions;
using Depra.Random.Randomizers;
using Depra.Random.Services;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    [TestOf(typeof(IRandomServiceBuilder))]
    public class RandomServiceBuilderTests
    {
        private IRandomServiceBuilder _randomServiceBuilder;

        [SetUp]
        public void Setup()
        {
            _randomServiceBuilder = new RandomServiceBuilder();
        }

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
            var intRandomizer = Substitute.For<IRandomizer<int>>();

            // Act.
            var randomService = _randomServiceBuilder.With<int>(intRandomizer).Build();
            
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
        public void WhenBuildingRandomService_AndRegisteringRandomizerFromCollectionByType_ThenServiceIsBuiltAndIsNotNull()
        {
            // Arrange.
            var valueType = typeof(int);
            var randomizersCollection = Substitute.For<IRandomizerCollection>(); 

            // Act.
            var randomService = _randomServiceBuilder.With(valueType, randomizersCollection).Build();
            
            // Assert.
            randomService.Should().NotBeNull();
        }
        
        [Test]
        public void WhenBuildingRandomService_AndRegisteringRandomizerFromCollectionByGenericType_ThenServiceIsBuiltAndIsNotNull()
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
            var valueType = typeof(int);
            var intRandomizer = Substitute.For<IRandomizer>();

            // Act.
            Action act = () => _randomServiceBuilder
                .With(valueType, intRandomizer)
                .With(valueType, intRandomizer)
                .Build();
            
            // Assert.
            act.Should().Throw<ReRegistrationException>();
        }
        
        [Test]
        public void WhenBuildingRandomService_AndReRegisteringRandomizerByGenericType_ThenThrowReRegistrationException()
        {
            // Arrange.
            var intRandomizer = Substitute.For<IRandomizer<int>>();

            // Act.
            Action act = () => _randomServiceBuilder
                .With<int>(intRandomizer)
                .With<int>(intRandomizer)
                .Build();
            
            // Assert.
            act.Should().Throw<ReRegistrationException>();
        }

        [Test]
        public void WhenBuildingRandomService_AndReRegisteringRandomizerByTypeFromCollection_ThenThrowReRegistrationException()
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
            act.Should().Throw<ReRegistrationException>();
        }
        
        [Test]
        public void WhenBuildingRandomService_AndReRegisteringRandomizerByGenericTypeFromCollection_ThenThrowReRegistrationException()
        {
            // Arrange.
            var randomizersCollection = Substitute.For<IRandomizerCollection>(); 

            // Act.
            Action act = () => _randomServiceBuilder
                .With<int>(randomizersCollection)
                .With<int>(randomizersCollection)
                .Build();
            
            // Assert.
            act.Should().Throw<ReRegistrationException>();
        }
    }
}