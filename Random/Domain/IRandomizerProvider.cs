namespace Depra.Random.Domain
{
    internal interface IRandomizerProvider
    {
        IRandomizer<T> GetRandomizer<T>();
    }
}