using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Box_of_Integer
{
   public class Box<T>
    {
        public Box(int text)
        {
            Text = text;
        }

        public int Text { get; set; }


        public override string ToString()
        {
            return $"{typeof(T)}: {Text}";
        }
    }
}
