using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodStrings
{
  public  class Box<T>
    {
        public Box(List<T> str)
        {
            this.str = str;
        }

        public Box()
        {
            str = new List<T>();
        }

        public List<T> str { get; set; }
    }
}
