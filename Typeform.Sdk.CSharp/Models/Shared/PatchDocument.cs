using Microsoft.AspNetCore.JsonPatch.Operations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class PatchDocument<TValue>
    {
        private PatchDocument()
        {
        }

        /// <summary>
        ///     Operation to execute.
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public OperationType Operation { get; private set; }

        /// <summary>
        ///     Target location.
        /// </summary>
        public string Path { get; private set; }

        /// <summary>
        ///     Value.
        /// </summary>
        public TValue Value { get; private set; }

        /// <summary>
        ///     Create an instance of a ViewWorkspace Patch.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static PatchDocument<TValue> Create(OperationType operation, string path)
        {
            Guard.ForNullOrEmptyOrWhitespace(path, nameof(path));


            return new PatchDocument<TValue>
            {
                Operation = operation,
                Path = path
            };
        }

        /// <summary>
        ///     Change the value of the ViewWorkspace Patch.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public PatchDocument<TValue> ChangeValue(TValue value)
        {
            Value = value;
            return this;
        }
    }
}