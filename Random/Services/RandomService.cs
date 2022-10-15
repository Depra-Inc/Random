using System;
using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    public sealed class RandomService : IRandomService
    {
        private readonly IRandomizer _randomizer;

        public IRandomizer GetRandomizer() => _randomizer;

        public RandomService(IRandomizer randomizer) =>
            _randomizer = randomizer ?? throw new NullReferenceException("Randomizer is null!");
    }
}