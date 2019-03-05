using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Fields
{
    public class Validations
    {
        /// <summary>
        ///     true if respondents must provide an answer. Otherwise, false. Available for date, dropdown, email, file_upload,
        ///     legal, long_text, multiple_choice, number, opinion_scale, payment, picture_choice, rating, short_text, website, and
        ///     yes_no types.
        /// </summary>
        [JsonProperty("required")]
        public bool Required { get; set; }

        /// <summary>
        ///     Maximum number of characters allowed in the answer. Available for long_text, number, and short_text types.
        /// </summary>
        [JsonProperty("max_length")]
        public int MaxLength { get; set; }

        /// <summary>
        ///     Maximum value allowed in the answer. Available for number types.
        /// </summary>
        [JsonProperty("min_value")]
        public int MinValue { get; set; }

        /// <summary>
        ///     Maximum value allowed in the answer. Available for number types.
        /// </summary>
        [JsonProperty("max_value")]
        public int MaxValue { get; set; }
    }
}