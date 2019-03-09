using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class Settings
    {
        public Settings()
        {
            IsPublic = false;
            ProgressBar = ProgressBarType.Proportion;
            ShowProgressBar = false;
            ShowTypformBranding = false;
        }

        /// <summary>
        /// </summary>
        [JsonProperty("language")]
        public LanguageType Language { get; set; }

        /// <summary>
        ///     True if your form is public. Otherwise, false (your form is private).
        /// </summary>
        [JsonProperty("is_public")]
        public bool IsPublic { get; set; }

        /// <summary>
        ///     Basis for the progress bar displayed on the screen. Choose "proportion" to show the number of questions answered so
        ///     far. Choose "percentage" to show the percentage of questions answered so far.
        /// </summary>
        [JsonProperty("progress_bar")]
        public ProgressBarType ProgressBar { get; set; }

        /// <summary>
        ///     True to display progress bar on the typeform. Otherwise, false.
        /// </summary>
        [JsonProperty("show_progress_bar")]
        public bool ShowProgressBar { get; set; }

        /// <summary>
        ///     True to display Typeform brand on the typeform. false to hide Typeform branding on the typeform. Hiding Typeform
        ///     branding is available for PRO+ accounts.
        /// </summary>
        [JsonProperty("show_typform_branding")]
        public bool ShowTypformBranding { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("meta")]
        public Meta Meta { get; set; }

        /// <summary>
        ///     URL where the typeform should redirect upon submission.
        /// </summary>
        [JsonProperty("redirect_after_submit_url")]
        public string RedirectAfterSubmitUrl { get; set; }

        /// <summary>
        ///     Google Analytics tracking ID to use for the form.
        /// </summary>
        [JsonProperty("google_analytics")]
        public string GoogleAnalytics { get; set; }

        /// <summary>
        ///     Facebook Pixel tracking ID to use for the form.
        /// </summary>
        [JsonProperty("facebook_pixel")]
        public string FacebookPixel { get; set; }

        /// <summary>
        ///     Google Tag Manager ID to use for the form.
        /// </summary>
        [JsonProperty("google_tag_manager")]
        public string GoogleTagManager { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("notifications")]
        public Notifications Notifications { get; set; }
    }
}