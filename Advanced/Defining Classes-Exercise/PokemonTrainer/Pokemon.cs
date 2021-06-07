namespace PokemonTrainer
{
    public class Pokemon
    {
        public Pokemon(string name,string element)
        {
            this.Name = name;
            this.Element = element;
        }

        public Pokemon(string trainerName, string name, string element, int health)
        :this(name,element)
        {
            this.Health = health;
        }
        public string Name { get; set; }
        public string Element { get; set; }
        public int Health { get; set; }
    }
}