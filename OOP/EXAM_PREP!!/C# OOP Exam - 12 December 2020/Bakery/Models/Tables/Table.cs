using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
        }

        #region Implementation of ITable

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => this.capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get => this.numberOfPeople;

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }
        public decimal PricePerPerson { get; private set; }
        public bool IsReserved { get; private set; }
        public decimal Price => PricePerPerson * NumberOfPeople;
        public void Reserve(int numberOfPeople)
        {
            NumberOfPeople = numberOfPeople;
            IsReserved = true;
        }

        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }


        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }

        public decimal GetBill()
        {
            return foodOrders.Sum(x => x.Price) + drinkOrders.Sum(x => x.Price) + Price;
        }

        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            this.numberOfPeople = 0;

            this.IsReserved = false;
        }

        public string GetFreeTableInfo()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {GetType().Name}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Price per Person: {PricePerPerson:F2}");

            return sb.ToString().TrimEnd();
        }

        #endregion

        #region Implementation of IEnumerable

        

        #endregion

        #region Implementation of IEnumerable

       

        #endregion

        #region Implementation of IEnumerable

        public abstract IEnumerator GetEnumerator();

        #endregion
    }
}
