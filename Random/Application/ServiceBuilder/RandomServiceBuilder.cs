// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Depra.Random.Application.Services;
using Depra.Random.Domain.Exceptions;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.ServiceBuilder
{
    public sealed class RandomServiceBuilder : IRandomServiceBuilder
    {
        private readonly IDictionary<Type, IRandomizer> _randomizers;

        public IRandomService Build() => new RandomService(_randomizers);

        public IRandomServiceBuilder With(Type valueType, IRandomizer randomizer)
        {
            if (_randomizers.ContainsKey(valueType))
            {
                Throw.RandomizerForTypeAlreadyRegistered(valueType);
            }
            
            _randomizers.Add(valueType, randomizer);
            
            return this;
        }

        public RandomServiceBuilder()
        {
            _randomizers = new Dictionary<Type, IRandomizer>();
        }
    }
}