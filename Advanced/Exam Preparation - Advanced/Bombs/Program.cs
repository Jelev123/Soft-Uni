using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            var effect = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var casings = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int datura = 0;
            int cherry = 0;
            int smoke = 0;
                bool bombCreated = false;


                while (effect.Count > 0 && casings.Count > 0)
            {
                int currentEffect = effect.Peek();
                int currnetCasings = casings.Peek();
                int sum = currentEffect + currnetCasings;

                if (sum == 40)
                {
                    datura++;
                    effect.Dequeue();
                    casings.Pop();

                }
                else if (sum == 60)
                {
                    cherry++;
                    effect.Dequeue();
                    casings.Pop();

                }
                else if (sum == 120)
                {
                    smoke++;
                    effect.Dequeue();
                    casings.Pop();

                }
                
                else
                {
                    casings.Pop();
                    casings.Push(currnetCasings-5);
                }

                if (datura >= 3 && cherry >= 3 && smoke >= 3)
                {
                    bombCreated = true;
                    break;
                    
                }
            }

            if (bombCreated)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else 
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
             if (effect.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else if (effect.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(" ",effect)}");
            }
             if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else if (casings.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(" ",casings)}");
            }


            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");

        }

    }
}
