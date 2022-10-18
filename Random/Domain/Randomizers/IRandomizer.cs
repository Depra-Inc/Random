// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;

namespace Depra.Random.Domain.Randomizers
{
    public interface IRandomizer
    {
        Type ValueType { get; }
    }
}