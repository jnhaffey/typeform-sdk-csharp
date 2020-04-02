using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Workspaces
{
    public class Forms : HrefObject
    {
        /// <summary>
        ///     Number of typeforms in the workspace.
        /// </summary>
        [JsonProperty("count")]
        public int Count { get; private set; }
    }
}