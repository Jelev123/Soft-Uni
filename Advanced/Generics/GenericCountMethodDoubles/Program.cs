using System;
using System.Collections.Generic;

namespace GenericCountMethodDoubles
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<double> box = new Box<double>();

            for (int i = 0; i < n; i++)
            {
                double line = double.Parse(Console.ReadLine());
                box.Add(line);
            }

            double element = double.Parse(Console.ReadLine());
            int count = GetCount(box.Text, element);

            Console.WriteLine(count);
        }


        public static int GetCount<T>(List<T> data, T element) where T : IComparable
        {
            int count = 0;

            foreach (var comparable in data)
            {
                if (comparable.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }



    }
    }

