using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Typeform.Sdk.CSharp.Enums;

namespace Typeform.Sdk.CSharp.Models.Webhook
{
    public class FormAnswer
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("type")]
        public FormAnswerType Type { get; set; }

        [JsonProperty("field")] public Field Field { get; set; }

        [JsonProperty("text")] public string Text { get; set; }

        [JsonProperty("choice")] public Choice Choice { get; set; }

        [JsonProperty("choices")]public Choices Choices { get; set; }

        [JsonProperty("email")] public string Email { get; set; }

        [JsonProperty("phone_number")] public string PhoneNumber { get; set; }

        [JsonProperty("date")] public DateTime? Date { get; set; }

        [JsonProperty("boolean")] public bool Boolean { get; set; }

        [JsonProperty("url")] public string Url { get; set; }
        [JsonProperty("number")] public int Number { get; set; }
        [JsonProperty("file_url")] public string FileUrl { get; set; }
        [JsonProperty("payment")] public Payment Payment { get; set; }
    }
}