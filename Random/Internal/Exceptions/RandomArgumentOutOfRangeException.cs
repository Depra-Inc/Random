using System;

namespace Depra.Random.Internal.Exceptions
{
    internal class RandomArgumentOutOfRangeException : ArgumentOutOfRangeException
    {
        private const string MUST_BE_GREATER_THAN_MESSAGE_FORMAT = 
            "'{0}' must be greater than {1}.";

        private const string MUST_BE_GREATER_THAN_OR_EQUAL_MESSAGE_FORMAT =
            "'{0}' must be greater than or equal to {1}.";

        private const string MUST_BE_SMALLER_OR_EQUAL_MESSAGE_FORMAT = 
            "'{0}' must be smaller than or equal to {1}.";

        public RandomArgumentOutOfRangeException(object maxValue, object expectedMaxValue, bool orEqual = false) :
            base(nameof(maxValue), maxValue,
                string.Format(orEqual ? MUST_BE_GREATER_THAN_OR_EQUAL_MESSAGE_FORMAT : MUST_BE_GREATER_THAN_MESSAGE_FORMAT,
                    nameof(maxValue), expectedMaxValue)) { }

        public RandomArgumentOutOfRangeException(object minValue, string maxValueDescription) :
            base(nameof(minValue), minValue,
                string.Format(MUST_BE_SMALLER_OR_EQUAL_MESSAGE_FORMAT, nameof(minValue), maxValueDescription)) { }
    }
}