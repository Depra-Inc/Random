using System;
using System.Reflection;

namespace Depra.Random.Internal.Exceptions
{
    internal class NoRegistrationException : Exception
    {
        private const string MESSAGE_FORMAT = "Randomizer for type {0} is not registered!";

        public NoRegistrationException(MemberInfo memberInfo) : base(string.Format(MESSAGE_FORMAT, memberInfo.Name)) { }
    }
}