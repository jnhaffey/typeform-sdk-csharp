using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class Patch<TValue>
    {
        public OperationType Operation { get; set; }
        public string Path { get; set; }
        public TValue Value { get; set; }
    }
}