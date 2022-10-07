using System;
using System.Collections.Generic;
using Depra.Random.Domain;

namespace Depra.Random.Services
{
    public sealed class RandomService : RandomizerProvider, IRandomService
    {
        public T GetSingle<T>() => GetRandomizer<T>().Next();

        public T Range<T>(T min, T max) => GetRandomizer<T>().Next(min, max);

        public RandomService(IDictionary<Type, object> randomizers) : base(randomizers) { }
    }
}