using System;
using Depra.Random.UnitTests.Internal;
using NUnit.Framework;

namespace Depra.Random.UnitTests
{
    [TestFixture]
    public class BirthdayProblemHelperTests
    {
        [TestCase(uint.MaxValue, 100000)]
        [TestCase(uint.MaxValue, uint.MaxValue)]
        public void CalculateDuplicates(double numberOfValues, double numberOfSamples)
        {
            var percentage = BirthdayProblemHelper.GetCollisionProbability(numberOfValues, numberOfSamples);
            Console.WriteLine(percentage);
        }
    }
}