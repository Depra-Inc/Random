namespace Depra.Random.Domain.Randomizers
{
    public interface ITypedRandomizer<out T> : IRandomizer
    {
        T Next();
    }
}