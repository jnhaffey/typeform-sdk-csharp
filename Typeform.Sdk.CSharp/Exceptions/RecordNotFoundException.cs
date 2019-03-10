using System;
using Typeform.Sdk.CSharp.Enums;

namespace Typeform.Sdk.CSharp.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        /// <summary>
        ///     Instantiate an instance of the RecordNotFoundException.
        /// </summary>
        /// <param name="recordType"></param>
        /// <param name="recordId"></param>
        public RecordNotFoundException(RecordType recordType, string recordId)
            : base($"No '{recordType}' record could be found with id '{recordType}'.")
        {
        }
    }
}