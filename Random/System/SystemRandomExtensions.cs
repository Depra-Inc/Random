namespace Depra.Random.System
{
    public static class SystemRandomExtensions
    {
        public static long NextLong(this global::System.Random random, long minInclusive = long.MinValue,
            long maxExclusive = long.MaxValue)
        {
            var result = (long) random.Next((int) (minInclusive >> 32), (int) (maxExclusive >> 32));
            result <<= 32;
            result |= (uint) random.Next((int) minInclusive, (int) maxExclusive);

            return result;
        }

        public static double NextDouble(this global::System.Random random, double minInclusive = double.MinValue,
            double maxExclusive = double.MaxValue)
        {
            return random.NextDouble() * (maxExclusive - minInclusive) + minInclusive;
        }

        public static void NextChars(this global::System.Random random, char[] buffer)
        {
            for (var i = 0; i < buffer.Length; ++i)
            {
                // Capping to byte value here to not exceed
                // 56 bit crypto keys length requirement by
                // Apple to avoid cryptography declaration.
                buffer[i] = (char) (random.Next() % 256);
            }
        }
    }
}