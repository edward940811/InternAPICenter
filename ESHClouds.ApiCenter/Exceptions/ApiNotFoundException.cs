using System;
using System.Collections.Generic;
using System.Text;

namespace Risk.Model.Exceptions
{

    [Serializable]
    public class ApiNotFoundException : Exception
    {
        public ApiNotFoundException() : base("ApiNotFound") { } 
        public ApiNotFoundException(string message) : base(message) { }
        public ApiNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected ApiNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
