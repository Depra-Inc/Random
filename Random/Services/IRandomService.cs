using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    public interface IRandomService
    {
        IRandomizer GetRandomizer();
    }
}