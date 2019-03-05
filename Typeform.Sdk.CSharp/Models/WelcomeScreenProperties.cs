using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models
{
    public class WelcomeScreenProperties : ScreenPropertyBase
    {
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}