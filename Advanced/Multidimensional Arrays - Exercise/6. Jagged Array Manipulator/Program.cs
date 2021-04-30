using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var jagged = new double[n][];

            for (int i = 0; i < n; i++)
            {
                jagged[i] = Console.ReadLine().Split()
                    .Select(double.Parse)
                    .ToArray();
            }

            Analyze(jagged);

            Cheked(jagged);

        }

        private static void Analyze(double[][] jagged)
        {
            for (int row = 0; row < jagged.Length-1; row++)
            {
                if (jagged[row].Length == jagged[row+1].Length)
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] *= 2;
                        jagged[row + 1][col] *= 2;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].Length; col++)
                    {
                        jagged[row][col] /= 2;
                    }

                    for (int col = 0; col < jagged[row + 1].Length; col++)
                    {
                        jagged[row+1][col] /= 2;
                    }
                }
            }
        }

        private static void Cheked(double[][] jagged)
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] splited = input.Split();
                string command = splited[0];
                int row = int.Parse(splited[1]);
                int col = int.Parse(splited[2]);
                int value = int.Parse(splited[3]);


                if (row >= 0 && row < jagged.Length && col >= 0 && col < jagged[row].Length)
                {
                    if (command == "Add")
                    {
                        jagged[row][col] += value;
                    }
                    else
                    {
                        jagged[row][col] -= value;
                    }
                }
                input = Console.ReadLine();

            }

            foreach (var item in jagged)
            {
                Console.WriteLine(string.Join(" ", item));
            }


        }
    }
}


