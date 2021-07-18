using System.Linq;
using _03._Telephony.Exceptions;

namespace _03._Telephony
{
    public class StationaryPhone : ICallable
    {
        #region Implementation of ICallable

        public string Call(string phoneNumber)
        {
            if (!phoneNumber.All(n=>char.IsDigit(n)))
            {
                throw new InvalidNumberException();
            }
            return $"Dialing... {phoneNumber}";
        }

        #endregion
    }
}