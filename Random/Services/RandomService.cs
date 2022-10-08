using System;
using System.Collections.Generic;
using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    public sealed class RandomService : IRandomService
    {
        private readonly IDictionary<Type, object> _randomizers;
        
        public IRandomizer<T> GetRandomizer<T>()
        {
            if (_randomizers.TryGetValue(typeof(T), out var valueProvider) == false)
            {
                throw new ArgumentException();
            }

            var typedValueProvider = (IRandomizer<T>) valueProvider;
            return typedValueProvider;
        }
        
        public void RegisterRandomizer<T>(IRandomizer<T> valueProvider)
        {
            var valueType = typeof(T);
            if (_randomizers.ContainsKey(valueType))
            {
                throw new ArgumentException($"Random value provider for {valueType} already registered!");
            }

            _randomizers[valueType] = valueProvider;
        }
        
        public RandomService(IDictionary<Type, object> randomizers = null) =>
            _randomizers = randomizers ?? new Dictionary<Type, object>();
    }
}