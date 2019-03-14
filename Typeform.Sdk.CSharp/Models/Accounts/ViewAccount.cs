using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Accounts
{
    public class ViewAccount
    {
        /// <summary>
        ///     Alias for the account.
        /// </summary>
        [JsonProperty("alias")]
        public string Alias { get; set; }

        /// <summary>
        ///     Email address associated to the account.
        /// </summary>
        [JsonProperty("email")]
        public string EmailAddress { get; set; }

        /// <summary>
        ///     Language set for the account.
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }
    }
}