using System;
using System.Collections.Generic;

namespace DCP_075
{
    class Program
    {
        static void Main(string[] args)
        {
            //Longest Output is 6 --> 0, 2, 6, 9, 11, 15
            int[] input = { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 };
            int[] coll = new int[1];
            PSIABrancher brancher = new PSIABrancher();
            int length = brancher.DetermineLongestPSIA(input);
            Console.WriteLine("Length: " + length);
            Console.ReadLine();

            //for (int i = 0; i < input.Length; i++) {
                //int[] tmp = PointStart(0, input);
                //if (tmp.Length > coll.Length) {
                    //coll = tmp;
                //}
            //}
            //Console.WriteLine("Coll");
            //PrintArray(113, coll);
            //Console.WriteLine("Length: " + coll.Length);
        }
        


        static int[] PointStart(int pos, int[] input) {
            int[] coll = { input[pos] };
            for (int checkPoint = pos + 1; checkPoint < input.Length; checkPoint++) {
                coll = IterateColl(pos, input, coll);
            }
            
            return coll;
        }

        static int[] IterateColl(int startPoint, int[] input, int[] collection) {
            for (int i = startPoint; i < input.Length; i++) {
                  if (input[i] > collection[collection.Length - 1]) {
                    collection = collection.Append(input[i]);
                    collection = IterateColl(i, input, collection);
                  }
            }
            return collection;
        }

        /// <summary>
        /// Prints the Array Number and the Array Contents.
        /// </summary>
        /// <param name="pos">Input Array Number.</param>
        /// <param name="arr">Input Array Data.</param>
        static void PrintArray(int pos, int[] arr) {
            Console.Write(pos + ": ");
            for (int i = 0; i < arr.Length; i++) {
                if (i == arr.Length - 1) {
                    Console.Write(arr[i]);
                    continue;
                }
                Console.Write(arr[i] + ", ");
            }
            Console.WriteLine();
        }
    }

    //https://www.techieclues.com/blogs/how-to-add-elements-to-an-array-in-csharp
    public static class ExtensionClass
    {
        // Extension method to append the element
        public static T[] Append<T>(this T[] array, T item)
        {
            List<T> list = new List<T>(array);
            list.Add(item);

            return list.ToArray();
        }
    }
}
