using System;
using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    public interface IRandomServiceBuilder
    {
        IRandomService Build();
        
        IRandomServiceBuilder With(Type valueType, IRandomizer randomizer);
    }
}