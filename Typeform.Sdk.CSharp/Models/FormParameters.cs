using System.Collections.Generic;
using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class FormParameters
    {
        public FormParameters()
        {
            Fields = new List<Field>();
            Hidden = new List<string>();
            WelcomeScreens = new List<Screen<WelcomeScreenProperties>>();
            ThankYouScreens = new List<Screen<ThankYouScreenProperties>>();
            Logics = new List<Logic>();
        }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("fields")]
        public List<Field> Fields { get; set; }

        [JsonProperty("hidden")]
        public List<string> Hidden { get; set; }

        [JsonProperty("welcome_screens")]
        public List<Screen<WelcomeScreenProperties>> WelcomeScreens { get; set; }

        [JsonProperty("thankyou_screens")]
        public List<Screen<ThankYouScreenProperties>> ThankYouScreens { get; set; }

        [JsonProperty("logic")]
        public List<Logic> Logics { get; set; }

        [JsonProperty("theme")]
        public HrefObject Theme { get; set; }

        [JsonProperty("workspace")]
        public HrefObject Workspace { get; set; }

        [JsonProperty("_link")]
        public DisplayObject DisplayObject { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }
    }
}