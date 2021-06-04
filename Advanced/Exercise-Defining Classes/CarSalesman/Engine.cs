using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
           this.Model = model;
            this.Power = power;
           
        }

        public Engine(string model,int power,int displacement) : this(model,power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model,int power,string efficiency):this(model,power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model,int power,string efficiency,int displacement)
        :this(model,power)
        {
            this.Efficiency = efficiency;
            this.Displacement = displacement;
        }

        
        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string Efficiency { get; set; }


        #region Overrides of Object

        public override string ToString()
        {
            var sb = new StringBuilder();
            var displacementValue = this.Displacement.HasValue ? this.Displacement.ToString() : "n/a";
            var efficiancyStr = String.IsNullOrEmpty(this.Efficiency) ? "n/a" : this.Efficiency;

            sb.AppendLine($" {this.Model}:")
                .AppendLine($"    Power: {this.Power}")
                .AppendLine($"    Displacement: {displacementValue}")
                .AppendLine($"    Efficiency: {efficiancyStr}");

            return sb.ToString().TrimEnd();
        }

        #endregion
    }
}