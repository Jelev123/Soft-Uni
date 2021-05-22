using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Cargo
    {
        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }


        public int cargoWeight { get; set; }
        public string cargoType { get; set; }
    }
}
