// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER
#define CSHARP8_OR_GREATER
using System.Diagnostics.CodeAnalysis;
#endif

using System;
using System.Reflection;

namespace Depra.Random.Domain.Exceptions
{
    internal static partial class Throw
    {
#if CSHARP8_OR_GREATER
        [DoesNotReturn]
#endif
        public static void ArgumentMustBeGreaterOrEqual(string paramName, object actualValue, object comparedValue) =>
            throw new ArgumentOutOfRangeException(paramName, actualValue,
                string.Format(MUST_BE_GREATER_THAN_OR_EQUAL_TO, paramName, comparedValue));

#if CSHARP8_OR_GREATER
        [DoesNotReturn]
#endif
        public static void ArgumentMustBeSmallerOrEqual(string paramName, object actualValue, object comparedValue) =>
            throw new ArgumentOutOfRangeException(paramName, actualValue,
                string.Format(MUST_BE_SMALLER_THAN_OR_EQUAL_TO, paramName, comparedValue));

#if CSHARP8_OR_GREATER
        [DoesNotReturn]
#endif
        public static void RandomizerForTypeAlreadyRegistered(MemberInfo memberInfo) =>
            throw new RandomizerForTypeAlreadyRegisteredException(memberInfo);

#if CSHARP8_OR_GREATER
        [DoesNotReturn]
#endif
        public static void RandomizerForTypeNotRegistered(MemberInfo memberInfo) =>
            throw new RandomizerForTypeNotRegisteredException(memberInfo);

#if CSHARP8_OR_GREATER
        [DoesNotReturn]
#endif
        public static void RandomizerIsNull(MemberInfo valueType) =>
            throw new NullReferenceException(string.Format(RANDOMIZER_IS_NULL, valueType));
    }
}