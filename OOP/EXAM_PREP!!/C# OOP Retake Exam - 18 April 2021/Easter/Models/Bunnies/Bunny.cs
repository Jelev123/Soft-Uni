using System;
using System.Collections.Generic;
using System.Text;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Models.Bunnies
{
 public  abstract class Bunny : IBunny
    {
      


        private const int BUNNY_ENERGY = 10;

        private string name;
        private int energy;



        public Bunny(string name, int energy)
        {
            Name = name;
            Energy = energy;
            this.Dyes = new List<IDye>();

        }

        protected Bunny()
        {

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
                    throw new ArgumentException(ExceptionMessages.InvalidBunnyName);
                }

                this.name = value;
            }
        }


        public int Energy
        {
            get
            {
                return this.energy;
            }
            protected set
            {
                this.energy = value > 0 ? value : 0;
            }
        }

        public ICollection<IDye> Dyes
        {
            get;
        }
        public virtual void Work()
        {
            return;
            this.energy -= BUNNY_ENERGY;
        }

        public void AddDye(IDye dye)
        {
            this.Dyes.Add(dye);
        }


    }
}
