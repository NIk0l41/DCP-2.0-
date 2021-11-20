using System;
using System.Text.RegularExpressions;

namespace DCP_087
{
    partial class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = {"A N B", "B NE C", "C N A" };
            string[] in2 = { "C W D", "D S B", "F NW B", "A N C", "E S C", "E N F" };
            Console.WriteLine(ValidInstructions(in2));
        }

        /// <summary>
        /// Returns the number of uniquely labelled points in a given list of instructions
        /// Considers both alpha and bravo points.
        /// </summary>
        /// <param name="regInstr">List of Formatted Instructions.</param>
        /// <returns>The number of unique points listed within the given instructions.</returns>
        static int NumPoints(Match[] regInstr) {
            string points = "";
            for (int i = 0; i < regInstr.Length; i++) {
                if (!points.Contains(regInstr[i].Groups[1].Value)) {
                    points += regInstr[i].Groups[1].Value;
                }
                if (!points.Contains(regInstr[i].Groups[3].Value)) {
                    points += regInstr[i].Groups[3].Value;
                }
            }
            return points.Length;
        }

        static Match[] GetMatches(string[] instructions, Regex regex) {
            Match[] matches = new Match[instructions.Length];
            for (int instructionNo = 0; instructionNo < instructions.Length; instructionNo++) {
                matches[instructionNo] = GetMatch(instructions[instructionNo], regex);
            }
            return matches;
        }

        /// <summary>
        /// Input string and REGEX, if successful: returns the match,
        /// otherwise returns null;
        /// </summary>
        /// <param name="input">A single string to search.</param>
        /// <param name="regex">The Regular Expression to start the search.</param>
        /// <returns></returns>
        static Match GetMatch(string input, Regex regex) {
            Match match = regex.Match(input);
            if (match.Success) {
                return match;
            }
            return null;
        }

    }
}
