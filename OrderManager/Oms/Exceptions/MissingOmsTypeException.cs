using System;

namespace OrderManager.Oms.Exceptions
{
    public class MissingOmsTypeException : Exception
    {
        public MissingOmsTypeException(string message) : base(message)
        {
        }
    }
}
