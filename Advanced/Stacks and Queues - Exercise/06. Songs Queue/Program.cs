using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] songs = Console.ReadLine().Split(", ");

            var queue = new Queue<string>(songs);

            

            while (queue.Count > 0)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                string comand = tokens[0];

                if (comand == "Play")
                {
                    queue.Dequeue();
                }
                else if (comand == "Add")
                {
                    string songName = input.Substring(4);

                    if (!queue.Contains(songName))
                    {
                        queue.Enqueue(songName);
                    }
                    else
                    {
                        Console.WriteLine($"{songName} is already contained!");
                    }

                }
                else if (comand == "Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }
                
            }

            Console.WriteLine("No more songs!");
        }
    }
}
