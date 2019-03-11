using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Models.Abstracts;

namespace Typeform.Sdk.CSharp.Models.Forms
{
    public class WelcomeScreenProperties : ScreenPropertyBase
    {
        /// <summary>
        ///     Description of the welcome screen.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}