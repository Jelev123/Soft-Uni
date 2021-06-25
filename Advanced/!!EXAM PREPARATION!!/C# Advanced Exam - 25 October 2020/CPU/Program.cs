using System;
using System.Collections.Generic;
using System.Linq;

namespace CPU
{
    class Program
    {
        static void Main(string[] args)
        {
            var stackTask = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var queueThreads = new Queue<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int valueToBeKilled = int.Parse(Console.ReadLine());

            bool isKilled = false;


            while (true)
            {

                if (stackTask.Peek() == valueToBeKilled)
                {
                    break;
                }
                if (queueThreads.Peek() >= stackTask.Peek())
                {
                    queueThreads.Dequeue();
                    stackTask.Pop();

                }
                else if (queueThreads.Peek() < stackTask.Peek())
                {
                    queueThreads.Dequeue();
                   
                   

                }
               
            }

            Console.WriteLine($"Thread with value {queueThreads.Peek()} killed task {valueToBeKilled}");
            Console.WriteLine(string.Join(" ",queueThreads));

            

        }
    }
}
