using System;

namespace Typeform.Sdk.CSharp.Exceptions
{
    public class InvalidHexColorException : Exception
    {
        public InvalidHexColorException()
        {
        }

        public InvalidHexColorException(string message)
            : base(message)
        {
        }
    }
}