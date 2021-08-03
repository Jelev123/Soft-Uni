using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easter.Models.Bunnies;
using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops;
using Easter.Repositories.Contracts;
using Easter.Utilities.Messages;

namespace Easter.Core.Contracts
{
  public  class Controller : IController
  {

      private const int MIN_ENERGY = 50;

      private BunnyRepository bunnies;
      private EggRepository eggs;


      public Controller()
        {
            this.bunnies = new BunnyRepository();
            this.eggs = new EggRepository();
        }
        public string AddBunny(string bunnyType, string bunnyName)
        {
            IBunny bunny = null;

            if (bunnyType == "HappyBunny")
            {
                bunny = new HappyBunny(bunnyName);
            }

            if (bunnyType == "SleepyBunny")
            {
                bunny = new SleepyBunny(bunnyName);
            }

            if (bunny == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidBunnyType);
            }
            this.bunnies.Add(bunny);

            return String.Format(OutputMessages.BunnyAdded, bunnyType, bunnyName);
        }

        public string AddDyeToBunny(string bunnyName, int power)
        {
            IBunny bunny = this.bunnies.FindByName(bunnyName);

            if (bunnyName == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InexistentBunny);
            }

            IDye dye = new Dye(power);
            bunny.AddDye(dye);

            return  String.Format(OutputMessages.DyeAdded,power,bunnyName);
        }

        public string AddEgg(string eggName, int energyRequired)
        {
            IEgg egg = new Egg(eggName, energyRequired);
            eggs.Add(egg);

            return  String.Format(OutputMessages.EggAdded,eggName);
        }

        public string ColorEgg(string eggName)
        {
            Workshop workshop = new Workshop();
            IEgg egg = this.eggs.FindByName(eggName);

            ICollection<IBunny> bunies = this.bunnies
                .Models
                .Where(b => b.Energy >= MIN_ENERGY)
                .OrderByDescending(b => b.Energy)
                .ToList();

            if (!bunies.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.BunniesNotReady);
            }


            IBunny bunny = bunies.First();

            while (bunies.Any())
            {
                workshop.Color(egg,bunny);

                if (!bunny.Dyes.Any())
                {
                    bunies.Remove(bunny);
                }
                if (bunny.Energy == 0)
                {
                    bunnies.Remove(bunny);
                    bunies.Remove(bunny);
                }

                if (egg.IsDone())
                {
                    break;
                }
            }

            string output = egg.IsDone()
                ? String.Format(OutputMessages.EggIsDone)
                : String.Format(OutputMessages.EggIsNotDone,eggName);

            return output;
        }

        public string Report()
        {
            int countColored = this.eggs.Models.Count(p => p.IsDone());

            var sb = new StringBuilder();

            sb.AppendLine($"{countColored} eggs are done!")
                .AppendLine("Bunnies info:");


            foreach (IBunny bunnies in this.bunnies.Models)
            {
                int countDyes = bunnies.Dyes
                    .Count(p => p.IsFinished());
                sb.AppendLine($"Name: {bunnies.Name}")
                    .AppendLine($"Energy: {bunnies.Energy}")
                    .AppendLine($"Dyes: {countDyes} not finished");
            }

            return sb.ToString().TrimEnd();

        }
  }
}
