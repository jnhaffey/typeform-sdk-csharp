using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class RespondentNotification : NotificationBase
    {
        public RespondentNotification()
        {
            ReplyTo = new List<string>();
        }

        [JsonProperty("recipient")]
        public string Recipient { get; set; }

        [JsonProperty("reply_to")]
        public List<string> ReplyTo { get; set; }
    }
}