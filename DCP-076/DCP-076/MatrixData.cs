using System;
using System.Collections.Generic;
using System.Text;

namespace DCP_076
{
    class MatrixData
    {
        public char[,] matrix;
        public int[,] matrixInt;

        public int nColumn = 0;
        public int mRow = 0;

        public MatrixData(int choice) {
            switch (choice) {
                case 1:
                    nColumn = 3;
                    mRow = 3;
                    matrix = new char[3, 3]{ {'c', 'd', 'g' },{'b', 'a', 'h' },{ 'a', 'f', 'i' } };
                    matrixInt = new int[3, 3];
                    break;
                case 2:
                    nColumn = 2;
                    mRow = 3;
                    matrix = new char[2, 3] { { 'c', 'd', 'g' },{ 'b', 'a', 'h' } };
                    matrixInt = new int[2, 3];
                    break;
                case 3:
                    nColumn = 1;
                    mRow = 6;
                    matrix = new char[1, 6] { { 'a', 'b', 'c', 'd', 'e', 'f' } };
                    matrixInt = new int[1, 6];
                    break;
                case 4:
                    nColumn = 3;
                    mRow = 3;
                    matrix = new char[3, 3] { {'z', 'w', 't' },{ 'y', 'v', 'u'},{ 'x', 'u', 'r' } };
                    matrixInt = new int[3, 3];
                    break;
                default:
                    nColumn = 1;
                    mRow = 1;
                    matrix = new char[1, 1];
                    matrixInt = new int[1, 1];
                    break;
            }
            //Populate MatrixInt
            for (int nCo = 0; nCo < nColumn; nCo++) {
                for (int mRo = 0; mRo < mRow; mRo++) {
                    matrixInt[nCo, mRo] = ReturnLetterValue(matrix[nCo, mRo]);
                }
            }
        }

        /// <summary>
        /// Input Char, Output Integer.
        /// </summary>
        /// <param name="inputChar">Input Letter.</param>
        /// <returns>Alphabet Position of Input Letter.</returns>
        int ReturnLetterValue(char inputChar)
        {
            switch (inputChar)
            {
                case 'a':
                    return 1;
                case 'b':
                    return 2;
                case 'c':
                    return 3;
                case 'd':
                    return 4;
                case 'e':
                    return 5;
                case 'f':
                    return 6;
                case 'g':
                    return 7;
                case 'h':
                    return 8;
                case 'i':
                    return 9;
                case 'j':
                    return 10;
                case 'k':
                    return 11;
                case 'l':
                    return 12;
                case 'm':
                    return 13;
                case 'n':
                    return 14;
                case 'o':
                    return 15;
                case 'p':
                    return 16;
                case 'q':
                    return 17;
                case 'r':
                    return 18;
                case 's':
                    return 19;
                case 't':
                    return 20;
                case 'u':
                    return 21;
                case 'v':
                    return 22;
                case 'w':
                    return 23;
                case 'x':
                    return 24;
                case 'y':
                    return 25;
                case 'z':
                    return 26;
                default:
                    return 0;
            }
        }
    }
}
