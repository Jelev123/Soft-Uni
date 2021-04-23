using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int quantity = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var queue = new Queue<int>(orders);

            Console.WriteLine(queue.Max());

            bool isCompleted = true;
            for (int i = 0; i < orders.Length; i++)
            {
                if (orders[i] <= quantity)
                {
                   quantity-= queue.Dequeue();
                }
                else
                {
                    Console.WriteLine($"Orders left: {string.Join(" ",queue)}");
                    isCompleted = false;
                    break;
                    
                }
            }
            if (isCompleted)
            {
                Console.WriteLine("Orders complete");
            }

        }
    }
}
