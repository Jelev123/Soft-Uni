using System;
using System.Collections.Generic;

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
                string[] command = input.Split();
                string action = command[0];

                if (action == "Play")
                {
                    queue.Dequeue();
                }
                else if (action == "Add")
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
                else if (action == "Show")
                {
                    Console.WriteLine(string.Join(", ",queue));
                }

                
            }

            Console.WriteLine("No more songs!");
            }
            
        }
    }

