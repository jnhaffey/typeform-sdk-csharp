using System.Collections.Generic;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class Logic
    {
        public Logic()
        {
            Actions = new List<Action>();
        }

        /// <summary>
        /// Specifies whether the Logic Jump is based on a question field or Hidden Field.
        /// </summary>
        [JsonProperty("type")]
        public LogicActionType Type { get; set; }

        /// <summary>
        /// Reference to the field that triggers the the Logic Jump.
        /// </summary>
        [JsonProperty("ref")]
        public string Ref { get; set; }

        /// <summary>
        /// Array of objects that define the Logic Jump's behavior.
        /// </summary>
        [JsonProperty("actions")]
        public List<Action> Actions { get; set; }
    }
}