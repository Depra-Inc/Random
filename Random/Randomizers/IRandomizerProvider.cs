namespace Depra.Random.Randomizers
{
    internal interface IRandomizerProvider
    {
        IRandomizer<T> GetRandomizer<T>();
    }
}