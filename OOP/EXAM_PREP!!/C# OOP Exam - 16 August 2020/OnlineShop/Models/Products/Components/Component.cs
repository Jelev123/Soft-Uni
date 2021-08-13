using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
   public abstract class Component: Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
        }

        #region Implementation of IComponent

        public int Generation { get; }


        #region Overrides of Product

        public override string ToString()
        {
            return $"Overall Performance: {OverallPerformance}. Price: {Price} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id}) Generation: {Generation}";

        }

        #endregion

        #endregion
    }
}
