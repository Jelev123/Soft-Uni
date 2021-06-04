using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
   public class Startup
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var trainers = new Dictionary<string, Trainers>();

            while (input != "Tournament")
            {
                string[] info = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName,new Trainers(trainerName));
                }

                Trainers currnetTrainer = trainers.FirstOrDefault(x => x.Key == trainerName).Value;
                Pokemon pokemon = new Pokemon(trainerName, pokemonName, pokemonElement, pokemonHealth);

                input = Console.ReadLine();
            }
        }
    }
}
