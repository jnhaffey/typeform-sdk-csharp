using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class AttachmentWithScale : Attachment
    {
        [JsonProperty("scale")]
        public int VideoScaleSize { get; set; }
    }
}