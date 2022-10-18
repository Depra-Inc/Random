using System;
using System.Collections.Generic;

namespace Depra.Random.Domain.Randomizers
{
    public interface IRandomizer
    {
        IEnumerable<Type> ValueTypes { get; }
    }
}