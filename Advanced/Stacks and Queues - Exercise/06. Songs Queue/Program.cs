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
            var songs = Console.ReadLine().Split(", ");
            var queue = new Queue<string>(songs);


            while (queue.Count > 0)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split();
                string command = tokens[0];

                if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command == "Add")
                {
                    string songToAdd = input.Substring(4);
                    if (!queue.Contains(songToAdd))
                    {
                        queue.Enqueue(songToAdd);
                    }
                    else
                    {
                        Console.WriteLine($"{songToAdd} is already contained!");
                    }
                }
                else if (command == "Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }

            }

            Console.WriteLine("No more songs!" );

        }
    }
}
