using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericCountMethodStrings
{
  public  class Box<T>
    {
        public Box(List<T> text)
        {
            Text = text;
        }

        public Box()
        {
            Text = new List<T>();
        }
        public List<T> Text { get; set; }

        public void Add(T item)
        {
            Text.Add(item);
        }
    }
}
