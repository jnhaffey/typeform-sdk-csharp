using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class Screen<TProperties>
    {
        /// <summary>
        ///     Readable name you can use to reference the welcome screen.
        /// </summary>
        [JsonProperty("ref")]
        public string Ref { get; set; }

        /// <summary>
        ///     Title for the welcome screen.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("properties")]
        public TProperties Properties { get; set; }

        /// <summary>
        ///     Allows you to display images and videos.
        /// </summary>
        [JsonProperty("attachment")]
        public AttachmentWithScale AttachmentWithScale { get; set; }
    }
}