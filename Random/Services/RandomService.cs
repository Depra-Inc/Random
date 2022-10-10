using System;
using System.Collections.Generic;
using Depra.Random.Extensions;
using Depra.Random.Internal.Exceptions;
using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    public sealed class RandomService : IRandomService
    {
        private readonly IDictionary<Type, IRandomizer> _randomizers;

        public IRandomizer<T> GetRandomizer<T>()
        {
            var valueType = typeof(T);
            if (_randomizers.TryGetValue(valueType, out var randomizer) == false)
            {
                throw new NoRegistrationException(valueType);
            }

            var typedRandomizer = (IRandomizer<T>) randomizer;
            return typedRandomizer;
        }

        public INumberRandomizer<T> GetNumberRandomizer<T>()
        {
            var valueType = typeof(T);
            if (valueType.IsNumericType() == false)
            {
                throw new ArgumentException($"The type {valueType.Name} is not numeric!");
            }

            if (_randomizers.TryGetValue(valueType, out var randomizer) == false)
            {
                throw new NoRegistrationException(valueType);
            }

            var typedNumberRandomizer = (INumberRandomizer<T>) randomizer;
            return typedNumberRandomizer;
        }

        public void RegisterRandomizer<T>(IRandomizer<T> randomizer) => RegisterRandomizer(typeof(T), randomizer);

        public void RegisterRandomizer(Type valueType, IRandomizer randomizer)
        {
            if (_randomizers.ContainsKey(valueType))
            {
                throw new ReRegistrationException(valueType);
            }

            _randomizers[valueType] = randomizer;
        }

        public RandomService(IDictionary<Type, IRandomizer> randomizers = null) =>
            _randomizers = randomizers ?? new Dictionary<Type, IRandomizer>();
    }
}