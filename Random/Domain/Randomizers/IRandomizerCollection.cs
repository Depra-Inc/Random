// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;

namespace Depra.Random.Domain.Randomizers
{
    public interface IRandomizerCollection
    {
        IRandomizer GetRandomizer(Type valueType);

        IEnumerable<IRandomizer> GetAllRandomizers();
    }
}