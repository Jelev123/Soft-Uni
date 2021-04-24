using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = row + col;
                }
            }

            int currnetRow = 0;
            int currnetCol = 0;

            while (true)
            {

                if (currnetRow >= matrix.GetLength(0)
                    || currnetCol>= matrix.GetLength(1))
                {
                    break;
                }
                
                Console.WriteLine(matrix[currnetRow,currnetCol]);
                currnetRow++;
                currnetCol++;
            }
        }
    }
}
