// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Depra.Random.Application.System.Mapping;
using Depra.Random.Application.System.Proxy;
using Depra.Random.Application.System.Randoms;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System.Collections
{
    public sealed class CryptoRandomizers : IRandomizerCollection
    {
        private readonly SystemRandomizersMapper _randomizersMapper;
        
        public CryptoRandomizers()
        {
            var random = new CryptoRandom();
            _randomizersMapper = new SystemRandomizersMapper(
                new IntRandomProxy(random),
                new DoubleRandomProxy(random),
                new ByteArrayRandomProxy(random));
        }

        public IRandomizer GetRandomizer(Type valueType) => _randomizersMapper.GetRandomizer(valueType);

        public IEnumerable<IRandomizer> GetAllRandomizers() => _randomizersMapper.GetAllRandomizers();
    }
}