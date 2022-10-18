// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Random.Application.UnitTests.Helpers;

internal static class ConsoleHelper
{
    public static void PrintCollection<T>(IEnumerable<T> collection)
    {
        foreach (var element in collection)
        {
            Console.WriteLine(element);
        }
    }

    public static void PrintRandomizeResultForCollection<T>(IEnumerable<T> collection, T minInclusive,
        T maxExclusive)
    {
        Console.WriteLine($"minInclusive: {minInclusive}\n" +
                          $"maxExclusive: {maxExclusive}\n");

        PrintCollection(collection);
    }

    public static void PrintBytes(IEnumerable<byte> bytes)
    {
        foreach (var @byte in bytes)
        {
            Console.Write(@byte + " ");
        }

        Console.WriteLine();
    }

    public static void PrintRandomizeResultForBytes(IEnumerable<byte> bytes, byte minInclusive, byte maxExclusive)
    {
        Console.WriteLine($"minInclusive: {minInclusive}\n" +
                          $"maxExclusive: {maxExclusive}\n");

        PrintBytes(bytes);
    }
        
    public static void PrintSBytes(IEnumerable<sbyte> bytes)
    {
        foreach (var @byte in bytes)
        {
            Console.Write(@byte + " ");
        }

        Console.WriteLine();
    }
        
    public static void PrintRandomizeResultForSBytes(IEnumerable<sbyte> bytes, sbyte minInclusive, sbyte maxExclusive)
    {
        Console.WriteLine($"minInclusive: {minInclusive}\n" +
                          $"maxExclusive: {maxExclusive}\n");

        PrintSBytes(bytes);
    }
}