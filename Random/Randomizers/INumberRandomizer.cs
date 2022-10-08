namespace Depra.Random.Randomizers
{
    public interface INumberRandomizer<T> : IRandomizer<T>
    {
        T Next(T minInclusive, T maxExclusive);
        
        T NextPositive(T maxExclusive);

        T NextNegative(T minInclusive);
    }
}