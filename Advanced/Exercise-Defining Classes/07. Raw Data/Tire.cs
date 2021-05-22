using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Tire
    {
        public Tire (double pressure, int age)
        {
            Pressure = pressure;
            Age = age;
        }

        public double Pressure { get; set; }
        public int Age { get; set; }
    }
}
    

