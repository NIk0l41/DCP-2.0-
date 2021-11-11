using System;

namespace DCP_079
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] example1 = { 10, 5, 7};
            int[] example2 = { 10, 5, 1};
            int[] array1 = { 10, 2, 3, 4, 5 };
            int[] array2 = { 10, 2, 3, 40, 5 };

            Console.WriteLine(NonDecreasingAbility(array2));
            Console.ReadLine();
        }

        /// <summary>
        /// Counts how many items in the array break the non-decreasing pattern. If that number is > 1, it returns false. Else, returns true.
        /// </summary>
        /// <param name="array">Input array to check.</param>
        /// <returns>Whether the non-decreasing pattern can be fulfilled by changing at most one item.</returns>
        static bool NonDecreasingAbility(int[] array) {
            /// 1) Loop through each item and count how many break non-decreasing standard
            int countPatternBreakers = 0;
            for (int arrayItem = 1; arrayItem < array.Length; arrayItem++){
                if (array[arrayItem] < array[arrayItem - 1]) {
                    countPatternBreakers++;
                }
            }
            /// 2) If the count is > 1, return false.
            ///     Else, return true.
            bool modifyOneToChange = (countPatternBreakers > 1) ? false : true;
            return modifyOneToChange;
        }
    }
}
