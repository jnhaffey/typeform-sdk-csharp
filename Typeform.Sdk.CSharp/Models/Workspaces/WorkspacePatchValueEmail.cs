using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class WorkspacePatchValueEmail
    {
        /// <summary>
        ///     Email address of member.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}