using System;

namespace TransactionExporter.Oms.Exceptions
{
    public class MissingOmsTypeException : Exception
    {
        public MissingOmsTypeException(string message) : base(message)
        {
        }
    }
}
