using System;
using System.Collections.Generic;
using System.Text;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars
{
 public  abstract class Car: ICar
    {
        #region Implementation of ICar

        private string model;
        private int horsepower;
        private int minHoresePower;
        private int maxHorsePower;


        public Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower
        )
        {
            this.maxHorsePower = maxHorsePower;
            this.minHoresePower = minHoresePower;

            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;

        }

        public string Model
        {
            get => this.model;

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidModel,value,4));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get => this.horsepower;

            private set
            {
                if (value < minHoresePower || value > maxHorsePower)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHorsePower);
                }

                this.horsepower = value;
            }

        }
        public double CubicCentimeters { get; private set; }
        public double CalculateRacePoints(int laps)
        {
            return CubicCentimeters / horsepower * laps;
        }

        #endregion
    }
}
