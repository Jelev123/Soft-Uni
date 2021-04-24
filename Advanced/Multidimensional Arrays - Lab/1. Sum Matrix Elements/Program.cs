using System;
using System.Linq;

namespace _1._Sum_Matrix_Elements
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

            Console.WriteLine(rows);
            Console.WriteLine(cols);

            var sum = 0;

            foreach (var item in matrix)
            {
                sum += item;
            }

            Console.WriteLine(sum);
        }

    }
}
