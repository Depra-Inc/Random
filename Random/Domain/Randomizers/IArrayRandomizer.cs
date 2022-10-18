// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Random.Domain.Randomizers
{
    public interface IArrayRandomizer<in T> : IRandomizer
    {
        void Next(T buffer);
    }
}