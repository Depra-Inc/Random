namespace Depra.Random.Domain.Randomizers
{
    public interface INumberRandomizer<T> : ITypedRandomizer<T>
    {
        T Next(T maxExclusive);
        
        T Next(T minInclusive, T maxExclusive);
    }
}