using System;
using Depra.Random.Application.Services;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.ServiceBuilder
{
    public interface IRandomServiceBuilder
    {
        IRandomService Build();

        IRandomServiceBuilder With(Type valueType, IRandomizer randomizer);
    }
}