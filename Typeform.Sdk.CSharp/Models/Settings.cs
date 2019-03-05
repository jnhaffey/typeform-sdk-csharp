using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class Settings
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }

        [JsonProperty("progress_bar")]
        public string ProgressBar { get; set; }

        [JsonProperty("show_progress_bar")]
        public bool ShowProgressBar { get; set; }

        [JsonProperty("show_typform_branding")]
        public bool ShowTypformBranding { get; set; }

        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        [JsonProperty("redirect_after_submit_url")]
        public string RedirectAfterSubmitUrl { get; set; }

        [JsonProperty("google_analytics")]
        public string GoogleAnalytics { get; set; }

        [JsonProperty("facebook_pixel")]
        public string FacebookPixel { get; set; }

        [JsonProperty("notifications")]
        public Notifications Notifications { get; set; }
    }
}