// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.Services
{
    /// <summary>
    /// Service providing <see cref="IRandomizer"/>.
    /// </summary>
    public interface IRandomService
    {
        IRandomizer GetRandomizer(Type valueType);
    }
}