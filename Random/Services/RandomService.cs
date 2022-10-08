using System;
using System.Collections.Generic;
using System.Reflection;
using Depra.Random.Extensions;
using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    public sealed class RandomService : IRandomService
    {
        private readonly IDictionary<Type, object> _randomizers;

        public IRandomizer<T> GetRandomizer<T>()
        {
            var valueType = typeof(T);
            if (_randomizers.TryGetValue(valueType, out var randomizer) == false)
            {
                ThrowNoRegistrationException(valueType);
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
                ThrowNoRegistrationException(valueType);
            }

            var typedNumberRandomizer = (INumberRandomizer<T>) randomizer;
            return typedNumberRandomizer;
        }

        public void RegisterRandomizer<T>(IRandomizer<T> randomizer)
        {
            var valueType = typeof(T);
            if (_randomizers.ContainsKey(valueType))
            {
                ThrowReRegistrationException(valueType);
            }

            _randomizers[valueType] = randomizer;
        }

        public RandomService(IDictionary<Type, object> randomizers = null) =>
            _randomizers = randomizers ?? new Dictionary<Type, object>();

        private static void ThrowReRegistrationException(MemberInfo type) =>
            throw new ArgumentException($"Randomizer for {type.Name} already registered!");

        private static void ThrowNoRegistrationException(MemberInfo type) =>
            throw new ArgumentException($"Randomizer for type {type.Name} is not registered!");
    }
}