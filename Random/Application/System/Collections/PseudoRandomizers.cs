// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Collections.Generic;
using Depra.Random.Application.System.Mapping;
using Depra.Random.Application.System.Proxy;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.System.Collections
{
    /// <summary>
    /// Decorator for <see cref="Random"/>, to support the <see cref="IRandomizer"/> contract.
    /// </summary>
    public sealed class PseudoRandomizers : IRandomizerCollection
    {
        private readonly SystemRandomizersMapper _randomizersMapper;

        public PseudoRandomizers()
        {
            var random = new global::System.Random();
            _randomizersMapper = new SystemRandomizersMapper(
                new IntRandomProxy(random),
                new DoubleRandomProxy(random),
                new ByteArrayRandomProxy(random));
        }

        public IRandomizer GetRandomizer(Type valueType) => _randomizersMapper.GetRandomizer(valueType);

        public IEnumerable<IRandomizer> GetAllRandomizers() => _randomizersMapper.GetAllRandomizers();
    }
}