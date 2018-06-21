using System;
using System.Collections.Generic;
using System.Text;

namespace Risk.Model.Exceptions
{
    public class BusinessModelException : Exception
    {
        public BusinessModelException() : base() { }
        public BusinessModelException(string message) : base(message) { }
        public BusinessModelException(string message, Exception inner) : base(message, inner) { }
        protected BusinessModelException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
