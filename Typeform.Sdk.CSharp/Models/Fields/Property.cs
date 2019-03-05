using System.Collections.Generic;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;

namespace Typeform.Sdk.CSharp.Models.Fields
{
    public class Property
    {
        public Property()
        {
            Fields = new List<Field>();
            ButtonText = "Continue";
            ScaleShape = ShapeType.Star;
            DateFormat = DateFormatType.DDMMYYYY;
            DateSeparator = DateSeparatorType.Slash;
            Currency = CurrencyType.EUR;
        }

        /// <summary>
        ///     Question or instruction to display for the field.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        ///     Answer choices. Available for dropdown, multiple_choice, and picture_choice types.
        /// </summary>
        [JsonProperty("choices")]
        public List<Choice> Choices { get; set; }

        /// <summary>
        ///     Contains the fields that belong in a question group. Only payment and group blocks are not allowed inside a
        ///     question group. Available for the group type.
        /// </summary>
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        /// <summary>
        ///     True to allow respondents to select more than one answer choice. false to allow respondents to select only one
        ///     answer choice. Available for multiple_choice and picture_choice types.
        /// </summary>
        [JsonProperty("allow_multiple_selection")]
        public bool AllowMultipleSelection { get; set; }

        /// <summary>
        ///     True if answer choices should be presented in a new random order for each respondent. false if answer choices
        ///     should be presented in the same order for each respondent. Available for multiple_choice and picture_choice types.
        /// </summary>
        [JsonProperty("randomize")]
        public bool RandomizeQuestionOrder { get; set; }

        /// <summary>
        ///     True to include an "Other" option so respondents can enter a different answer choice from those listed. false to
        ///     limit answer choices to those listed. Available for multiple_choice and picture_choice types.
        /// </summary>
        [JsonProperty("allow_other_choice")]
        public bool AllowOtherAnswerOption { get; set; }

        /// <summary>
        ///     True to list answer choices vertically. false to list answer choices horizontally. Available for multiple_choice
        ///     types.
        /// </summary>
        [JsonProperty("vertical_alignment")]
        public bool ListAnswersHorizontally { get; set; }

        /// <summary>
        ///     True if you want to use larger-sized images for answer choices. Otherwise, false. Available for picture_choice
        ///     types.
        /// </summary>
        [JsonProperty("supersized")]
        public bool SuperSizedImages { get; set; }

        /// <summary>
        ///     True to show text labels and images as answer choices. false to show only images as answer choices. Available for
        ///     picture_choice types.
        /// </summary>
        [JsonProperty("show_labels")]
        public bool ShowLabels { get; set; }

        /// <summary>
        ///     True if question should list dropdown answer choices in alphabetical order. false if question should list dropdown
        ///     answer choices in the order they're listed in the "choices" array. Available for dropdown types.
        /// </summary>
        [JsonProperty("alphabetical_order")]
        public bool AlphabeticalQuestionOrder { get; set; }

        /// <summary>
        ///     True if you want to display quotation marks around the statement on the form. Otherwise, false. Available for
        ///     statement types.
        /// </summary>
        [JsonProperty("hide_marks")]
        public bool HideQuotationMarks { get; set; }

        /// <summary>
        ///     Text to display in the button associated with the object. Available for group, payment, and statement types.
        /// </summary>
        /// <remarks>Default: Continue</remarks>
        [JsonProperty("button_text")]
        public string ButtonText { get; set; }

        /// <summary>
        ///     Number of steps in the scale's range. Minimum is 5 and maximum is 11. Available for opinion_scale and rating types.
        /// </summary>
        [JsonProperty("steps")]
        public int ScaleNumberRange { get; set; }

        /// <summary>
        ///     Shape to display on the scale's steps. Available for opinion_scale and rating types.
        /// </summary>
        [JsonProperty("shape")]
        public ShapeType ScaleShape { get; set; }

        /// <summary>
        ///     Label to help respondents understand the scale's range. Available for opinion_scale and rating types.
        /// </summary>
        [JsonProperty("labels")]
        public Labels Labels { get; set; }

        /// <summary>
        ///     True if range numbering should start at 1. false if range numbering should start at 0. Available for opinion_scale
        ///     types.
        /// </summary>
        [JsonProperty("start_at_one")]
        public bool ScaleStartAtOne { get; set; }

        /// <summary>
        ///     Format for month, date, and year in answer. Available for date types.
        /// </summary>
        [JsonProperty("structure")]
        public DateFormatType DateFormat { get; set; }

        /// <summary>
        ///     Character to use between month, day, and year in answer. Available for date types.
        /// </summary>
        [JsonProperty("separator")]
        public DateSeparatorType DateSeparator { get; set; }

        /// <summary>
        ///     Currency of the payment. Available for payment types.
        /// </summary>
        [JsonProperty("currency")]
        public CurrencyType Currency { get; set; }

        /// <summary>
        ///     Price of the item. Available for payment fields.
        /// </summary>
        [JsonProperty("price")]
        public Price ItemPrice { get; set; }

        /// <summary>
        ///     True to display a button. Otherwise, false. Available for group and payment types.
        /// </summary>
        [JsonProperty("show_button")]
        public bool ShowButton { get; set; }
    }
}