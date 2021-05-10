using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] number = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            var values = new Dictionary<double, int>();

            for (int i = 0; i < number.Length; i++)
            {
                if (!values.ContainsKey(number[i]))
                {
                    values.Add(number[i],new int());
                }

                values[number[i]]++;
            }

            foreach (var kvp in values)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
