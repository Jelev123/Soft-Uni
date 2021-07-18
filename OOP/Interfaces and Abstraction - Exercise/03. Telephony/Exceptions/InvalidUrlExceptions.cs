using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace _03._Telephony.Exceptions
{
   public class InvalidUrlExceptions : Exception
   {
       private const string URL_EXC_MSG = "Invalid URL!";

       public InvalidUrlExceptions()
       :base(URL_EXC_MSG)
        {

        }
    }
}
