using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class Action
    {
        /// <summary>
        ///     Behavior the Logic Jump will take.
        /// </summary>
        [JsonProperty("action")]
        public ActionType Name { get; set; }

        /// <summary>
        ///     Properties that further specify how the Logic Jump will behave.
        /// </summary>
        [JsonProperty("details")]
        public ActionDetails Details { get; set; }

        /// <summary>
        ///     Conditions for executing the Logic Jump. Conditions answer the question, "Under what circumstances?" The condition
        ///     object is the IF statement in your Logic Jump.
        /// </summary>
        [JsonProperty("condition")]
        public ActionCondition ActionCondition { get; set; }
    }
}