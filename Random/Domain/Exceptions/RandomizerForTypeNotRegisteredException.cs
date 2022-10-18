using System;
using System.Reflection;

namespace Depra.Random.Domain.Exceptions
{
    internal sealed class RandomizerForTypeNotRegisteredException : ArgumentException
    {
        private const string MESSAGE_FORMAT = "Randomizer for type {0} is not registered!";

        public RandomizerForTypeNotRegisteredException(MemberInfo memberInfo) : 
            base(string.Format(MESSAGE_FORMAT, memberInfo.Name)) { }
    }
}