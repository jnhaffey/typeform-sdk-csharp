using System.Collections.Generic;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Abstracts;

namespace Typeform.Sdk.CSharp.Models.Settings
{
    public class RespondentNotification : NotificationBase
    {
        public RespondentNotification()
        {
            ReplyTo = new List<string>();
        }

        /// <summary>
        ///     Email where respondent notification will be sent. Must be a piped value based on respondent's answer to a field:
        ///     {{field:ref}} or {{hidden:ref}}.
        /// </summary>
        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("reply_to")]
        public List<string> ReplyTo { get; set; }
    }
}