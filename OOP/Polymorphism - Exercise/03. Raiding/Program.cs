using System;
using System.Collections.Generic;
using System.Linq;
using _03._Raiding.Models;

namespace _03._Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            var riders = new List<BaseHero>();
            BaseHero herro;
            int n = int.Parse(Console.ReadLine());
          
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();


                try
                {
                    if (type == "Druid")
                    {
                        herro = new Druid(name);
                    }
                    else if (type == "Warrior")
                    {
                        herro = new Warrior(name);
                    }
                    else if (type == "Paladin")
                    {
                        herro = new Paladin(name);
                    }
                    else if (type == "Rogue")
                    {
                        herro = new Rogue(name);
                    }
                    else
                    {
                        throw new ArgumentException("Invalid hero");
                    }

                   

                    riders.Add(herro);

                }

                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            }
           

            long bossPower = long.Parse(Console.ReadLine());

            foreach (var baseHero in riders)
            {
                Console.WriteLine(baseHero.CastAbility());
            }

            long allPowers = riders.Select(x => x.Power).Sum();


            if (allPowers >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }

        }
    }
}
