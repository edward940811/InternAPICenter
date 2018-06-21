using System;
using System.Collections.Generic;
using System.Text;

namespace Risk.Model.Exceptions
{
    public class ValidationModelException : Exception
    {
        public ValidationModelException() : base("Invalid Model") { }
        public ValidationModelException(string message) : base(message) { }
        public ValidationModelException(string message, Exception inner) : base(message, inner) { }
        protected ValidationModelException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
