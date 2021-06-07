using System.Collections.Generic;

namespace PokemonTrainer
{
    public class Trainers
    {

        public Trainers(string name)
        {
            this.Name = name;
            this.NumberOfBadges = 0;
            this.CollectionOfPokemon = new List<Pokemon>();
        }

       
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> CollectionOfPokemon { get; set; }
    }
}