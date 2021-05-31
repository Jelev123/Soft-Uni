using System;
using System.Linq;
using System.Security.Claims;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimension = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int rows = dimension[0];
            int cols = dimension[1];
            var matrix = new string[rows, cols];

            InitializeMatrix(matrix);


            string input = Console.ReadLine();

            while (input != "END")
            {
                var tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];
                if (command == "swap")
                {
                    int firstRow = int.Parse(tokens[1]);
                    int firstCol = int.Parse(tokens[2]);
                    int secondRow =int.Parse(tokens[3]);
                    int secondCol = int.Parse(tokens[4]);

                    if (firstRow >= 0 && firstRow < matrix.Length && firstCol >= 0 && firstCol < matrix.Length &&
                        secondRow >= 0 && secondRow < matrix.Length && secondCol >= 0 && secondCol < matrix.Length)
                    {
                        var temp = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col     = 0; col     < matrix.GetLength(1); col    ++)
                            {
                                Console.Write(matrix[row,col] + " ");
                            }

                            Console.WriteLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
                
                input = Console.ReadLine();
            }

        }

        private static void InitializeMatrix(string[,] matrix)
        {

            for (int row = 0; row < matrix.GetLength(0); row++)
            {

                var input = Console.ReadLine()
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    ;
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
