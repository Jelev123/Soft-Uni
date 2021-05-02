using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimension = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rows = dimension[0];
            var cols = dimension[1];

            var matrix = new string[rows, cols];

            Matrix(matrix);

            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] splited = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var command = splited[0];

                if (command == "swap" && splited.Length==5)
                {

                    int firstRow = int.Parse(splited[1]);
                    int firstCol = int.Parse(splited[2]);
                    int secondRow = int.Parse(splited[3]);
                    int secondCol = int.Parse(splited[4]);

                    if (firstRow >= 0 && firstRow < rows-1 && firstCol >= 0 && firstCol <= cols-1 && 
                        secondRow >= 0 && secondRow <= rows-1 && secondCol >= 0 && secondCol <= cols-1)
                    {
                        var temp = matrix[firstRow, firstCol];
                        matrix[firstRow, firstCol] = matrix[secondRow, secondCol];
                        matrix[secondRow, secondCol] = temp;

                        for (int row = 0; row < matrix.GetLength(0); row++)
                        {
                            for (int col = 0; col < matrix.GetLength(1); col++)
                            {
                                Console.Write($"{matrix[row,col] + " "}");
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

        private static void Matrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
        }
    }
}
