using System;
using System.Runtime.Serialization;

namespace CalculatorSelenium.Specs.Exceptions
{
    public class InteractionException : ApplicationException
    {
        public InteractionException()
        {
        }

        public InteractionException(string message) : base(message)
        {
        }

        public InteractionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InteractionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}