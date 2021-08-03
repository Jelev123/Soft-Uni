using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    public class HappyBunny : Bunny
    {
        private const int INIT_ENERGY = 100;

        public HappyBunny(string name, int energy) : base(name, INIT_ENERGY)
        {

        }

        public HappyBunny(string bunnyName) : base()
        {
            throw new NotImplementedException();
        }
    }
}
