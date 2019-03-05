using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class SelfNotification : NotificationBase
    {
        public SelfNotification()
        {
            Recipients = new List<string>();
        }

        [JsonProperty("recipients")]
        public List<string> Recipients { get; set; }

        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }
    }
}