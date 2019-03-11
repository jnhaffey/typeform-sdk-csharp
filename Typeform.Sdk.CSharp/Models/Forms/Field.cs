using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class Field
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Readable name you can use to reference the field.
        /// </summary>
        [JsonProperty("ref")]
        public string Ref { get; set; }

        /// <summary>
        ///     Unique name you assign to the field on this form.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        /// <summary>
        ///     The type of field.
        /// </summary>
        [JsonProperty("type")]
        public FieldType Type { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("properties")]
        public Property Properties { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("validations")]
        public Validations Validations { get; set; }

        /// <summary>
        ///     Allows you to display images and videos.
        /// </summary>
        [JsonProperty("attachment")]
        public AttachmentWithScale AttachmentWithScale { get; set; }
    }
}