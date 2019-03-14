using System.Collections.Generic;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class ViewWorkspace
    {
        /// <summary>
        ///     Unique identifier for the workspace.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Name of the workspace.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     If the default workspace, true. Otherwise, false.
        /// </summary>
        [JsonProperty("default")]
        public bool Default { get; set; }

        /// <summary>
        ///     If the workspace is shared with a team, true. Otherwise, false.
        /// </summary>
        [JsonProperty("shared")]
        public bool Shared { get; set; }

        /// <summary>
        ///     Link and count of typeforms in the workspace.
        /// </summary>
        [JsonProperty("forms")]
        public WorkspaceForms Forms { get; set; }

        /// <summary>
        ///     Link to the workspace.
        /// </summary>
        [JsonProperty("self")]
        public HrefObject SelfLink { get; set; }

        /// <summary>
        ///     List of members.
        /// </summary>
        [JsonProperty("members")]
        public List<WorkspaceMember> Members { get; set; }
    }
}