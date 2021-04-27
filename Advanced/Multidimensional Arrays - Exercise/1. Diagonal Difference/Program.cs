using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var jaged = new int[n][];

            for (int i = 0; i < n; i++)
            {

                jaged[i] = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int firstDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                firstDiagonal += jaged[row][row];
                
            }

            int secondDiagonal = 0;

           

            for (int row = 0,col=n-1; row < n; row++,col--)
            {
                secondDiagonal += jaged[row][col];
            }

            Console.WriteLine(secondDiagonal-firstDiagonal);
        }
    }
}
