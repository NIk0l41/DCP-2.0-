using System;
using System.Text.RegularExpressions;

namespace DCP_086
{
    class Program
    {
        static void Main(string[] args)
        {
            string paran = "()(())((()";
            char[] pInput = paran.ToCharArray();
            Console.WriteLine(NumberOfParanthesisToRemoveUntilValid(pInput));
        }

        static int NumberOfParanthesisToRemoveUntilValid(char[] input) {
            /// 1) Setup Variables
            int unPairedOpens = 0;
            int unPairedCloses = 0;
            int totalPairs = 0;

            for (int i = 0; i < input.Length; i++) {
                if (input[i] == '(') {
                    unPairedOpens++;
                    continue;
                }
                if (input[i] == ')') {
                    if (unPairedOpens == 0) {
                        unPairedCloses++;
                        continue;
                    }
                    else {
                        unPairedOpens--;
                        totalPairs++;
                        continue;
                    }
                }
            }
            return unPairedCloses + unPairedOpens;
        }

        //static string[] CullNullStringsInArray(string[] input) {
        //    bool cullOccurs = false;
        //    int cullSlot = -1;
        //    string[] arrOut = new string[input.Length - 1];
        //    for (int i = 0; i < input.Length; i++) {
        //        if (input[i] == null || input[i] == string.Empty) {
        //            cullOccurs = true;
        //            cullSlot = i;
        //            break;
        //        }
        //    }
        //    if (cullOccurs) {
        //        for (int i = cullSlot; i < arrOut.Length - 1; i++) {
        //            input[i] = input[i + 1];
        //        }
        //        for (int i = 0; i < arrOut.Length; i++) {
        //            arrOut[i] = input[i];
        //        }
        //        return CullNullStringsInArray(arrOut);
        //    }
        //    else {
        //        return input;
        //    }
        //}
    }
}
