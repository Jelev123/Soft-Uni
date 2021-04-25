using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var jagedArray = new int[n][];

            for (int i = 0; i < n; i++)
            {
                var numbers = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                jagedArray[i] = numbers;
            }

            string input = Console.ReadLine();

            while (input != "END")
            {
                var splited = input.Split();
                var command = splited[0];
                var row = int.Parse(splited[1]);
                var col = int.Parse(splited[2]);
                var value = int.Parse(splited[3]);


                if (row < 0 || row > jagedArray.Length-1) 
                {
                    Console.WriteLine("Invalid coordinates");
                }

               else if (col < 0 || col > jagedArray[row].Length - 1)
                {
                    Console.WriteLine("Invalid coordinates");

                }


                if (command.StartsWith("Add"))
                {
                    jagedArray[row][col] += value;
                }
                else if (command.StartsWith("Subtract"))
                {
                    jagedArray[row][col] -= value;
                }


                input = Console.ReadLine();
            }

            for (int i = 0; i < jagedArray.Length; i++)
            {
                for (int j = 0; j < jagedArray[i].Length; j++)
                {
                    Console.Write(string.Join(" ",jagedArray[i][j]+ " "));
                }

                Console.WriteLine();
            }

            
        }
    }
}
