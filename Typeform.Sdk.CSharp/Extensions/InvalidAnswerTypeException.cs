using System;

namespace Typeform.Sdk.CSharp.Extensions
{
    public class InvalidAnswerTypeException : Exception
    {
        public InvalidAnswerTypeException(string message)
            : base(message)
        {
        }
    }
}