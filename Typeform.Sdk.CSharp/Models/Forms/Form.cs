using System.Collections.Generic;
using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class Form
    {
        public Form()
        {
            Fields = new List<Field>();
            Logic = new List<Logic>();
            Hidden = new List<string>();
            WelcomeScreens = new List<Screen<WelcomeScreenProperties>>();
            ThankYouScreens = new List<Screen<ThankYouScreenProperties>>();
        }

        /// <summary>
        ///     Title to use for the typeform.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        /// <summary>
        ///     URL of the theme to use for the typeform. If you don't specify a URL for the theme, Typeform applies a new copy of
        ///     the default theme to the form.
        /// </summary>
        [JsonProperty("theme")]
        public string Theme { get; set; }

        /// <summary>
        ///     URL of the workspace to use for the typeform. If you don't specify a URL for the workspace, Typeform saves the form
        ///     in the default workspace.
        /// </summary>
        [JsonProperty("workspace")]
        public HrefObject Workspace { get; set; }

        /// <summary>
        ///     Array of Hidden Fields to use in the form.
        /// </summary>
        [JsonProperty("hidden")]
        public List<string> Hidden { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("variables")]
        public Variables Variables { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("welcome_screens")]
        public List<Screen<WelcomeScreenProperties>> WelcomeScreens { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("thankyou_screens")]
        public List<Screen<ThankYouScreenProperties>> ThankYouScreens { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty("logic")]
        public List<Logic> Logic { get; set; }
    }
}