using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] dimension = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var matrix = new int[dimension[0], dimension[1]];

            InitializeMatrix(matrix);

            int sum = int.MinValue;
            int targetRow = 0;
            int targetCol = 0;

            for (int row = 0; row < matrix.GetLength(0)-2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-2; col++)
                {
                    if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix.Length)
                    {
                        int currentSum= (matrix[row, col] + matrix[row + 1, col] +
                                        matrix[row + 2, col] +
                                        matrix[row, col + 1] +
                                        + matrix[row, col + 2] +
                                        matrix[row + 1, col + 1] + 
                                       matrix[row + 2, col + 1]  +
                                        matrix[row + 2, col + 2]  +
                                        matrix[row + 1, col + 2]);

                        if (currentSum > sum)
                        {
                            sum = currentSum;
                             targetRow = row;
                             targetCol = col;
                        }


                    }
                }
            }

            Console.WriteLine($"Sum = {sum}");

            for (int row = targetRow; row <= targetRow +2; row++)
            {
                for (int col = targetCol; col <= targetCol+2; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void InitializeMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}



