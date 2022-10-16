// Copyright © 2022 Nikolay Melnikov. All rights reserved.
// SPDX-License-Identifier: Apache-2.0

using System;

namespace Depra.Random.Internal.Exceptions
{
    public static class Throw
    {
        private const string MUST_BE_GREATER_THAN_OR_EQUAL_TO = "'{0}' must be greater than or equal to {1}.";
        private const string MUST_BE_SMALLER_THAN_OR_EQUAL_TO = "{0} must be smaller than or equal to {1}!";
        
        public static void ArgumentMustBeGreaterOrEqual(string paramName, object actualValue, object comparedValue) =>
            throw new ArgumentOutOfRangeException(paramName, actualValue,
                string.Format(MUST_BE_GREATER_THAN_OR_EQUAL_TO, paramName, comparedValue));

        public static void ArgumentMustBeSmallerOrEqual(string paramName, object actualValue, object comparedValue) =>
            throw new ArgumentOutOfRangeException(paramName, actualValue,
                string.Format(MUST_BE_SMALLER_THAN_OR_EQUAL_TO, paramName, comparedValue));
    }
}