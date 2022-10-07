using System;
using System.Collections.Generic;

namespace Depra.Random.Domain
{
    public abstract class RandomizerProvider : IRandomizerProvider
    {
        private readonly IDictionary<Type, object> _randomizers;

        public void RegisterRandomizer<T>(IRandomizer<T> valueProvider)
        {
            var valueType = typeof(T);
            if (_randomizers.ContainsKey(valueType))
            {
                throw new ArgumentException($"Random value provider for {valueType} already registered!");
            }

            _randomizers[valueType] = valueProvider;
        }

        public IRandomizer<T> GetRandomizer<T>()
        {
            if (_randomizers.TryGetValue(typeof(T), out var valueProvider) == false)
            {
                throw new ArgumentException();
            }

            var typedValueProvider = (IRandomizer<T>) valueProvider;
            return typedValueProvider;
        }

        protected RandomizerProvider(IDictionary<Type, object> randomizers) =>
            _randomizers = randomizers ?? new Dictionary<Type, object>();
    }
}