using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Logics
{
    public class ActionDetails
    {
        /// <summary>
        ///     Specifies where the Logic Jump leads---to another field ("field"), a Hidden Field ("hidden"), or thank you screen
        ///     ("thankyou").
        /// </summary>
        [JsonProperty("to")]
        public StringTypeValuePair ActionTo { get; set; }

        /// <summary>
        ///     Keeps a running total for the score or price variable.
        /// </summary>
        [JsonProperty("target")]
        public StringTypeValuePair ActionTarget { get; set; }

        /// <summary>
        ///     Specifies the numeric value to use in the calculation for the score or price variable.
        /// </summary>
        [JsonProperty("value")]
        public StringTypeValuePair ActionValue { get; set; }
    }
}