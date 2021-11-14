using System;
using System.Text.RegularExpressions;

namespace DCP_081
{
    class Program
    {
        static void Main(string[] args)
        {
            DigitMap map2 = new DigitMap("2", new string[] { "a", "b", "c"});
            DigitMap map3 = new DigitMap("3", new string[] { "d", "e", "f" });
            DigitMap map4 = new DigitMap("4", new string[] { "g", "h", "i" });
            DigitMap[] mapping = new DigitMap[] { map2, map3};

            string[] input = Regex.Split("23", string.Empty);
            input = CullNullStringsInArray(input);
            PrintStringArray(input);
            string[] tests = ReturnPossibleLetterCombinations(input, mapping);
            PrintStringArray(tests);
            //PrintStringArray(ReturnPossibleLetterCombinations(input, mapping ));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="mapping"></param>
        /// <returns></returns>
        static string[] ReturnPossibleLetterCombinations(string[] input, DigitMap[] mapping) {
            int len = input.Length;
            int maps = mapping.Length;
            ///
            /// Let's assume that the correct map is given for each input string.
            /// It'll save us a headache.
            /// 
            int outLen = 1;
            for (int i = 0; i < mapping.Length; i++) {
                outLen *= mapping[i].letters.Length;
            }
            string[] output = new string[outLen];
            //Create slotWeights.
            int[] slotWeights = new int[mapping.Length];
            for (int i = 0; i < mapping.Length; i++) {
                slotWeights[i] = mapping[i].letters.Length;
            }
            for (int i = 0; i < outLen; i++) {
                Class1 fuckMe = new Class1();
                int[] scaledWeights = fuckMe.ScaleWeights(slotWeights);
                int[] nary = fuckMe.NaryFromInt2(i, scaledWeights);
                //Now that it has nary, it will apply the mapping to each item.
                //Assum nary = (1, 1) --> "b", "d"
                //PrintNnary(nary);
                output[i] = ReturnCombinationString(nary, mapping);
            }
            /// 4) Return output
            return output;
        }



        static int[] NnaryFromInt(int val, int[] slotWeights) {
            Console.WriteLine("Nnary " + val);
            int[] putout = new int[slotWeights.Length];
            //for (int i = 0; i < slotWeights.Length; i++) {
            //    int[] a = Mod(val, slotWeights[i]);
            //    val = a[1];
            //    putout[i] = a[0];
            //}
            for (int i = slotWeights.Length - 2; i > -1; i--){
                int[] a = Mod(val, slotWeights[i]);
                //while (a[0] >= a[1]) {
                //    a[0] -= a[1];
                //    putout[i - 1]++;
                //}
                val = a[1];
                putout[i] = a[0];
            }
            putout[slotWeights.Length - 1] = val;
            return putout;
        }

        static int[] Mod(int val, int weight) {
            int numTimes = 0;
            while (val >= weight) {
                val -= weight;
                numTimes++;
            }
            //if (numTimes >= weight) {
            //    int[] modIterate = Mod(numTimes, weight);
            //    numTimes = modIterate[0];
            //    val = modIterate[1];
            //}
            return new int[] { numTimes, val };
        }

        static string ReturnCombinationString(int[] slots, DigitMap[] maps) {
            string output = "";
            for (int i = 0; i < slots.Length; i++) {
                output += maps[i].letters[slots[i]];
            }
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        static void PrintStringArray(string[] array) {
            int len = array.Length;
            for (int i = 0; i < len; i++) {
                Console.Write(array[i]);
                if (i != len - 1)
                    Console.Write(", ");
            }
            Console.ReadLine();
        }

        static void PrintNnary(int[] nnary) {
            if (nnary != null){
                int len = nnary.Length;
                for (int i = 0; i < len; i++){
                    Console.Write(nnary[i]);
                    if (i != len - 1)
                        Console.Write(", ");
                }
                Console.ReadLine();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        static string[] CullNullStringsInArray(string[] array) {
            bool cullOccurs = false;
            int cullSlot = -1;
            string[] arrOut = new string[array.Length - 1];
            for (int i = 0; i < array.Length; i++) {
                if (array[i] == null || array[i] == String.Empty) {
                    cullOccurs = true;
                    cullSlot = i;
                    break;
                }

            }
            if (cullOccurs) {
                for (int i = cullSlot; i < array.Length - 1; i++) {
                    array[i] = array[i + 1];
                }
                for (int i = 0; i < arrOut.Length; i++) {
                    arrOut[i] = array[i];
                }
                return CullNullStringsInArray(arrOut);
            }
            else {
                return array;
            }
        }
    }
}
