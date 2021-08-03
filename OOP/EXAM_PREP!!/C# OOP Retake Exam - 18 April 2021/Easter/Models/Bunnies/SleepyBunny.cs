using Easter.Models.Dyes.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Bunnies
{
    class SleepyBunny : Bunny
    {
        private const int INIT_ENERGY = 50;
        private const int DECREASE_ENERGY = 5;
        public SleepyBunny(string name, int energy) : base(name, INIT_ENERGY)
        {

        }

        public SleepyBunny(string bunnyName)
        {
            throw new NotImplementedException();
        }


        public override void Work()
        {
            base.Work();
            this.Energy -= DECREASE_ENERGY;
        }
    }
}
