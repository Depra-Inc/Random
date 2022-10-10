namespace Depra.Random.Randomizers
{
    public static class RandomizerCollectionExtensions
    {
        public static IRandomizer<T> GetRandomizer<T>(this IRandomizerCollection randomizerCollection) =>
            (IRandomizer<T>) randomizerCollection.GetRandomizer(typeof(T));

        public static INumberRandomizer<T> GetNumberRandomizer<T>(this IRandomizerCollection randomizerCollection) =>
            (INumberRandomizer<T>) randomizerCollection.GetRandomizer(typeof(T));
    }
}