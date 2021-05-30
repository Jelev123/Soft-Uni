using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Microsoft.VisualBasic.CompilerServices;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();


            for (int i = 0; i < n; i++)
            {
                int[] commandAsIndex = Console.ReadLine().Split()
                    .Select(int.Parse)
                    .ToArray();
                int command = commandAsIndex[0];

                if (command == 1)
                {
                    int elementsToPush = commandAsIndex[1];
                    stack.Push(elementsToPush);
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

            Console.WriteLine(string.Join(", ", stack));


        }

    }
}





