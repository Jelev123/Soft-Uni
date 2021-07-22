namespace Vehicle.Models
{
    public class Truck : Vehicle
    {
        private const double FUEL_CONSUPTION = 1.6;
        private const double FUEL_EFICYANCI = 0.95;
       
        public Truck(double fuelQty, double fuelCons) : base(fuelQty, fuelCons)
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
                base.FuelCons = value + FUEL_CONSUPTION;
            }
        }

        #endregion

        #region Overrides of Vehicle

        public override void Refuel(double fuelAmount)
        {
            base.Refuel(fuelAmount * FUEL_EFICYANCI);
        }

        #endregion
    }
}