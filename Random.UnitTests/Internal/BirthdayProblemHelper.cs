using System;

namespace Depra.Random.UnitTests.Internal
{
    internal static class BirthdayProblemHelper
    {
        /// <summary>
        /// The expected total number of times a selection will repeat a previous selection as n such values.
        /// </summary>
        /// <param name="n">Number of possible values.</param>
        /// <param name="k">Number of samples.</param>
        /// <returns></returns>
        public static double FindCollisionsCount(double n, double k) => k - n + n * Math.Pow((n - 1) / n, k);

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
        /// <param name="p">Collision probability.</param>
        /// <returns></returns>
        public static double GetApproximateNumberOfValuesForProbability(double n, double p) =>
            Math.Ceiling(Math.Sqrt(2 * n * Math.Log(1 / (1 - p))));

        public static double Test(double n, double k)
        {
            double pr = 0.7;
            int result = 0;

            double p = 1;
            while (p > pr)
            {
                p *= (n / k);
                n--;
                result++;
            }

            //Console.Write("\nTotal no. of people out of which there is ");
            //Console.Write("{0:F1} probability that two of them have same birthdays is {1} ", p, result);

            return result;
        }

        public static double QM(double m)
        {
            double sum = 0;
            for (var k = 1; k <= m; k++)
            {
                sum += Factorial(m) / Factorial(m - k) * (1 / Math.Pow(m, k));
            }

            return sum;
        }

        public static double Factorial(double n)
        {
            if (n == 1) 
            { 
                return 1; 
            }

            return n * Factorial(n - 1);
        }
    }
}