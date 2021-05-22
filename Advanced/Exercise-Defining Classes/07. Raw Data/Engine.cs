using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
  public  class Engine
    {
        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }

        public int engineSpeed { get; set; }
        public int enginePower { get; set; }
    }
}
