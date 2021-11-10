using System;

namespace DCP_077
{
    class Program
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
            Print(0);
            //We need to print out the contents of integer arrays.
            PrintTitle("Interval Collection C");
            PrintIntervalCollection(intervalC);
            PrintTitle("Merged Interval Collection C");
            PrintIntervalCollection(ReturnMergedIntervals(intervalC));
        }



        /*
        int[,] OrderIntervalArray(int[,] inputArray) {
            int[,] intervalOrdered = new int[inputArray.Length / 2, 2];
            intervalOrdered[0, 0] = inputArray[0, 0];
            intervalOrdered[0, 1] = inputArray[0, 1];
            for (int intervalSlot = 1; intervalSlot < inputArray.Length / 2; intervalSlot++) {
                if (inputArray[intervalSlot - 1, 0] > inputArray[intervalSlot, 0]) {
                    intervalOrdered
                }
            }
        }*/

        /// <summary>
        /// PrintShit
        /// </summary>
        /// <param name="num"></param>
        /// <param name="context"></param>
        static void Print(int num, string context = "") {
            Console.WriteLine(context + num);
        }

        /// <summary>
        /// Print More Shit.
        /// </summary>
        /// <param name="interval"></param>
        static void PrintInterval(int[] interval) {
            Console.WriteLine(interval[0] + ", " + interval[1]);
        }

        /// <summary>
        /// Prints a formatted string for titles.
        /// </summary>
        /// <param name="title">Title to Print</param>
        static void PrintTitle(string title) {
            Console.WriteLine("---" + title + "---");
        }

        /// <summary>
        /// Prints a formatted string for subtitles.
        /// </summary>
        /// <param name="subtitle">Subtitle to Print</param>
        static void PrintSubTitle(string subtitle)
        {
            Console.WriteLine("-" + subtitle + "-");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        static void PrintIntervalCollection(int[,] input) {
            for (int intervalSlot = 0; intervalSlot < input.Length / 2; intervalSlot++) {
                Console.Write("{ " + input[intervalSlot, 0] + ", " + input[intervalSlot, 1] + " }");
                if (intervalSlot != (input.Length / 2) - 1) {
                    Console.Write(",");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// Input an N x 2 array with number intervals and returns it with no overlaps.
        /// </summary>
        /// <param name="input">A 2D array with a collection of number intervals.</param>
        /// <returns>A modified input array with no overlapping intervals.</returns>
        static int[,] ReturnMergedIntervals(int[,] input) {
            //First, create a tmp variable of non-overlapping intervals.
            int[,] tmp = new int[input.Length / 2, 2];
            //Then, we create another blank variable which will act as the output.
            int[,] output;
            //First, we have to create an overlap finder.
            for (int intervalSlot = 0; intervalSlot < (input.Length / 2) - 1; intervalSlot++) {
                //If A(1) > B(0)
                if (input[intervalSlot, 1] < input[intervalSlot + 1, 0])
                {
                    //We have found an overlap.
                    //So, we need to merge it.
                    int[] mergedInterval = MergeOverlappingIntervals(
                        new int[] {
                            input[intervalSlot, 0],
                            input[intervalSlot, 1]
                            },
                        new int[]{
                            input[intervalSlot + 1, 0],
                            input[intervalSlot + 1, 1]
                        } 
                    );
                    //Now that we've merged that interval, we
                    //Need to declare that B = mergedInterval.
                    //That way, the process isn't interrupted.
                    PrintInterval(mergedInterval);
                    input[intervalSlot + 1, 0] = mergedInterval[0];
                    input[intervalSlot + 1, 1] = mergedInterval[1];
                    
                }
                else {
                    //If there is no overlap, A is added to the tmp array.
                    tmp[intervalSlot, 0] = input[intervalSlot, 0];
                    tmp[intervalSlot, 1] = input[intervalSlot, 1];
                    PrintSubTitle("tmp");
                    Print(tmp[intervalSlot, 0], "tmp[" + intervalSlot + ", 0] = ");
                    Print(tmp[intervalSlot, 1], "tmp[" + intervalSlot + ", 1] = ");
                }
            }
            //PrintTitle("tmp");
            //PrintIntervalCollection(tmp);
            //Once all the merging has been done, we need to create a clean output array.
            output = new int[tmp.Length / 2, 2];
            //Then, we append the appropriate items into their respective slots.
            for (int intervalSlot = 0; intervalSlot < output.Length / 2; intervalSlot++) {
                output[intervalSlot, 0] = tmp[intervalSlot, 0];
                output[intervalSlot, 1] = tmp[intervalSlot, 1];
            }
            //Now we can return the output variable!
            return output;
        }

        static int[,] ReturnMerged2(int[,] input) {
            int[,] output = new int[input.Length / 2, 2];
            for (int intervalSlot = 0; intervalSlot < (input.Length / 2); intervalSlot++) {
                //A(1) > B(0)
                if (input[intervalSlot, 1] > input[intervalSlot + 1, 0]) {
                    int merged = MergeOverlappingIntervals();
                    output[intervalSlot, ]
                }
            }
            return output;
        }

        /// <summary>
        /// Merges two overlapping intervals, or returns inputB.
        /// </summary>
        /// <param name="inputA"></param>
        /// <param name="inputB"></param>
        /// <returns>A merged interval where the first item is the lowest of the two, and the second item is the highest of the two.</returns>
        static int[] MergeOverlappingIntervals(int[] inputA, int[] inputB) {
            int[] output;
            if (inputA[1] > inputB[0]) {
                output = new int[] { Math.Min(inputA[0], inputB[0]), Math.Max(inputA[1], inputB[1]) };
            }
            else {
                output = inputB;
            }
            return output;
        }
    }
}
