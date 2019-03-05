using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class AttachmentWithScale : Attachment
    {
        /// <summary>
        ///     Optional parameter for responsively scaling videos. Available only for "video" type. Default value is 0.6
        /// </summary>
        [JsonProperty("scale")]
        public decimal VideoScaleSize { get; set; }
    }
}