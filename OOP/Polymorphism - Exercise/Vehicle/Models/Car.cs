

namespace Vehicle.Models
{
    public class Car : Vehicle
    {
        private const double Fuel_Consumtion = 0.9;
        public Car(double fuelQty, double fuelCons) : base(fuelQty, fuelCons)
        {

        }

        #region Overrides of Vehicle

        public override double FuelCons
        {
            get
            {
                return base.FuelCons;
            }

            protected set
            {
                base.FuelCons = value + Fuel_Consumtion;
            }

        }

        #endregion
    }
}
