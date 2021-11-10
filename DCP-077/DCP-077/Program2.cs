using System;
using System.Collections.Generic;
using System.Text;

namespace DCP_077
{
    public partial class Program
    {

        /// <summary>
        /// PrintShit
        /// </summary>
        /// <param name="num"></param>
        /// <param name="context"></param>
        static void Print(int num, string context = "")
        {
            Console.WriteLine(context + num);
        }

        /// <summary>
        /// Print More Shit.
        /// </summary>
        /// <param name="interval"></param>
        static void PrintInterval(int[] interval)
        {
            Console.WriteLine(interval[0] + ", " + interval[1]);
        }

        /// <summary>
        /// Prints a formatted string for titles.
        /// </summary>
        /// <param name="title">Title to Print</param>
        static void PrintTitle(string title)
        {
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
        static void PrintIntervalCollection(int[,] input)
        {
            for (int intervalSlot = 0; intervalSlot < input.Length / 2; intervalSlot++)
            {
                Console.Write("{ " + input[intervalSlot, 0] + ", " + input[intervalSlot, 1] + " }");
                if (intervalSlot != (input.Length / 2) - 1)
                {
                    Console.Write(",");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }


        /// <summary>
        /// (OBSELETE) Input an N x 2 array with number intervals and returns it with no overlaps.
        /// </summary>
        /// <param name="input">A 2D array with a collection of number intervals.</param>
        /// <returns>A modified input array with no overlapping intervals.</returns>
        static int[,] OBSELETEReturnMergedIntervals(int[,] input)
        {
            //First, create a tmp variable of non-overlapping intervals.
            int[,] tmp = new int[input.Length / 2, 2];
            //Then, we create another blank variable which will act as the output.
            int[,] output;
            //First, we have to create an overlap finder.
            for (int intervalSlot = 0; intervalSlot < (input.Length / 2) - 1; intervalSlot++)
            {
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
                else
                {
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
            for (int intervalSlot = 0; intervalSlot < output.Length / 2; intervalSlot++)
            {
                output[intervalSlot, 0] = tmp[intervalSlot, 0];
                output[intervalSlot, 1] = tmp[intervalSlot, 1];
            }
            //Now we can return the output variable!
            return output;
        }

    }
}
