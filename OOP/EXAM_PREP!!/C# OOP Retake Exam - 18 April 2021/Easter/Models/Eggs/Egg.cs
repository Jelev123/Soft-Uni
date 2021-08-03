using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Eggs.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Eggs
{
  public  class Egg : IEgg
  {
        private const int DECREASE_ENERGY = 10;

      private string name;
      private int energyRequired;

      public Egg(string name, int energyRequired)
        {
            this.Name = name;
            this.EnergyRequired = energyRequired;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEggName);
                }

                this.name = value;
            }
        }

        public int EnergyRequired
        {
            get
            {
                return this.energyRequired;
            }
            private set
            {
                this.energyRequired = value > 0 ? value : 0;
            }
        }
        public void GetColored()
        {
            this.energyRequired -= DECREASE_ENERGY;
        }

        public bool IsDone()
        {
            return this.energyRequired == 0;
        }
  }
}
