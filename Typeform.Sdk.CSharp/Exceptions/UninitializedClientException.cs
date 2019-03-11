using System;

namespace Typeform.Sdk.CSharp.Exceptions
{
    public class UninitializedClientException : Exception
    {
        public UninitializedClientException(string clientName)
            : base($"The '{clientName}' does not contain an API Key.")
        {
        }
    }
}