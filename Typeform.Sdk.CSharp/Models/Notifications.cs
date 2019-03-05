using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Notifications
    {
        [JsonProperty("self")]
        public SelfNotification Self { get; set; }

        [JsonProperty("respondent")]
        public RespondentNotification Respondent { get; set; }
    }
}