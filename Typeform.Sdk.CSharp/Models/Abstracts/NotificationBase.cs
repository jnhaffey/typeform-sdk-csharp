using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Abstracts
{
    public abstract class NotificationBase
    {
        protected NotificationBase()
        {
            Enabled = false;
        }

        /// <summary>
        ///     True to send notifications. false to disable notifications.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        /// <summary>
        ///     Subject to use for the notification email. Can combine text and piped value from one or more fields.
        /// </summary>
        /// <example>
        ///     Available piped values are {{form:title}}, {{account:email}}, {{account:name}}, {{link:report}}, and standard
        ///     piping for fields {{field:ref}} and hidden fields {{hidden:ref}}.
        /// </example>
        [JsonProperty("subject")]
        public string Subject { get; set; }

        /// <summary>
        ///     Message to include in the body of the notification email. Can combine text and piped value from one or more fields.
        /// </summary>
        /// <example>
        ///     Available piped values are {{form:title}}, {{account:email}}, {{account:name}}, {{link:report}},
        ///     {{form:all_answers}}, and standard piping for fields {{field:ref}} and hidden fields {{hidden:ref}}.
        ///     You can format messages with bold (*bold*) and italic (_italic_) text. HTML tags are forbidden.
        /// </example>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}