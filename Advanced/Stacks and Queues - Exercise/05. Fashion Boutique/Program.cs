using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();
            var stack = new Stack<int>(clothesInBox);

            int capacity = int.Parse(Console.ReadLine());

            int sum = 0;
            int numberOfRacs = 1;

            while (stack.Count > 0)
            {
                sum += stack.Peek();

                if (sum<=capacity)
                {
                    stack.Pop();
                }
                else
                {
                    numberOfRacs++;
                    sum = 0;
                }
            }

            Console.WriteLine(numberOfRacs);
        }
    }
}
