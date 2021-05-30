using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split().Select(int.Parse);
            int capacyOfRack = int.Parse(Console.ReadLine());

            var stack = new Stack<int>(clothes);
            int sum = 0;
            int numberOfRacks = 1;

            while (stack.Count>0)
            {
                sum += stack.Peek();

                if (sum <=capacyOfRack)
                {
                    stack.Pop();
                }
                else
                {
                    numberOfRacks++;
                  
                }
            }

            Console.WriteLine(numberOfRacks);
        }
    }
}
