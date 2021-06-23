using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coocking
{
    class Program
    {
        static void Main(string[] args)
        {

            var queueLiqiud = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            var stacIngredients = new Stack<int>(Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;
            bool isEmpty = false;

            while (queueLiqiud.Count > 0 && stacIngredients.Count > 0)
            {
                int liquid = queueLiqiud.Peek();
                int ingredients = stacIngredients.Peek();
                int sum = liquid + ingredients;

                if (sum == 25)
                {
                    bread++;
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                }

               else if (sum == 50)
                {
                    cake++;
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                }

                else if (sum == 75)
                {
                    pastry++;
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                }

                else if (sum == 100)
                {
                    fruitPie++;
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                }
                else
                {
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                    stacIngredients.Push(ingredients + 3);
                }

            }

            if (stacIngredients.Count == 0 && queueLiqiud.Count == 0)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");

            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything."
                    );
            }

            if (queueLiqiud.Count == 0)
            {
                Console.WriteLine("Liquids left: none");

            }
            else
            {
                Console.WriteLine($"Liquids left: {queueLiqiud}");
            }

            if (stacIngredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ",stacIngredients)}");

            }

            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
           

            




        }
    }
}
