using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Drivers
{
   public class Driver : IDriver
    {
        #region Implementation of IDriver

        private string name;
        private int numbersOfWins;

        public Driver(string name)
        {
            this.Name = name;
        }


        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidName,value,5));
                }
            }
        }
        public ICar Car { get; private set; }
        public int NumberOfWins { get; private set; }
        public bool CanParticipate { get; private set; }
        public void WinRace()
        {
            numbersOfWins++;
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                CanParticipate = false;
                throw new ArgumentException(ExceptionMessages.CarInvalid);
            }

            Car = car;
            CanParticipate = true;
        }

        #endregion
    }
}
