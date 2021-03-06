﻿using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Abstracts;

namespace Typeform.Sdk.CSharp.Models.Shared
{
    public class NumberTypeValuePair : TypeValuePairBase
    {
        /// <summary>
        /// </summary>
        [JsonProperty("value")]
        public decimal Value { get; set; }
    }
}