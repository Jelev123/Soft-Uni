using System;
using System.Linq;
using _03._Telephony.Exceptions;

namespace _03._Telephony
{
    public class Smartphone : IBrowseble ,ICallable
    {
        
        #region Implementation of IBrowseble

        public string Browse(string url)
        {
            
            if (url.Any(c=>char.IsDigit(c)))
            {
                throw new InvalidUrlExceptions();
            }

            return $"Browsing: {url}!";
        }

        #endregion

        #region Implementation of ICallable

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(c=>char.IsDigit(c)))
            {
                throw new InvalidNumberException();


            }

            return $"Calling... {phoneNumber}";
        }

        #endregion
    }
}