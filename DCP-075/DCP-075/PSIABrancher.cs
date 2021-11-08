using System;
using System.Collections.Generic;
using System.Text;

namespace DCP_075
{
    class PSIABrancher
    {
        /// <summary>
        /// Returns the length of the longest possible subsequent increasing array.
        /// </summary>
        /// <param name="array">Input array.</param>
        /// <returns>An integer length.</returns>
        public int DetermineLongestPSIA(int[] array) {
            /* //Determine Starting Points
             * Each iteration of this loop chooses a new point to start at.
             * May be in our interest to keep this in mind.
             */
            int length = 0;
            int[] PSIA = { };
            for (int startingPoint = 0; startingPoint < array.Length; startingPoint++) {
                int tmp = IterateBranch(array, startingPoint, 0);
                length = (tmp > length) ? tmp : length;
            }

            return length;
        }

        public int IterateBranch(int[] array, int startPoint, int counter) {
            int[] possibleBranches = { };
            //Foreach item after startpoint, check if it's valid for PSIA
            for (int possibleBranch = startPoint + 1; possibleBranch < array.Length; possibleBranch++) {
                if (array[possibleBranch] > array[startPoint]) {
                    //If the possibleBranch is valid, add the position to possibleBranches.
                    possibleBranches = possibleBranches.Append(possibleBranch);
                }
            }
            //If there are no possibleBranches that could make a PSIA,
            //We return how many steps were taken prior.
            //No progress is made.
            if (possibleBranches.Length == 0) {
                return counter;
            }
            else {
                //If there are possibleBranches that could make a PSIA, 
                //we need to IterateBranch, and see how the counts go.
                for (int branches = 0; branches < possibleBranches.Length; branches++) {
                    int branchCount = IterateBranch(array, possibleBranches[branches], counter + 1);
                    counter = (branchCount > counter) ? branchCount : counter;
                }

                return counter;

            }
        }


    }

}
