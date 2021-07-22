using System;
using Vehicle.Common;

namespace Vehicle
{
    public abstract class Vehicle : IDrivable,IRefuel
    {
        protected Vehicle(double fuelQty, double fuelCons)
        {
            FuelQty = fuelQty;
            FuelCons = fuelCons;
        }

        public double FuelQty { get; set; }
        public virtual double FuelCons { get; protected set; }
        public string Drive(double kilometres)
        {
            double fuelNeeded = kilometres * FuelCons;

            if (fuelNeeded > FuelQty)
            {
                string messages = string.Format(ExceptionMesage.NotEnoughtFuelMessage, this.GetType().Name);
                throw new InvalidOperationException(messages);
            }

            FuelQty -= fuelNeeded;
            return $"{this.GetType().Name} travelled {kilometres} km";
        }

        public virtual void Refuel(double fuelAmount)
        {
            if (fuelAmount > 0)
            {
                FuelQty += fuelAmount;
            }
        }


        #region Overrides of Object

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQty}";
        }

        #endregion
    }
}