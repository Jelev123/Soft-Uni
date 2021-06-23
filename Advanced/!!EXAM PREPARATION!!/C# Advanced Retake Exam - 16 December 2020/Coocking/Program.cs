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

            

            var food = new SortedDictionary<string, int>();
            food.Add("Bread", 0);
            food.Add("Cake", 0);
            food.Add("Pastry", 0);
            food.Add("Fruit Pie", 0);

            while (queueLiqiud.Count > 0 && stacIngredients.Count > 0)
            {
                int liquid = queueLiqiud.Peek();
                int ingredients = stacIngredients.Peek();
                int sum = liquid + ingredients;

                if (sum == 25)
                {
                    
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                    food["Bread"]++;

                }

               else if (sum == 50)
                {
                    
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                    food["Cake"]++;
                }

                else if (sum == 75)
                {
                    
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                    food["Pastry"]++;
                }

                else if (sum == 100)
                {
                    
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                    food["Fruit Pie"]++;
                }
                else
                {
                    queueLiqiud.Dequeue();
                    stacIngredients.Pop();
                    stacIngredients.Push(ingredients + 3);
                }

            }

            if (food["Bread"] >= 1 && food["Cake"] >= 1 && food["Pastry"] >= 1 && food["Fruit Pie"] >= 1)
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

            foreach (var i in food)
            {
                Console.WriteLine($"{i.Key}: {i.Value}");
                
            }

            




        }
    }
}
