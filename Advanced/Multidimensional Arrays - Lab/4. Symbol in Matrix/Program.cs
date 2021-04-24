using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToArray();
            var rows = dimension[0];
            var cols = dimension[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var currnetRow = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currnetRow[col];
                }
            }

            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    var sum2x2Matrix = matrix[row, col] + matrix[row + 1, col]
                                                        + matrix[row, col + 1]
                                                        +matrix[row +1,col +1];
                    if (sum2x2Matrix > maxSum)
                    {
                        maxSum = sum2x2Matrix;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[maxRow,maxCol]} {matrix[maxRow,maxCol+1]}");
            Console.WriteLine($"{matrix[maxRow+1,maxCol]} {matrix[maxRow+1,maxCol+1]}");
            Console.WriteLine(maxSum);
            
        }
    }
}
