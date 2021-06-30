﻿using System.Collections.Generic;

namespace CustomStack
{
    public class StackOfStrings_: Stack<string>
    {
        public bool IsEmpty()
        {
            return this.Count == 0;
        }

        public void AddRange(Stack<string> range)  
        {
            while (range.Count > 0)
            {
                this.Push(range.Pop());
            }
        }
    }
}