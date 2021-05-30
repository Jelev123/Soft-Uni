using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Swap_Method_Integers
{
  public  class Box<T>
    {
        public Box(List<T> names)
        {
            Names = names;
        }

        public Box()
        {
            Names = new List<T>();
        }

        public void Add(T item)
        {
            Names.Add(item);
        }

        public List<T> Names { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var item in Names)
            {
                sb.AppendLine($"{typeof(T)}: {item}");
            }

            return sb.ToString();
        }

        #endregion
    }
}
