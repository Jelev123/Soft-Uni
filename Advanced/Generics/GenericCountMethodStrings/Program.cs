using System;
using System.Collections.Generic;

namespace GenericCountMethodStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Box<string> text = new Box<string>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                text.str.Add(line);
            }


        }

        public static int GetCountOff<T> (List<T> listWithData, T element) where  T: IComparable
        {
            int count = 0;

            foreach (var item in listWithData)
            {
                if (item.CompareTo(element) < 0)
                {
                    count++;
                }

                return count;
            }
        }
    }
}
