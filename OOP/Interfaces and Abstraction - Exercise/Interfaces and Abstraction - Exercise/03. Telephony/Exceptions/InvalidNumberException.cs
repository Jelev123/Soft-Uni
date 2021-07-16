using System;
using System.Collections.Generic;
using System.Text;

namespace _03._Telephony.Exceptions
{
    class InvalidNumberException : Exception
    {
        private const string NUM_EXC_MSG = "Invalid number!";

        public InvalidNumberException()
            : base(NUM_EXC_MSG)
        {
            
        }
    }
}
