using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public abstract class ScreenPropertyBase
    {
        [JsonProperty("show_button")]
        public bool ShowStartButton { get; set; }

        [JsonProperty("button_text")]
        public string StartButtonText { get; set; }
    }
}