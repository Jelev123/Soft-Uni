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

            var colectionOfTrainers = new Dictionary<string, Trainers>();

            while (input != "Tournament")
            {
                string[] info = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = info[0];
                string pokemonName = info[1];
                string pokemonElement = info[2];
                int pokemonHealth = int.Parse(info[3]);

                if (!colectionOfTrainers.ContainsKey(trainerName))
                {
                    colectionOfTrainers.Add(trainerName,new Trainers(trainerName));
                }

                Trainers currnetTrainer = colectionOfTrainers.FirstOrDefault(x => x.Key == trainerName).Value;
                Pokemon pokemon = new Pokemon(trainerName, pokemonName, pokemonElement, pokemonHealth);

                currnetTrainer.CollectionOfPokemon.Add(pokemon);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                string element = input;

                foreach (var trainer in colectionOfTrainers)   
                {
                    if (trainer.Value.CollectionOfPokemon.Any(x=>x.Element==element))
                    {
                        trainer.Value.NumberOfBadges++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Value.CollectionOfPokemon)
                        {
                            pokemon.Health -= 10;
                        }

                        trainer.Value.CollectionOfPokemon.RemoveAll(x => x.Health <= 0);
                    }
                }

                input = Console.ReadLine();

            }

            var result = colectionOfTrainers.OrderByDescending(x => x.Value.NumberOfBadges);

            foreach (var item in result)
            {

                Console.WriteLine($"{item.Value.Name} {item.Value.NumberOfBadges} {item.Value.CollectionOfPokemon.Count}");


            }
        }
    }
}
