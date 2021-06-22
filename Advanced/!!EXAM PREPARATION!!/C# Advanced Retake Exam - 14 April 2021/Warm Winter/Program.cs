using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Warm_Winter
{
    class Program
    {
        static void Main(string[] args)
        {
            var stackHat = new Stack<int>(Console.ReadLine().Split()
                .Select(int.Parse)
                .ToArray());
            var queeueScarf = new Queue<int>(Console.ReadLine().Split()
                .Select(int.Parse).ToArray());

            int sets = int.MinValue;
            var clothes = new List<int>();

            while (stackHat.Count > 0 && queeueScarf.Count > 0)
            {
                if (stackHat.Peek() > queeueScarf.Peek())
                {
                    clothes.Add(stackHat.Peek() + queeueScarf.Peek());
                    stackHat.Pop();
                    queeueScarf.Dequeue();

                }
                else if (queeueScarf.Peek() > stackHat.Peek())
                {
                    stackHat.Pop();
                }
                else if (stackHat.Peek() == queeueScarf.Peek())
                {
                    queeueScarf.Dequeue();
                    stackHat.Push(stackHat.Pop() + 1);

                }


            }
            Console.WriteLine($"The most expensive set is: {clothes.Max()}");

            Console.WriteLine(string.Join(" ",clothes));


        }
    }
}
