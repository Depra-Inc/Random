// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Random.Randomizers
{
    /// <summary>
    /// Contract for random number generator.
    /// </summary>
    public interface IRandomizer
    {
        int Next();

        int Next(int maxExclusive);

        int Next(int minInclusive, int maxExclusive);

        double NextDouble();

        void NextBytes(byte[] buffer);
    }
}