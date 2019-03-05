using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class Attachment
    {
        /// <summary>
        ///     Type of attachment.
        /// </summary>
        [JsonProperty("type")]
        public AttachmentType Type { get; set; }

        /// <summary>
        ///     URL for the image or video you want to display. Images must already exist in your account
        ///     Use the image's Typeform URL.
        /// </summary>
        [JsonProperty("href")]
        public string Url { get; set; }
    }
}