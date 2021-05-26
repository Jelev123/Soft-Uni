using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Swap_Method_Integers
{
    class Box<T>
    {
        public Box(List<T> names)
        {
            Names = names;
        }

        public Box()
        {
            Names = new List<T>();
        }

        public List<T> Names { get; set; }


        public void Add(T item)
        {
            Names.Add(item);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var name in Names)
            {
                sb.AppendLine($"{typeof(T)}: {name}");
            }

            return sb.ToString();
        }
    }
}
