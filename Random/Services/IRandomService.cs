// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    /// <summary>
    /// Service providing <see cref="IRandomizer"/>.
    /// </summary>
    public interface IRandomService
    {
        IRandomizer GetRandomizer();
    }
}