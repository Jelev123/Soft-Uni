using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            var token = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var stack = new Stack<int>(numbers);
            var s = token[1];

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            int x = token[2];

            if (stack.Contains(x))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }

        }
    }
}
