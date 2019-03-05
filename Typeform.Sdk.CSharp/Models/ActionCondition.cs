using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class ActionCondition
    {
        public ActionCondition()
        {
            Variables = new List<TypeValuePair>();
        }

        [JsonProperty("op")]
        public string Operation { get; set; }

        [JsonProperty("vars")]
        public List<TypeValuePair> Variables { get; set; }
    }
}