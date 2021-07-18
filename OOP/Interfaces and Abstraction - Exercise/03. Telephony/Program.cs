using System;
using _03._Telephony;
using _03._Telephony.Exceptions;

namespace Telephony
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split();
            string[] sites = Console.ReadLine().Split();

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            try
            {
                for (int i = 0; i < phoneNumbers.Length; i++)
                {
                    if (phoneNumbers[i].Length == 7)
                    {
                        Console.WriteLine(stationaryPhone.Call(phoneNumbers[i]));
                    }
                    else if (phoneNumbers[i].Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(phoneNumbers[i]));
                    }
                    else
                    {
                        throw new InvalidNumberException();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            try
            {
                for (int i = 0; i < sites.Length; i++)
                {
                    Console.WriteLine(smartphone.Browse(sites[i]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
              
            }
           
        }
    }
}
