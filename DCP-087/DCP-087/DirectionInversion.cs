using System;

namespace DCP_087 {

    partial class Program {

        /// <summary>
        /// Inverts the Direction an Instruction detaisl --> made to help with the point creation process.
        /// </summary>
        /// <param name="input">Original Direction.</param>
        /// <returns>Inverted Direction.</returns>
        static string InvertDir(string input) {
            string output = input;
            if (input.Contains("N")) {
                output = output.Replace("N", "S");
            }
            else {
                if (input.Contains("S")) {
                    output = output.Replace("S", "N");
                }
            }

            if (input.Contains("E")) {
                output = output.Replace("E", "W");
            }
            else {
                if (input.Contains("W")) {
                    output = output.Replace("W", "E");
                }
            }

            return output;
        }
    }
}