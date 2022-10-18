// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

namespace Depra.Random.Domain.Randomizers
{
    public interface ITypedRandomizer<out T> : IRandomizer
    {
        T Next();
    }
}