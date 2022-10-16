// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Random.Randomizers;

namespace Depra.Random.Services
{
    /// <inheritdoc />
    public sealed class RandomService : IRandomService
    {
        private readonly IRandomizer _randomizer;

        public IRandomizer GetRandomizer() => _randomizer;

        public RandomService(IRandomizer randomizer) =>
            _randomizer = randomizer ?? throw new NullReferenceException("Randomizer is null!");
    }
}