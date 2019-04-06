using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Interfaces;
using Typeform.Sdk.CSharp.Models.Themes;
using Typeform.Sdk.CSharp.Validations;

namespace Typeform.Sdk.CSharp.Builders
{
    /// <summary>
    ///     Theme Builder Object.
    /// </summary>
    public class ThemeBuilder : IIsValidatable<ThemeValidation, Theme>, IBuilder<Theme>
    {
        private readonly Theme _themeToCreate;

        private ThemeBuilder(string themeName)
        {
            _themeToCreate = new Theme {Name = themeName};
        }

        #region Implementation of IBuilder<Theme>

        /// <summary>
        ///     Returns the Theme.
        /// </summary>
        /// <returns></returns>
        public Theme Build()
        {
            return _themeToCreate;
        }

        #endregion


        #region Implementation of IIsValidatable<ThemeValidation,Theme>

        /// <inheritdoc />
        /// <summary>
        ///     Validates the model.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="ValidationException"></exception>
        public async Task<bool> IsValid(CancellationToken token = default)
        {
            var validator = new ThemeValidation();
            var validation = await validator.ValidateAsync(_themeToCreate, token);
            if (validation.IsValid) return true;
            throw new ValidationException(validation.Errors);
        }

        #endregion

        /// <summary>
        ///     Create an instance of the Theme Builder object.
        /// </summary>
        /// <param name="themeName">The name of the theme being created.</param>
        /// <returns></returns>
        public static ThemeBuilder Create(string themeName)
        {
            Guard.ForNullOrEmptyOrWhitespace(themeName, nameof(themeName));
            return new ThemeBuilder(themeName);
        }

        /// <summary>
        ///     Set the background URL (Optional).
        /// </summary>
        /// <param name="url">URL to use.</param>
        /// <returns></returns>
        public ThemeBuilder SetBackgroundUrl(string url)
        {
            if (!string.IsNullOrWhiteSpace(url)) Guard.ForInvalidUrl(url, nameof(url));
            AddBackgroundIfNotExist();
            _themeToCreate.Background.Href = url;
            return this;
        }

        /// <summary>
        ///     Set the background layout (Optional | Default: Fullscreen).
        /// </summary>
        /// <param name="layout">Layout to use.</param>
        /// <returns></returns>
        public ThemeBuilder SetBackgroundLayout(LayoutType layout)
        {
            AddBackgroundIfNotExist();
            _themeToCreate.Background.Layout = layout;
            return this;
        }

        /// <summary>
        ///     Set the background brightness (Optional | Default: 0)
        /// </summary>
        /// <param name="brightness">Brightness level to use (Valid Options: -1 to 1</param>
        /// <returns></returns>
        public ThemeBuilder SetBackgroundBrightness(decimal brightness)
        {
            Guard.ForBetweenValues(brightness, -1, 1, nameof(brightness));
            AddBackgroundIfNotExist();
            _themeToCreate.Background.Brightness = brightness;
            return this;
        }

        /// <summary>
        ///     Set all colors.
        /// </summary>
        /// <param name="questionColor">Hex Color Value for Questions.</param>
        /// <param name="answerColor">Hex Color Value for Answers.</param>
        /// <param name="buttonColor">Hex Color Value for Buttons.</param>
        /// <param name="backgroundColor">Hex Color Value for Background.</param>
        /// <returns></returns>
        public ThemeBuilder SetColors(string questionColor, string answerColor, string buttonColor,
            string backgroundColor)
        {
            return SetQuestionColor(questionColor)
                .SetAnswerColor(answerColor)
                .SetButtonColor(buttonColor)
                .SetBackgroundColor(backgroundColor);
        }

        /// <summary>
        ///     Set the questions color (Default: #FFFFFF).
        /// </summary>
        /// <param name="questionColor">Hex Color Value for Questions.</param>
        /// <returns></returns>
        public ThemeBuilder SetQuestionColor(string questionColor)
        {
            Guard.ForNullOrEmptyOrWhitespace(questionColor, nameof(questionColor));
            Guard.ForHexColorValue(questionColor, nameof(questionColor));
            AddColorIfNotExist();
            _themeToCreate.Colors.Question = questionColor;
            return this;
        }

        /// <summary>
        ///     Set the answers color (Default: #4FB0AE).
        /// </summary>
        /// <param name="answerColor">Hex Color Value for Answers.</param>
        /// <returns></returns>
        public ThemeBuilder SetAnswerColor(string answerColor)
        {
            Guard.ForNullOrEmptyOrWhitespace(answerColor, nameof(answerColor));
            Guard.ForHexColorValue(answerColor, nameof(answerColor));
            AddColorIfNotExist();
            _themeToCreate.Colors.Answer = answerColor;
            return this;
        }

        /// <summary>
        ///     Set the button color (Default: #4FB0AE).
        /// </summary>
        /// <param name="buttonColor">Hex Color Value for Buttons.</param>
        /// <returns></returns>
        public ThemeBuilder SetButtonColor(string buttonColor)
        {
            Guard.ForNullOrEmptyOrWhitespace(buttonColor, nameof(buttonColor));
            Guard.ForHexColorValue(buttonColor, nameof(buttonColor));
            AddColorIfNotExist();
            _themeToCreate.Colors.Button = buttonColor;
            return this;
        }

        /// <summary>
        ///     Set the background color (Default: #3D3D3D).
        /// </summary>
        /// <param name="backgroundColor">Hex Color Value for Background.</param>
        /// <returns></returns>
        public ThemeBuilder SetBackgroundColor(string backgroundColor)
        {
            Guard.ForNullOrEmptyOrWhitespace(backgroundColor, nameof(backgroundColor));
            Guard.ForHexColorValue(backgroundColor, nameof(backgroundColor));
            AddColorIfNotExist();
            _themeToCreate.Colors.Background = backgroundColor;
            return this;
        }

        /// <summary>
        ///     Set the font (Default: Source Sans Pro).
        /// </summary>
        /// <param name="fontToUse"></param>
        /// <returns></returns>
        public ThemeBuilder SetFont(FontType fontToUse)
        {
            _themeToCreate.Font = fontToUse;
            return this;
        }

        /// <summary>
        ///     Set if the buttons are transparent (Default: true).
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public ThemeBuilder SetTransparentButtons(bool value = true)
        {
            _themeToCreate.HasTransparentButton = value;
            return this;
        }

        private void AddColorIfNotExist()
        {
            if (_themeToCreate.Colors == null) _themeToCreate.Colors = new Colors();
        }

        private void AddBackgroundIfNotExist()
        {
            if (_themeToCreate.Background == null) _themeToCreate.Background = new BackGround();
        }
    }
}