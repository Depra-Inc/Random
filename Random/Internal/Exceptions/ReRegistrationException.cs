using System;
using System.Reflection;

namespace Depra.Random.Internal.Exceptions
{
    internal class ReRegistrationException : Exception
    {
        private const string MESSAGE_FORMAT = "Randomizer for {0} already registered!";

        public ReRegistrationException(MemberInfo memberInfo) : base(string.Format(MESSAGE_FORMAT, memberInfo.Name)) { }
    }
}