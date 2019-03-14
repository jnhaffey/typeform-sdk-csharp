using Newtonsoft.Json;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Shared;

namespace Typeform.Sdk.CSharp.Models.Themes
{
    public class Theme
    {
        public Theme()
        {
            Font = FontType.SourceSansPro;
        }

        /// <summary>
        ///     Url to Self.
        /// </summary>
        [JsonIgnore]
        public HrefObject Self { get; set; }

        /// <summary>
        ///     Settings for the background.
        /// </summary>
        [JsonProperty("background")]
        public BackGround Background { get; set; }

        /// <summary>
        ///     Colors the theme will apply to answers, background, buttons, and questions.
        /// </summary>
        [JsonProperty("colors")]
        public Colors Colors { get; set; }

        /// <summary>
        ///     Font for the theme. Default: Source Sans Pro.
        /// </summary>
        [JsonProperty("font")]
        public FontType Font { get; set; }

        /// <summary>
        ///     True if buttons should be transparent. Otherwise, false.
        /// </summary>
        [JsonProperty("has_transparent_button")]
        public bool HasTransparentButton { get; set; }

        /// <summary>
        ///     Unique ID of the theme.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Name of the theme.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     Specifies whether the theme is public (one of Typeform's built-in themes that are available in all accounts) or
        ///     private (a theme you created). You can only change private themes. You can't change Typeform's public themes.
        ///     Default:private.
        /// </summary>
        [JsonProperty("visibility")]
        public string Visibility { get; set; }
    }
}