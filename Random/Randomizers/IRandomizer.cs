namespace Depra.Random.Randomizers
{
    public interface IRandomizer<out T>
    {
        T Next();
    }
}