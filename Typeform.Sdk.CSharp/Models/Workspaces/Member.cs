using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;

namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class Member
    {
        /// <summary>
        ///     Name of member.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; private set; }

        /// <summary>
        ///     Email of member.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; private set; }

        /// <summary>
        ///     Role of member.
        /// </summary>
        [JsonProperty("role")]
        public MemberRoleType Role { get; private set; }
    }
}