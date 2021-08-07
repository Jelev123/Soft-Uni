using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.BakedFoods
{
   public abstract class BakedFood : IBakedFood
    {
        #region Implementation of IBakedFood

        private string name;
        private int portion;
        private decimal price;


        public BakedFood(string name, int portion,decimal price)
        {
            this.Name = name;
            this.Price = price;
            this.Portion = portion;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }

                this.name = value;
            }
        }

        public int Portion
        {
            get => this.portion;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPortion);
                }

                this.portion = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }

        #region Overrides of Object

        public override string ToString()
        {
            return $"{this.Name}: {this.Portion}g - {this.Price:F2}";

        }

        #endregion

        #endregion
    }
}
