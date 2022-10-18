// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Random.Domain.Randomizers
{
    public interface INumberRandomizer<T> : ITypedRandomizer<T>
    {
        T Next(T maxExclusive);
        
        T Next(T minInclusive, T maxExclusive);
    }
}