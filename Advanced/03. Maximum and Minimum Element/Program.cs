using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            

            var stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());
            int max = int.MaxValue;
            int min = int.MinValue;
            for (int i = 0; i < n; i++)
            {
                int[] commandAsIndex = Console.ReadLine().Split()
                    .Select(int.Parse).ToArray();

                int command = commandAsIndex[0];

                if (command == 1)
                {
                    int commandElements = commandAsIndex[1];
                    stack.Push(commandElements);
                }
                else if (command == 2)
                {
                    stack.Pop();
                }
                else if (command == 3)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (command == 4)
                {
                    Console.WriteLine(stack.Min());
                }
            }

            Console.WriteLine(string.Join(", ",stack));
        }
    }
}
