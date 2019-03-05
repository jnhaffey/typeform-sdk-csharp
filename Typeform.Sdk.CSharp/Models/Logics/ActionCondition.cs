using System.Collections.Generic;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Logics
{
    public class ActionCondition
    {
        public ActionCondition()
        {
            Variables = new List<StringTypeValuePair>();
        }

        /// <summary>
        ///     Operator for the condition.
        /// </summary>
        [JsonProperty("op")]
        public ConditionOperationType Operation { get; set; }

        /// <summary>
        ///     Object that defines the field type and value to evaluate with the operator.
        /// </summary>
        [JsonProperty("vars")]
        public List<StringTypeValuePair> Variables { get; set; }
    }
}