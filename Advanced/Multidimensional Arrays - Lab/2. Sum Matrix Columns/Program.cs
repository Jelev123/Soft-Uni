using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main(string[] args)
        {

            var sized = Console.ReadLine()
                .Split(",")
                .Select(int.Parse)
                .ToArray();

            var rows = sized[0];
            var cols = sized[1];
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var col = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[row, c] = col[c];
                }
            }

            for (int col = 0; col < cols; col++)
            {
                int sum = 0;
                for (int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }

                Console.WriteLine(sum);
            }
        }
    }
}
