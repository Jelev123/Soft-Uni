namespace EasterRaces.Models.Cars
{
    public class MuscleCar : Car
    {
        private const int cubicSantimeters = 5000;
        private const int maxHorsePower = 600;
        private const int minHorsePower = 400;
        public MuscleCar(string model, int horsePower) : base(model, horsePower, cubicSantimeters, minHorsePower, maxHorsePower)
        {

        }
    }
}