using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Fields
{
    public class Choice
    {
        /// <summary>
        ///     Readable name you can use to reference the answer choice. Available for multiple_choice and picture_choice types.
        ///     Not available for dropdown types.
        /// </summary>
        [JsonProperty("ref")]
        public string Ref { get; set; }

        /// <summary>
        ///     Text for the answer choice.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        ///     Identifies the image to use for the answer choice. Available only for picture_choice types.
        /// </summary>
        [JsonProperty("attachment")]
        public Attachment Attachment { get; set; }
    }
}