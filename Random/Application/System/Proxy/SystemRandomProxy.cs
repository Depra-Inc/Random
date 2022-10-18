// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System.Runtime.CompilerServices;

namespace Depra.Random.Application.System.Proxy
{
    internal abstract class SystemRandomProxy
    {
        private readonly global::System.Random _random;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        protected global::System.Random GetRandom() => _random;

        protected SystemRandomProxy(global::System.Random random) => _random = random;
    }
}