using System;

namespace DCP_077
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            //The input list is not necessarily ordered in any way.
            /*
             * Right, ok, so I just need to remove some overlapping numbers.
             * Since they don't have to be in order, how exactly
             * do I determine what's overlapping?
             * If don't think the task is for me to order them, or it would
             * say so.
             * What does merge mean in this context?
             * AHH!
             * So, let's say we have (3, 8) and (4,10)
             * To merge these items, our output would be (3, 10),
             * since they overlap, we take the max and the min.
             * 
             * Given this explanation, we should order these items to
             * find the overlaps.
             * 
             * Or... Do we simply look for overlaps with adjacent items?
             * 
             */
            int[,] intervalA = { { 1, 3 }, { 5, 8 }, { 4, 10 }, { 20, 25 } };
            int[,] intervalB = { { 20, 25 }, { 5, 8 }, { 1, 3 }, { 4, 10 } };
            int[,] intervalC = { { 1, 5 }, {4, 10 } };
            //Print Original Contents
            PrintTitle("Interval Collection C");
            PrintIntervalCollection(intervalC);
            //Print Sorted Contents
            PrintTitle("Sorted Interval Collection C");
            PrintIntervalCollection(ReturnSortedIntervalCollection(intervalC));
            //Print Merged Contents.
            PrintTitle("Merged Interval Collection C");
            PrintIntervalCollection(ReturnMergedIntervalCollection(intervalC));
        }

        /// <summary>
        /// Sorts a collection of intervals by their first index.
        /// </summary>
        /// <param name="input">A Collection of Number Intervals.</param>
        /// <returns>A sorted collection of number Intervals.</returns>
        static int[,] ReturnSortedIntervalCollection(int[,] input) {
            /// 1) One Sort.
            for (int intervalCollection = 0; intervalCollection < (input.Length / 2) - 1; intervalCollection++) {
                if (input[intervalCollection, 0] > input[intervalCollection + 1, 0]) {
                    //T = A
                    int[] tmp = { input[intervalCollection, 0], input[intervalCollection, 1]};
                    //A = B
                    input[intervalCollection, 0] = input[intervalCollection + 1, 0];
                    input[intervalCollection, 1] = input[intervalCollection + 1, 1];
                    //B = T
                    input[intervalCollection + 1, 0] = tmp[0];
                    input[intervalCollection + 1, 1] = tmp[1];
                }
            }

            /// 2) Check for completion.
            //If one sort, didn't work, we iterate again.
            //First, we add a counter.
            int counter = 0;
            for (int intervalCollection = 0; intervalCollection < (input.Length / 2) - 1; intervalCollection++) {
                if (input[intervalCollection, 0] > input[intervalCollection + 1, 0]) {
                    counter++;
                }
            }

            /// 3) Iterate if incomplete.
            //If this counter is > 0, then the sort is incomplete, and we need to iterate.
            //Eventually, this should sort the entire array.
            //Through brute force. It's not efficient,
            //but it'll get there eventually with larger datasets.
            if (counter > 0) {
                input = ReturnSortedIntervalCollection(input);
            }

            /// 4)Return the sorted array!
            return input;
        }

        /// <summary>
        /// Scans for an overlap, merges a single overlap, then creates a new collection with one less item.
        /// It iterates with itself to check for other overlaps then returns the result.
        /// </summary>
        /// <param name="input">A Sorted Number Interval Collection. Use "SortedIntervalCollection" first if you haven't already.</param>
        /// <returns>A new Number Interval Collection with no numerial overlaps.</returns>
        static int[,] ReturnMergedIntervalCollection(int[,] input) {
            /// 1) Scan for a single overlap, FUNCTION then break
            //We create a bool.
            //Later, if it's true, then a merge has taken place.
            bool hasMergeOccurred = false;
            for (int intervalSlot = 0; intervalSlot < (input.Length / 2) - 1; intervalSlot++) {
                //A(1) > B(0)
                if (input[intervalSlot, 1] > input[intervalSlot + 1, 0]){
                    /// 2) Merge overlap. Place Merge in A. Erase B.
                    int[] tmp = MergeOverlappingIntervals(
                        new int[] { input[intervalSlot, 0], input[intervalSlot, 1] },
                        new int[] { input[intervalSlot + 1, 0], input[intervalSlot + 1, 1] }
                        );
                    //Place tmp in A's position.
                    input[intervalSlot, 0] = tmp[0];
                    input[intervalSlot, 1] = tmp[1];
                    //Erase B by multiplying B(0) by -1.
                    //No collection of number intervals is in the negative!
                    //This will be a pointer that it has no place in the future array, and to be ignored.
                    input[intervalSlot + 1, 0] *= -1;
                    //We also need to let the algorithm know that a merge has taken place.
                    //(Forgot to add this on my first run through of this finished script :P)
                    hasMergeOccurred = true;
                    break;
                }
            }
            //PrintSubTitle("After Merge");
            //PrintIntervalCollection(input);
            /// 3) Create a new Interval Collection with the remnants of input.
            //We run this script if a merge has occurred.
            if (hasMergeOccurred) {
                //First, we create our new 'Merged Interval Collection', or MIC
                //It needs to be one shorter than before, to account for the merge.
                int[,] MIC = new int[(input.Length / 2) - 1, 2];
                //Print(MIC.Length, "MIC LENGTH");
                //Keeps track of where data is inserted into the MIC.
                //Stands for 'Merged Interval Collection Interval Slot'
                int MICIS = 0;
                for (int intervalSlot = 0; intervalSlot < (input.Length / 2); intervalSlot++) {
                    //If we find an item that needs to be erased,
                    //We simply skip over it.
                    if (input[intervalSlot, 0] < 0) {
                        continue;
                    }
                    //If that item needs to be added, we add it.
                    //Using MICIS and intervalSlot, we can place the data in the correct location.
                    MIC[MICIS, 0] = input[intervalSlot, 0];
                    MIC[MICIS, 1] = input[intervalSlot, 1];
                    //We then add 1 to MICIS to indicate the next slot that needs to be filled.
                    //This compensates for the shifting that occurs in the dataset.
                    //FORGOT TO FUCKING ADD 1.
                    //GOD DAMN IT.
                    MICIS++;
                    //WROTE THE COMMENT NOT THE CODE.
                    //NOTE: IF THIS IS NOT THERE, MANY ZEROES.
                }

                /// 4) Iterate with self.
                // This iteration allows us to offload if there are more overlaps and merges to take place,
                // since this function only does a single merge.
                //PrintSubTitle("MIC");
                //PrintIntervalCollection(MIC);
                MIC = ReturnMergedIntervalCollection(MIC);

                /// 5) Return Merged Interval Collection.
                // After all that, we can now return our final product!
                return MIC;
            }

            //If no merge occurred, then we return the input!
            return input;
        }

        /// <summary>
        /// Merges two overlapping intervals, or returns inputB.
        /// </summary>
        /// <param name="inputA"></param>
        /// <param name="inputB"></param>
        /// <returns>A merged interval where the first item is the lowest of the two, and the second item is the highest of the two.</returns>
        static int[] MergeOverlappingIntervals(int[] inputA, int[] inputB) {
            int[] output;
            output = new int[] { Math.Min(inputA[0], inputB[0]), Math.Max(inputA[1], inputB[1])};
            return output;
        }
    }
}
