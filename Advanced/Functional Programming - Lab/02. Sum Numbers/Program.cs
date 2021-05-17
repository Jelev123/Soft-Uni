﻿using System;
using System.Linq;

namespace _02._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
           

           Console.WriteLine(string.Join(" ",numbers.Length));
           Console.WriteLine(string.Join(" ", numbers.Sum()));


        }
    }
}
