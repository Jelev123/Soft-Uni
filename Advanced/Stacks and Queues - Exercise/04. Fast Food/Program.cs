using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantityOfTheFood = int.Parse(Console.ReadLine());
            var orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            bool isCompleted = true;

            for (int i = 0; i < orders.Length; i++)
            {
                if (quantityOfTheFood >= orders[i])
                {
                    quantityOfTheFood -= queue.Dequeue();
                   

                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
                    isCompleted = false;
                    break;
                    ;

                }

                
            }

            if (isCompleted)
            {
                Console.WriteLine("Orders complete");
            }


        }
    }
}
