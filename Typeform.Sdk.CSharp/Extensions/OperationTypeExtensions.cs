using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Typeform.Sdk.CSharp.Extensions
{
    public static class OperationTypeExtensions
    {
        /// <summary>
        ///     Returns a lower string version of the JSON Patch Operation.
        /// </summary>
        /// <param name="operationType"></param>
        /// <returns></returns>
        public static string ToLowerString(this OperationType operationType)
        {
            return operationType.ToString().ToLowerInvariant();
        }
    }
}