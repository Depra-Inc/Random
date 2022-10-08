using Depra.Random.Extensions;

namespace Depra.Random.Helpers
{
    public static class Numeric
    {
        /// <summary>
        /// Determines if a <see cref="T"/> is numeric.
        /// </summary>
        /// <typeparam name="T">Object type.</typeparam>s
        /// <returns>Type is numeric.</returns>
        public static bool IsNumericType<T>() => typeof(T).IsNumericType();
    }
}