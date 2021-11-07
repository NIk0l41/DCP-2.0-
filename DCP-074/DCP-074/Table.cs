using System;
using System.Collections.Generic;
using System.Text;

namespace DCP_074
{
    class Table
    {
        int[,] Contents;
        int Dimensions;

        public Table(int N) {
            Dimensions = N;
            Contents = CreateTable(N);
        }

        /// <summary>
        /// Returns a 2D Multiplication Table with dimensions N x N
        /// </summary>
        /// <param name="N">The dimensions of the multiplication table.</param>
        /// <returns>A 2D array contents.</returns>
        int[,] CreateTable(int N) {
            int[,] table = new int[N, N];
            for (int i = 0; i < N; i++) {
                for (int j = 0; j < N; j++) {
                    table[i, j] = (i + 1) * (j + 1);
                }
            }
            return table;
        }

        /// <summary>
        /// Prints the Contents of the Table Object.
        /// </summary>
        public void PrintTable() {
            for (int i = 0; i < Dimensions; i++) {
                for (int j = 0; j < Dimensions; j++) {
                    Console.Write(Contents[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        /// <summary>
        /// How many times does 'num' appear in the table?
        /// </summary>
        /// <param name="num">What number to find in the table.</param>
        /// <returns>Integer count of occurrences of 'num'.</returns>
        public int ReturnCount(int num) {
            int counter = 0;
            for (int i = 0; i < Dimensions; i++) {
                for (int j = 0; j < Dimensions; j++) {
                    if (Contents[i, j] == num) counter += 1;
                }
            }
            return counter;
        }
    }
}
