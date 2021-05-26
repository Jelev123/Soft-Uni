using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace GenericBoxOfString
{
   public class Box<T>
    {
        public Box(string text)
        {
            Text = text;
        }

        public string Text { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return $"{Text.GetType()}: {Text}";
        }

        #endregion
    }
   
}
