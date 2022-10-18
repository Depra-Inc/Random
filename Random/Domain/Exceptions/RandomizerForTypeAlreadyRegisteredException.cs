// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;
using System.Reflection;

namespace Depra.Random.Domain.Exceptions
{
    internal sealed class RandomizerForTypeAlreadyRegisteredException : ArgumentException
    {
        private const string MESSAGE_FORMAT = "Randomizer for {0} already registered!";

        public RandomizerForTypeAlreadyRegisteredException(MemberInfo memberInfo) :
            base(string.Format(MESSAGE_FORMAT, memberInfo.Name)) { }
    }
}