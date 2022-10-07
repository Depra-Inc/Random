namespace Depra.Random.Domain
{
    public interface IRandomizer<T>
    {
        T Next();
        
        T Next(T minInclusive, T maxExclusive);
    }
}