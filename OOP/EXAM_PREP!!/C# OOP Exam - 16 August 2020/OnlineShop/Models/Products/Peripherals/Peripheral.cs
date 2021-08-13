using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
  public  abstract class Peripheral: Product , IPeripheral
    {
        protected Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {

        }

        #region Implementation of IPeripheral

        public string ConnectionType { get; }


        #region Overrides of Product

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance}. Price: {Price} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id}) Connection Type: {ConnectionType}";

        }

        #endregion

        #endregion
    }
}
