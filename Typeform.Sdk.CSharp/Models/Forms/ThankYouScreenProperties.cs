using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Abstracts;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class ThankYouScreenProperties : ScreenPropertyBase
    {
        /// <summary>
        ///     Specify whether the form should reload or redirect to another URL when respondents click the 'Submit' button. PRO+
        ///     feature.
        /// </summary>
        [JsonProperty("button_mode")]
        public ButtonModeType SubmitButtonMode { get; set; }

        /// <summary>
        ///     URL where the typeform should redirect after submission, if you specified "redirect" for button_mode.
        /// </summary>
        [JsonProperty("redirect_url")]
        public string RedirectUrlOnSubmit { get; set; }

        /// <summary>
        ///     True to display social media sharing icons on the thank you screen so respondents can post your typeform's link on
        ///     Facebook, Twitter, LinkedIn, and Google+. Otherwise, false.
        /// </summary>
        [JsonProperty("share_icons")]
        public bool DisplaySharingIcons { get; set; }
    }
}