using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Settings
{
    public class Notifications
    {
        /// <summary>
        ///     Settings for notifications sent when respondents complete and submit the typeform.
        /// </summary>
        [JsonProperty("self")]
        public SelfNotification Self { get; set; }

        /// <summary>
        ///     Settings for notifications sent to respondents immediately after submitting the typeform.
        /// </summary>
        [JsonProperty("respondent")]
        public RespondentNotification Respondent { get; set; }
    }
}