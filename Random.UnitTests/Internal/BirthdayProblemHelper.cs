using System;

namespace Depra.Random.UnitTests.Internal
{
    internal static class BirthdayProblemHelper
    {
        /// <summary>
        /// Returns collision probability in <see cref="k"/> samples,
        /// each of which is a random selection of <see cref="n"/> possible values.
        /// </summary>
        /// <param name="n">Number of possible values.</param>
        /// <param name="k">Number of samples.</param>
        /// <returns></returns>
        public static double GetCollisionProbability(double n, double k) =>
            1 - Math.Exp(-k * (k - 1) / (2 * n));

        /// <summary>
        /// Returns the approximate number of values for a given probability.
        /// </summary>
        /// <param name="n">Number of possible values.</param>
        /// <param name="p">Collision probability</param>
        /// <returns></returns>
        public static double GetApproximateNumberOfValuesForProbability(double n, double p) =>
            Math.Ceiling(Math.Sqrt(2 * n * Math.Log(1 / (1 - p))));
    }
}