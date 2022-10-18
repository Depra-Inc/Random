namespace Depra.Random.Domain.Randomizers
{
    public interface IArrayRandomizer<in T> : IRandomizer
    {
        void Next(T buffer);
    }
}