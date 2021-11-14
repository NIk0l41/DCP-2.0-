using System;
using System.Text.RegularExpressions;

namespace DCP_081
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            DigitMap map1 = new DigitMap("1", new string[] { " " });
            DigitMap map2 = new DigitMap("2", new string[] { "a", "b", "c"});
            DigitMap map3 = new DigitMap("3", new string[] { "d", "e", "f" });
            DigitMap map4 = new DigitMap("4", new string[] { "g", "h", "i" });
            DigitMap map5 = new DigitMap("5", new string[] { "j", "k", "l" });
            DigitMap map6 = new DigitMap("6", new string[] { "m", "n", "o" });
            DigitMap map7 = new DigitMap("7", new string[] { "p", "q", "r", "s" });
            DigitMap map8 = new DigitMap("8", new string[] { "t", "u", "v" });
            DigitMap map9 = new DigitMap("9", new string[] { "w", "x", "y", "z" });
            DigitMap[] mapLibrary = new DigitMap[] { map1, map2, map3, map4, map5, map6, map7, map8, map9};

            Console.WriteLine("Enter a sequence of integers.");
            Console.Write(">");
            string reader = Console.ReadLine();

            string[] input = Regex.Split(reader, string.Empty);
            input = CullNullStringsInArray(input);
            PrintStringArray(input);
            DigitMap[] mapping = MapToInput(mapLibrary, input);
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
            int[] scaledWeights = ScaleWeights(slotWeights);
            for (int i = 0; i < outLen; i++) {
                int[] nary = NaryFromInt2(i, scaledWeights, slotWeights);
                //Now that it has nary, it will apply the mapping to each item.
                //Assum nary = (1, 1) --> "b", "d"
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

        static string ReturnCombinationString(int[] nary, DigitMap[] maps) {
            string output = "";
            for (int i = 0; i < nary.Length; i++) {
                output += maps[i].letters[nary[i]];
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
