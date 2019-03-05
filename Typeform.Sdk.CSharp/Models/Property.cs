using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Property
    {
        public Property()
        {
            Fields = new List<Field>();

        }
        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        [JsonProperty("allow_multiple_selection")]
        public bool AllowMultipleSelection { get; set; }

        [JsonProperty("randomize")]
        public bool RandomizeQuestionOrder { get; set; }

        [JsonProperty("allow_other_choice")]
        public bool AllowOtherAnswerOption { get; set; }

        [JsonProperty("vertical_alignment")]
        public bool ListAnswersHorizontally { get; set; }

        [JsonProperty("supersized")]
        public bool SuperSizedImages { get; set; }

        [JsonProperty("show_labels")]
        public bool ShowLabels { get; set; }

        [JsonProperty("alphabetical_order")]
        public bool AlphabeticalQuestionOrder { get; set; }

        [JsonProperty("hide_marks")]
        public bool HideQuotationMarks { get; set; }

        [JsonProperty("button_text")]
        public string ButtonText { get; set; }

        [JsonProperty("steps")]
        public int ScaleNumberRange { get; set; }

        [JsonProperty("shape")]
        public string ScaleShape { get; set; }

        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        [JsonProperty("start_at_one")]
        public bool ScaleStartAtOne { get; set; }

        [JsonProperty("structure")]
        public string DateFormat { get; set; }

        [JsonProperty("separator")]
        public string DateSeparator { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("price")]
        public Price ItemPrice { get; set; }

        [JsonProperty("show_button")]
        public bool ShowButton { get; set; }
    }
}