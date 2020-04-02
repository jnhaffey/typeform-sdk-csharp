using System;

namespace Typeform.Sdk.CSharp.Exceptions
{
    public class InvalidEmailException : Exception
    {
        public InvalidEmailException(string message)
            : base(message)
        {
        }
    }
}