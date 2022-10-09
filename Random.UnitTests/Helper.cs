using System;

namespace Depra.Random.UnitTests
{
    internal static class Helper
    {
        public static void PrintRandomizeResult(object result) => Console.WriteLine(result);

        public static void PrintRandomizeResult(object result, object minInclusive, object maxExclusive) =>
            Console.WriteLine($"minInclusive: {minInclusive}\n" +
                              $"random: {result}\n" +
                              $"maxExclusive: {maxExclusive}");
    }
}