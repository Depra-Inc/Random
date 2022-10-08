using System;

namespace Depra.Random.Extensions
{
    public static class NumericExtensions
    {
        /// <summary>
        /// Determines if a <see cref="Type"/> is numeric.
        /// </summary>
        /// <param name="type">Object type.</param>
        /// <returns>Type is numeric.</returns>
        public static bool IsNumericType(this Type type)
        {   
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }
    }
}