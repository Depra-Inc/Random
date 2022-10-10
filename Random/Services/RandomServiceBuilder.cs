using System;
using System.Collections.Generic;
using Depra.Random.Internal.Exceptions;
using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    public class RandomServiceBuilder : IRandomServiceBuilder
    {
        private readonly IDictionary<Type, IRandomizer> _randomizers;

        public IRandomService Build() => new RandomService(_randomizers);

        public IRandomServiceBuilder With(Type valueType, IRandomizer randomizer)
        {
            if (_randomizers.ContainsKey(valueType))
            {
                throw new ReRegistrationException(valueType);
            }

            _randomizers[valueType] = randomizer;
            return this;
        }
        
        public RandomServiceBuilder() => _randomizers = new Dictionary<Type, IRandomizer>();
    }
}