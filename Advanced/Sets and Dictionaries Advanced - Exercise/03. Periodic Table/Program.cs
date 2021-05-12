using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var set = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(" ");

                foreach (var item in tokens)
                {
                    set.Add(item);
                }
                
            }

            foreach (var elemets in set.OrderBy(x=>x))
            {
                Console.Write($"{elemets + " "}");
            }
        }
    }
}
