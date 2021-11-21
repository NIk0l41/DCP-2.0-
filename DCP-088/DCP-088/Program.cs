using System;

namespace DCP_088
{
    class Program
    {
        static void Main(string[] args)
        {
            int quotient = QuotientOf(1, 4);
            Console.WriteLine(quotient);
        }

        /// <summary>
        /// Determines whether the quotient would be < 1 or >= 1, then appropriately 'divides' the dividend by the divisor.
        /// </summary>
        /// <param name="dividend"></param>
        /// <param name="divisor"></param>
        /// <returns>An Integer Quotient.</returns>
        static int QuotientOf(int dividend, int divisor) {
            int output = 0;
            //If the quotient would be < 1
            if (dividend < divisor) {
                //Round up or round down?
                output = (dividend < (divisor / 2)) ? 0 : 1;
            }
            //If the quotient would be >= 1
            while (dividend >= divisor) {
                output++;
                dividend -= divisor;
            }
            return output;
        }
    }
}
