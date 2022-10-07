namespace Depra.Random.Randomizers
{
    public interface IRandomizer<T>
    {
        T Next();
        
        T Next(T minInclusive, T maxExclusive);
    }
}