using System;
using System.Collections.Generic;
using System.Text;

namespace Generic_Box_of_Integer
{
    public class Box<T>
    {
        public Box(int numbers)
        {
            Numbers = numbers;
        }

        public int Numbers { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return $"{Numbers.GetType()}: {Numbers}";
        }

        #endregion
    }
}
