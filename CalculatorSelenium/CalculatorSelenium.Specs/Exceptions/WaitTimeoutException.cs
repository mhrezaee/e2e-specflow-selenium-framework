using System;
using System.Runtime.Serialization;

namespace CalculatorSelenium.Specs.Exceptions
{
    public class WaitTimeoutException : ApplicationException
    {
        public WaitTimeoutException()
        {
        }

        public WaitTimeoutException(string message) : base(message)
        {
        }

        public WaitTimeoutException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WaitTimeoutException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}