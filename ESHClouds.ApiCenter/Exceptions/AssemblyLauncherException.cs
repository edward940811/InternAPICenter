using System;
using System.Collections.Generic;
using System.Text;

namespace Risk.Model.Exceptions
{
    public class AssemblyLauncherException : Exception
    {
        public AssemblyLauncherException() : base("Assembly Launcher Error") { }
        public AssemblyLauncherException(string message) : base(message) { }
        public AssemblyLauncherException(string message, Exception inner) : base(message, inner) { }
        protected AssemblyLauncherException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
