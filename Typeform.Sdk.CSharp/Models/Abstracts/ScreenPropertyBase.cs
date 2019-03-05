using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Abstracts
{
    public abstract class ScreenPropertyBase
    {
        /// <summary>
        ///     True to display a 'Start' button on the screen. Otherwise, false.
        /// </summary>
        [JsonProperty("show_button")]
        public bool ShowStartButton { get; set; }

        /// <summary>
        ///     Text to display on the 'Start' button on the screen.
        /// </summary>
        [JsonProperty("button_text")]
        public string StartButtonText { get; set; }
    }
}