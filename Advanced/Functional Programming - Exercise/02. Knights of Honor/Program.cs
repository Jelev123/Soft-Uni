using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] knights = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var knight in knights)
            {
                Console.WriteLine($"Sir {knight}");
            }


        }
    }
}
