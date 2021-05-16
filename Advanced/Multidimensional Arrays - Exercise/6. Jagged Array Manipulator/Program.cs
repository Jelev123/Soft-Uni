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
            var n = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray();
            var rows = n[0];
            var cols = n[1];

            var matrix = new char[rows, cols];

            InitializeMatrix(matrix);
            int counter = 0;

            for (int row = 0; row < matrix.GetLength(0)-1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1)-1; col++)
                {
                    if (row >= 0 && row < matrix.Length && col >= 0 && col < matrix.Length)
                    {
                        if (matrix[row , col] == matrix[row + 1 ,col] &&
                            matrix[row,col] == matrix[row,col+1] && 
                            matrix[row,col] == matrix[row +1,col+1])
                        {
                            counter++;
                        }
                    }
                }
            }

            Console.WriteLine(counter);
            
        }

        private static void InitializeMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                char[] input = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = input[j];
                }
            }
        }
    }
}



