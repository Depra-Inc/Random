using System;

namespace Depra.Random.Randomizers
{
    public interface IRandomizer
    {
        Type ValueType { get; }
    }
    
    public interface IRandomizer<out T> : IRandomizer
    {
        T Next();
    }
}