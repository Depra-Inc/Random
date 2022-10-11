namespace Depra.Random.Randomizers
{
    public interface ISignedNumberRandomizer<T> : INumberRandomizer<T>
    {
        T NextNegative(T minInclusive);
    }
}