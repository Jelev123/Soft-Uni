using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Races
{
   public class Race : IRace
   {
       private string name;
       private int laps;
      
        public Race(string name, int laps)
        {
            Name = name;
            Laps = laps;
            
        }

        #region Implementation of IRace

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName, value, 5));
                }
                this.name = value;
            }

        }

        public int Laps
        {
            get => this.laps;
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfLaps);
                }

                this.laps = value;
            }
        }
        public IReadOnlyCollection<IDriver> Drivers { get; private set; }
        public void AddDriver(IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentException(ExceptionMessages.DriverInvalid);
            }

            if (driver.CanParticipate == false)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverNotParticipate));
            }

            if (Drivers.Any(x=>x.Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.DriverAlreadyAdded));
            }
            
        }

        #endregion
    }
}
