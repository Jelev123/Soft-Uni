using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Dyes.Contracts;

namespace Easter.Models.Dyes
{
    public class Dye : IDye
    {

        private const int DECREASE_POWER = 10;

        private int power;

        public Dye(int power)
        {
            Power = power;
        }

        public int Power
        {
            get
            {
                return this.power;
            }
            private set
            {
                this.power = value > 0 ? value : 0;
            }
        }
        public void Use()
        {
            this.power -= DECREASE_POWER;
        }

        public bool IsFinished()
        {
            return this.power == 0;
        }
    }
}
