namespace Depra.Random.Services
{
    public interface IRandomService
    {
        T GetSingle<T>();
        
        T Range<T>(T minInclusive, T maxExclusive);
    }
}