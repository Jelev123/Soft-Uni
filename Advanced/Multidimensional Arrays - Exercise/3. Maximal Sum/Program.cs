using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int rows = dimension[0];
            int cols = dimension[1];
            var matrix = new int[rows, cols];

            InitializeMatrix(matrix);

            int maxSum = int.MinValue;
            int targetRow = 0;
            int targetCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix.Length)
                    {
                        int currnetSum = matrix[row, col] + matrix[row + 1,
                            col] + matrix[row + 2, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                            matrix[row + 1, col + 1] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2] +
                            matrix[row + 1, col + 2];

                        if (currnetSum > maxSum)
                        {
                            maxSum = currnetSum;
                            targetRow = row;
                            targetCol = col;
                        }
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");

            for (int row = targetRow; row <= targetRow + 2; row++)
            {
                for (int col = targetCol; col <= targetCol + 2; col++)
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

                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
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
