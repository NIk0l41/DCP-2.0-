using System;
using System.Text.RegularExpressions;

namespace DCP_087 {

    partial class Program {


        static bool ValidInstructions(string[] instructions) {
            bool output = true;
            Regex regex = new Regex(@"([A-Z]).([NESW]+).([A-Z])");
            Match[] instr = GetMatches(instructions, regex);
            Point[] points = new Point[NumPoints(instr)];
            // Assuming that instructions is not empty
            (Point a, Point b) = GetFirstPoints(instr[0]);
            // Add first points to collection.
            points[0] = a;
            points[1] = b;
            int pointCount = 2;
            // For every instruction other than the first one.
            for (int instrNo = 1; instrNo < instructions.Length; instrNo++) {
                (string aName, string bName) = (instr[instrNo].Groups[1].Value, instr[instrNo].Groups[3].Value);
                string dir = instr[instrNo].Groups[2].Value;
                /// 1) Determine if the instructions is 'Comparison' or 'Creation'
                ///     Comparison --> Occurs if alpha&&bravo are found in points.
                ///     Creation --> Occurs if alpha||bravo is not found in points.
                if (ContainsPoint(points, aName) && ContainsPoint(points, bName)) {
                    /// 2) Comparison - Determine valid relationship between alpha and bravo.
                    Point alpha = new Point();
                    alpha.coord = ReturnPointCoords(points, aName);
                    Point bravo = new Point();
                    bravo.coord = ReturnPointCoords(points, bName);
                    // If the relationship between alpha and bravo is illegal,
                    // the output is changed.
                    if (!DetermineValidInstruction(alpha, bravo, dir)) {
                        output = false;
                    }
                    // If the relationship between alpha and bravo is valid, 
                    // the output is unchanged and the loop continues.
                }
                else {
                    pointCount++;
                    /// 3) Creation - Create a new point and add it to points.
                    // Zerothly, assign alpha and bravo name;
                    // First, determine if new point is alpha or bravo.
                    bool isAlpha = (ContainsPoint(points, aName)) ? false : true;
                    // Second, determine the anchor and its coordinates
                    (int coX, int coY) coo = (0, 0);
                    if (isAlpha) {
                        coo = ReturnPointCoords(points, bName);
                    }
                    else {
                        coo = ReturnPointCoords(points, aName);
                    }
                    Point point = CreateAdditionalPoint(coo, isAlpha, instr[instrNo]);
                    points[pointCount - 1] = point;
                }
            }
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchorCoord">The coordinates for the existing
        /// point in the given instruction.</param>
        /// <param name="isAlpha">Is the additional point the first or
        /// second point in the instruction?</param>
        /// <param name="instr">The entire instruction.</param>
        /// <returns>A new point from a given instruction, assuming a preexisting point.</returns>
        static Point CreateAdditionalPoint((int x, int y) anchorCoord, bool isAlpha, Match instr) {
            Point output = new Point();
            string dir = (isAlpha) ? instr.Groups[2].Value : InvertDir(instr.Groups[2].Value);
            output.name = (isAlpha) ? instr.Groups[1].Value : instr.Groups[3].Value;
            output.coord = ReturnCoordFromAnchor(dir, anchorCoord);
            return output;
        }


        /// <summary>
        /// Returns the initial points for a given set of rules.
        /// </summary>
        /// <param name="instr">First instruction.</param>
        /// <returns>The first two points of the list of rules.</returns>
        static (Point alpha, Point bravo) GetFirstPoints(Match instr) {
            Point bravo;
            bravo.name = instr.Groups[3].Value;
            bravo.coord.x = 0;
            bravo.coord.y = 0;

            Point alpha;
            alpha.name = instr.Groups[1].Value;
            alpha.coord = ReturnCoordFromAnchor(instr.Groups[2].Value, bravo.coord);

            return (alpha, bravo);
        }

        /// <summary>
        /// Returns Coordinates for a point given a starting (anchor) point and a direction.
        /// </summary>
        /// <param name="dir">The direction a point exists from the anchor point.</param>
        /// <param name="anchorCoordinates">The coordinates of the anchor point.</param>
        /// <returns>Coordinates for a point.</returns>
        static (int x, int y) ReturnCoordFromAnchor(string dir, (int x, int y) anchorCoordinates) {
            int x = anchorCoordinates.x;
            int y = anchorCoordinates.y;

            y +=  (dir.Contains("N")) ? 1 : 0;
            y += (dir.Contains("S")) ? -1 : 0;
            x += (dir.Contains("E")) ? 1 : 0;
            x += (dir.Contains("W")) ? -1 : 0;

            return (x, y);
        }

        /// <summary>
        /// Determines whether two existing points follow the given rule.
        /// </summary>
        /// <param name="alpha"></param>
        /// <param name="bravo"></param>
        /// <param name="dir"></param>
        /// <returns>True if the Instruction is Valid and False if the Instruction is Invalid.</returns>
        static bool DetermineValidInstruction(Point alpha, Point bravo, string dir) {
            bool yChecks = true;
            bool xChecks = true;
            if (dir.Contains("N")) {
                yChecks = IsNorthOf(alpha.coord, bravo.coord);
            }
            if (dir.Contains("S")) {
                yChecks = IsSouthOf(alpha.coord, bravo.coord);
            }
            if (dir.Contains("E")) {
                xChecks = IsEastOf(alpha.coord, bravo.coord);
            }
            if (dir.Contains("W")) {
                xChecks = IsWestOf(alpha.coord, bravo.coord);
            }
            return xChecks && yChecks;
        }

        static (int x, int y) ReturnPointCoords(Point[] points, string name) {
            (int x, int y) output = (0, 0);
            // Loop through each item in points.
            for (int point = 0; point < points.Length; point++) {
                // Assuming that a match exists in points.
                if (points[point].name == name) {
                    output = points[point].coord;
                }
            }
            return output;
        }

        static bool ContainsPoint(Point[] points, string pointName) {
            for (int i = 0; i < points.Length; i++) {
                if (points[i].name == null) {
                    break;
                }
                if (points[i].name == pointName) {
                    return true;
                }
            }
            return false;
        }

    }

    struct Point {
        public string name;
        public (int x, int y) coord;
    }
}
