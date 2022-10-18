// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.Services
{
    /// <inheritdoc />
    public sealed class RandomService : IRandomService
    {
        private readonly IDictionary<Type, IRandomizer> _randomizers;

        public IRandomizer GetRandomizer(Type valueType)
        {
            if (_randomizers.TryGetValue(valueType, out var randomizer) == false)
            {
                Throw.RandomizerForTypeNotRegistered(valueType);
            }

            return randomizer;
        }

        public void RegisterRandomizer(Type valueType, IRandomizer randomizer)
        {
            if (randomizer == null)
            {
                Throw.RandomizerIsNull(valueType);
            }

            if (_randomizers.ContainsKey(valueType))
            {
                Throw.RandomizerForTypeAlreadyRegistered(valueType);
            }

            _randomizers.Add(valueType, randomizer);
        }

        public RandomService(IDictionary<Type, IRandomizer> randomizers = null) =>
            _randomizers = randomizers ?? new Dictionary<Type, IRandomizer>();
    }
}