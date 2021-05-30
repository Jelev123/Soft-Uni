using System;
using System.Collections.Generic;
using System.Linq;

namespace Generic_Swap_Method_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> box = new Box<string>();


            for (int i = 0; i < n; i++)
            {
                string lines = Console.ReadLine();
                box.Add(lines);

            }

            int[] nums = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int first = nums[0];
            int second = nums[1];
            Swap(box.Names,first,second);

            Console.WriteLine(box);
            

        }

        static void Swap<T>(List<T> data,int firstIndex,int secondIndex)
        {
            var temp = data[firstIndex];
            data[firstIndex] = data[secondIndex];
            data[secondIndex] = temp;
        }
    }
    }

