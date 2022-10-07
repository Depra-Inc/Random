namespace Depra.Random.Randomizers
{
    public interface INumberRandomizer<T> : IRandomizer<T>
    {
        T NextPositive(T maxExclusive);

        T NextNegative(T minInclusive);
    }
}