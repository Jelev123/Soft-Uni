namespace EasterRaces.Models.Cars
{
    public class SportsCar : Car
    {
        private const int cubicCentimeters = 3000;
        private const int maxHorsePower = 250;
        private const int minHorsePower = 450;
        public SportsCar(string model, int horsePower) : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        {

        }
    }
}