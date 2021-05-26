using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<int> box = new Box<int>();
            for (int i = 0; i < n; i++)
            {
                int line = int.Parse(Console.ReadLine());
                box.Add(line);
            }

            var nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            var first = nums[0];
            var second = nums[1];
            Swap(box.Names,first,second);

            Console.WriteLine(box);

        }

        static void Swap<T>(List<T>listWithData,int firstIndex,int secondIndex)
        {
            var temp = listWithData[firstIndex];
            listWithData[firstIndex] = listWithData[secondIndex];
            listWithData[secondIndex] = temp;
        }
    }
}
