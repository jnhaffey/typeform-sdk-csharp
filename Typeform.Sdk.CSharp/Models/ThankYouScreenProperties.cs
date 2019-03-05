using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class ThankYouScreenProperties : ScreenPropertyBase
    {
        [JsonProperty("button_mode")]
        public string SubmitButtonMode { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrlOnSubmit { get; set; }

        [JsonProperty("share_icons")]
        public bool DisplaySharingIcons { get; set; }
    }
}