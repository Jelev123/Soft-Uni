using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var set = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());

                if (input % 2 == 0 || input % 2 != 0)
                {
                    set.Add(input);
                }
            }

            foreach (var i in set)
            {
                Console.WriteLine(i);
            }
        }
    }
}
