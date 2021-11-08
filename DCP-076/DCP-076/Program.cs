using System;

namespace DCP_076
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What example matrix would you like to try out?");
            Console.WriteLine("Enter an integer value between 1 and 4 (inclusive).");
            try {
                int choice = Convert.ToInt32(Console.ReadLine());
                if (choice > 0 || choice < 5)
                {
                    MatrixData data = new MatrixData(choice);
                    int[] dimensions = { data.nColumn, data.mRow };
                    int nColumn = dimensions[0];
                    int mRow = dimensions[1];
                    char[,] matrix = data.matrix;
                    int[,] matrixInt = data.matrixInt;

                    PrintCharacterMatrix(matrix, dimensions);
                    PrintIntegerMatrix(matrixInt, dimensions);

                    Console.WriteLine("Given the current Matrix, " + FindDeathMarks(matrixInt, dimensions) + " column(s) need to be deleted.");
                    Console.ReadLine();
                }
                else {
                    Console.WriteLine("Please enter a value within the bounds next time.");
                    Console.WriteLine("Thank you.");
                    Console.ReadLine();
                }
            }
            catch {
                Console.WriteLine("Please enter an integer value.");
                Console.ReadLine();
            }
        }


        
        /// <summary>
        /// Finds DeathMarks. Duh.
        /// </summary>
        /// <param name="matrixInt">Input Integer Matrix to Peruse.</param>
        /// <returns>The number of columns to be deleted.</returns>
        static int FindDeathMarks(int[,] matrixInt, int[] dims) {
            int[] markedForDeath = new int[dims[0]];
            for (int nColumn = 0; nColumn < dims[0]; nColumn++) {
                for (int mRow = 1; mRow < dims[0]; mRow++) {
                    if (matrixInt[nColumn, mRow] <= matrixInt[nColumn, mRow - 1]){
                        //Console.WriteLine(matrixInt[nColumn, mRow] + " <= " + matrixInt[nColumn, mRow - 1]);
                        markedForDeath[nColumn] = 1;
                    }
                    //Console.WriteLine("The value at: [" + nColumn + ", " + mRow + "] is " + matrixInt[nColumn, mRow]);
                }
            }
            int totalRowsToDelete = 0;
            for (int marks = 0; marks < markedForDeath.Length; marks++) {
                //Console.WriteLine("markedForDeath[" + marks + "] = " + markedForDeath[marks]);
                totalRowsToDelete += markedForDeath[marks];
            }
            return totalRowsToDelete;
        }

        /// <summary>
        /// Inputs 2D Integer Array, Prints contents on Console.
        /// </summary>
        /// <param name="matrixInt">2D Integer Array to Print</param>
        static void PrintIntegerMatrix(int[,] matrixInt, int[] dims) {
            Console.WriteLine("---Integer Matrix---");
            for (int mRow = 0; mRow < dims[1]; mRow++) {
                for (int nColumn = 0; nColumn < dims[0]; nColumn++) {
                    if (nColumn == dims[1] - 1) {
                        Console.Write(matrixInt[nColumn, mRow]);
                    }
                    else {
                        Console.Write(matrixInt[nColumn, mRow] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Inputs 2D Character Array, Prints contents on Console.
        /// </summary>
        /// <param name="matrix">2D Char Array to Print.</param>
        static void PrintCharacterMatrix(char[,] matrix, int[] dims) {
            Console.WriteLine("---Character Matrix---");
            for (int mRow = 0; mRow < dims[1]; mRow++) {
                for (int nColumn = 0; nColumn < dims[0]; nColumn++) {
                    if (nColumn == dims[1] - 1) {
                        Console.Write(matrix[nColumn, mRow]);
                    }
                    else {
                        Console.Write(matrix[nColumn, mRow] + " ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }

}
