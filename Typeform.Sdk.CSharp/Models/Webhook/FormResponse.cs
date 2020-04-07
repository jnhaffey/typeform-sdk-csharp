using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Webhook
{
    public class FormResponse
    {
        [JsonProperty("form_id")] public string FormId { get; set; }

        [JsonProperty("token")] public string Token { get; set; }

        [JsonProperty("submitted_at")] public DateTimeOffset SubmittedAt { get; set; }

        [JsonProperty("landed_at")] public DateTimeOffset LandedAt { get; set; }

        [JsonProperty("hidden")] public Dictionary<string, string> HiddenFields { get; set; }

        [JsonProperty("calculated")] public Calculated Calculated { get; set; }

        [JsonProperty("definition")] public FormDefinition FormDefinition { get; set; }

        [JsonProperty("answers")] public List<FormAnswer> FormAnswers { get; set; }
    }
}