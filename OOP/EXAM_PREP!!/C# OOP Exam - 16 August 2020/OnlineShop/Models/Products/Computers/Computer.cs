using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer: Product,IComputer
    {

        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        #region Overrides of Product

        public override double OverallPerformance
        {
            get
            {
                if (!this.Components.Any())
                {
                    return base.OverallPerformance;
                }
                var componentsAveragePerformance = this.Components.Any() ? this.Components.Average(c => c.OverallPerformance) : 0;

                return base.OverallPerformance + componentsAveragePerformance;
            }
        }

        public override decimal Price
        {
            get
            {
                decimal componentsPrice = this.Components.Any() ? this.Components.Sum(c => c.Price) : 0;
                decimal peripheralsPrice = this.Peripherals.Any() ? this.Peripherals.Sum(p => p.Price) : 0;

                return base.Price + componentsPrice + peripheralsPrice;
            }
        }

        #endregion

        #region Implementation of IComputer

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();
        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();
        public void AddComponent(IComponent component)
        {
            if (this.Components.Any(c => c.GetType().Name == component.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, component.GetType().Name,
                    this.GetType().Name, Id));
            }
            components.Add(component);
        }

        public IComponent RemoveComponent(string componentType)
        {
            if (Components.All(c => c.GetType().Name != componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent,
                    componentType, GetType().Name, Id));
            }

            IComponent componenTypes = components.FirstOrDefault(c => c.GetType().Name == componentType);
            components.Remove(componenTypes);
            return componenTypes;
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            if (Peripherals.Any(c => c.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral,
                    peripheral.GetType().Name, GetType().Name, Id));
            }

            peripherals.Add(peripheral);
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            if (Peripherals.All(c => c.GetType().Name != peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType,
                    GetType().Name, Id));
            }

            IPeripheral peripheral = this.Peripherals
                .First(c => c.GetType().Name == peripheralType);

            this.peripherals.Remove(peripheral);
            return peripheral;
        }

        #region Overrides of Product

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(base.ToString());
            stringBuilder.AppendLine(" " + String.Format(SuccessMessages.ComputerComponentsToString, this.Components.Count));
            foreach (IComponent component in this.Components)
            {
                stringBuilder.AppendLine("  " + component.ToString());
            }

            stringBuilder.AppendLine(" " + String.Format(SuccessMessages.ComputerPeripheralsToString, this.Peripherals.Count,
                this.Peripherals.Any() ? this.Peripherals.Average(p => p.OverallPerformance) : 0));
            foreach (var peripheral in this.Peripherals)
            {
                stringBuilder.AppendLine("  " + peripheral.ToString());
            }

            return stringBuilder.ToString().TrimEnd();
        }

        #endregion

        #endregion
    }
}

