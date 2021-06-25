using System;
using System.Linq;

namespace Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine().Split();
            int rows = int.Parse(dimension[0]);
            int cols = int.Parse(dimension[1]);
            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = 0;
                }
            }


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Bloom Bloom Plow")
                {
                    break;
                }

                var rowIndex = int.Parse(command[0].ToString());
                var colIndex = int.Parse(command[2].ToString());

                if (rowIndex < 0 || rowIndex > matrix.GetLength(0) && colIndex < 0 || colIndex > matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                    continue;
                }
                
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        matrix[rowIndex, i]++;
                    }

                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        matrix[j, colIndex]++;
                    }

                    matrix[rowIndex, colIndex]--;

                 
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col     = 0; col     < cols; col    ++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
