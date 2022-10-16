using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    /// <summary>
    /// Service providing <see cref="IRandomizer"/>.
    /// </summary>
    public interface IRandomService
    {
        IRandomizer GetRandomizer();
    }
}