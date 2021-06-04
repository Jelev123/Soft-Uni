using System;
using System.Text;

namespace CarSalesman
{
    public class Car
    {
        public Car(string model,Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
        :this(model,engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine,string color)
        :this(model,engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
        :this(model,engine)
        {
            this.Weight = weight;
            this.Color = color;
        }
        
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            var sb = new StringBuilder();
            var weight = this.Weight.HasValue ? this.Weight.ToString() : "n/a";
            var color = String.IsNullOrEmpty(this.Color) ? "n/a" : this.Color;

            sb.AppendLine($"{this.Model}:")
                .AppendLine($" {this.Engine}")
                .AppendLine($"  Weight: {weight}")
                .AppendLine($"  Color: {color}");

            return sb.ToString().TrimEnd();
        }

        #endregion

    }
}