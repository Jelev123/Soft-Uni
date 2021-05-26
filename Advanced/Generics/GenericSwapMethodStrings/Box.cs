using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace GenericSwapMethodStrings
{
   public class Box<T>
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

        #region Overrides of Object

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var name in Names)
            {
                sb.AppendLine($"{typeof(T)}: {name}");
            }

            return sb.ToString();
        }

        #endregion
    }
}
