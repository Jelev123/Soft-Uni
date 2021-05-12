using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            var element = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var n = element[0];
            var m = element[1];
            var nSet = new HashSet<int>();
            var mSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                var input = int.Parse(Console.ReadLine());
                nSet.Add(input);
            }

            for (int i = 0; i < m; i++)
            {
                var input = int.Parse(Console.ReadLine());
                mSet.Add(input);
            }

            nSet.SetEquals(mSet);

            Console.WriteLine(string.Join(" ",nSet));
        }
    }
}
