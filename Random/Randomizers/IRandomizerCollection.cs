using System;
using System.Collections.Generic;

namespace Depra.Random.Randomizers
{
    public interface IRandomizerCollection
    {
        IRandomizer GetRandomizer(Type valueType);

        IEnumerable<IRandomizer> GetAllRandomizers();
    }
}