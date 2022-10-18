// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using Depra.Random.Application.Services;
using Depra.Random.Domain.Randomizers;

namespace Depra.Random.Application.ServiceBuilder
{
    public interface IRandomServiceBuilder
    {
        IRandomService Build();

        IRandomServiceBuilder With(Type valueType, IRandomizer randomizer);
    }
}