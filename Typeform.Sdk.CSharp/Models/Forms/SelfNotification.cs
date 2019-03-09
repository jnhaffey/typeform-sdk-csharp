using System.Collections.Generic;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Abstracts;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class SelfNotification : NotificationBase
    {
        public SelfNotification()
        {
            Recipients = new List<string>();
        }

        /// <summary>
        /// </summary>
        [JsonProperty("recipients")]
        public List<string> Recipients { get; set; }

        /// <summary>
        ///     Email address to use for notification Reply-To. Must be a piped value based on respondent's answer to a field:
        ///     {{field:ref}} or {{hidden:ref}}.
        /// </summary>
        [JsonProperty("reply_to")]
        public string ReplyTo { get; set; }
    }
}