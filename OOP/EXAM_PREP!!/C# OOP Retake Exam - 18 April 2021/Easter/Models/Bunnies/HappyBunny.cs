using System;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int buny_energy = 100;
        public HappyBunny(string name) : base(name, buny_energy)
        {
        }

        
    }
}