using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Themes
{
    public class Colors
    {
        public Colors()
        {
            Answer = "#4FB0AE";
            Background = "#FFFFFF";
            Button = "#4FB0AE";
            Question = "#3D3D3D";
        }

        /// <summary>
        ///     Color the theme will apply to answers. Hexadecimal value.
        /// </summary>
        [JsonProperty("answer")]
        public string Answer { get; set; }

        /// <summary>
        ///     Color the theme will apply to background. Hexadecimal value.
        /// </summary>
        [JsonProperty("background")]
        public string Background { get; set; }

        /// <summary>
        ///     Color the theme will apply to buttons. Hexadecimal value.
        /// </summary>
        [JsonProperty("button")]
        public string Button { get; set; }

        /// <summary>
        ///     Color the theme will apply to questions. Hexadecimal value.
        /// </summary>
        [JsonProperty("question")]
        public string Question { get; set; }
    }
}