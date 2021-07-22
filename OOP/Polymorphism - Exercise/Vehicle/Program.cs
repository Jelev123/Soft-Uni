using System;
using Vehicle.Models;
using Vehicle.Models.Contracts;

namespace Vehicle
{
    class Program
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
