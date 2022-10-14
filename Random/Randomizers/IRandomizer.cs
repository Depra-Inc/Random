namespace Depra.Random.Randomizers
{
    public interface IRandomizer
    {
        int Next();

        int Next(int maxExclusive);

        int Next(int minInclusive, int maxExclusive);

        double NextDouble();

        void NextBytes(byte[] buffer);
    }
}