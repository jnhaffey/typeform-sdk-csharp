using Newtonsoft.Json;

namespace Typeform.Sdk.CSharp.Models.Themes
{
    public class BackGround
    {
        public BackGround()
        {
            Layout = LayoutType.Fullscreen;
        }

        /// <summary>
        ///     Background image URL.
        /// </summary>
        [JsonProperty("href")]
        public string Href { get; set; }

        /// <summary>
        ///     Layout for the background. Default: Fullscreen.
        /// </summary>
        [JsonProperty("layout")]
        public LayoutType Layout { get; set; }

        /// <summary>
        ///     Brightness for the background. -1 is least bright (minimum) and 1 is most bright (maximum).
        /// </summary>
        [JsonProperty("brightness")]
        public int Brightness { get; set; }
    }
}