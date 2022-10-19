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
    public sealed class ConcurrentPseudoRandomizers : IRandomizerCollection
    {
        private static readonly SystemRandomizersMapper RANDOMIZERS_MAPPER;

        public IRandomizer GetRandomizer(Type valueType) => RANDOMIZERS_MAPPER.GetRandomizer(valueType);

        public IEnumerable<IRandomizer> GetAllRandomizers() => RANDOMIZERS_MAPPER.GetAllRandomizers();

        static ConcurrentPseudoRandomizers()
        {
            var randomImpl =
#if NET6_0_OR_GREATER
                new global::System.Random();
#else
                new ConcurrentPseudoRandom();
#endif

            RANDOMIZERS_MAPPER = new SystemRandomizersMapper(
                new IntRandomProxy(randomImpl),
                new DoubleRandomProxy(randomImpl),
                new ByteArrayRandomProxy(randomImpl));
        }
    }
}