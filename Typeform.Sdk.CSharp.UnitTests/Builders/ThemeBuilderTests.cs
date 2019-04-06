using System;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Typeform.Sdk.CSharp.Builders;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Themes;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Builders
{
    [ExcludeFromCodeCoverage]
    public class ThemeBuilderTests
    {
        [Fact]
        public void Create_Default()
        {
            // ARRANGE
            // ACT
            Func<ThemeBuilder> functionToTest = () => ThemeBuilder.Create(TestData.Themes.Name);

            // ASSERT
            functionToTest.Should().NotThrow();
            functionToTest.Invoke().Build().Name.Should().Be(TestData.Themes.Name);
        }

        [Fact]
        public void Create_Empty_String()
        {
            // ARRANGE
            // ACT
            Func<ThemeBuilder> functionToTest = () => ThemeBuilder.Create(string.Empty);

            // ASSERT
            functionToTest.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("themeName cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void SetAnswerColor_Empty_String()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetAnswerColor(string.Empty);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("answerColor cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void SetAnswerColor_Valid_Hex()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetAnswerColor(TestData.Themes.SixCharHexColor);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetBackgroundBrightness_Above_One()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);
            var brightnessValue = 1.1M;

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundBrightness(brightnessValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage($"The value '{brightnessValue}' provided for brightness is out of range.  Valid range is -1 through 1.*");
        }

        [Fact]
        public void SetBackgroundBrightness_Below_Negative_One()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);
            var brightnessValue = -1.1M;

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundBrightness(brightnessValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage($"The value '{brightnessValue}' provided for brightness is out of range.  Valid range is -1 through 1.*");
        }

        [Fact]
        public void SetBackgroundBrightness_Between_Negative_One_And_One()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);
            var brightnessValue = 0M;

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundBrightness(brightnessValue);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetBackgroundBrightness_Exactly_Negative_One()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);
            var brightnessValue = -1M;

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundBrightness(brightnessValue);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetBackgroundBrightness_Exactly_One()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);
            var brightnessValue = 1M;

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundBrightness(brightnessValue);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetBackgroundColor_Empty_String()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundColor(string.Empty);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("backgroundColor cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void SetBackgroundColor_Valid_Hex()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundColor(TestData.Themes.SixCharHexColor);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetBackgroundLayout_Set_Default()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundLayout(LayoutType.Fullscreen);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetBackgroundLayout_Set_None_Default()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundLayout(LayoutType.NoRepeat);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetBackgroundUrl_Set_Empty_String()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundUrl(string.Empty);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void SetBackgroundUrl_Set_Invalid_Value()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);
            var url = TestData.BogusRandomizer.AlphaNumeric(15);

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundUrl(url);

            // ASSERT
            actionToTest.Should().Throw<UriFormatException>()
                .WithMessage($"The URL '{url}' provided for url is not valid.");
        }

        [Fact]
        public void SetBackgroundUrl_Set_Value()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);
            var validUrl = TestData.BogusFaker.Internet.Url();

            // ACT
            Action actionToTest = () => themeToTest.SetBackgroundUrl(validUrl);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetButtonColor_Empty_String()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetButtonColor(string.Empty);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("buttonColor cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void SetButtonColor_Valid_Hex()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetButtonColor(TestData.Themes.SixCharHexColor);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetColors_Valid_Hex()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetColors(TestData.Themes.SixCharHexColor,
                TestData.Themes.SixCharHexColor,
                TestData.Themes.SixCharHexColor,
                TestData.Themes.SixCharHexColor);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetFont_Default()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            themeToTest.SetFont(FontType.SourceSansPro);

            // ASSERT
            themeToTest.Build().Font.Should().Be(FontType.SourceSansPro);
        }

        [Fact]
        public void SetFont_None_Default()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            themeToTest.SetFont(FontType.Acme);

            // ASSERT
            themeToTest.Build().Font.Should().Be(FontType.Acme);
        }

        [Fact]
        public void SetQuestionColor_Empty_String()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetQuestionColor(string.Empty);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage("questionColor cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void SetQuestionColor_Valid_Hex()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            Action actionToTest = () => themeToTest.SetQuestionColor(TestData.Themes.SixCharHexColor);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentNullException>();
        }

        [Fact]
        public void SetTransportButtons_Default()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            themeToTest.SetTransparentButtons();

            // ASSERT
            themeToTest.Build().HasTransparentButton.Should().BeTrue();
        }

        [Fact]
        public void SetTransportButtons_False()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            themeToTest.SetTransparentButtons(false);

            // ASSERT
            themeToTest.Build().HasTransparentButton.Should().BeFalse();
        }

        [Fact]
        public void SetTransportButtons_True()
        {
            // ARRANGE
            var themeToTest = ThemeBuilder.Create(TestData.Themes.Name);

            // ACT
            themeToTest.SetTransparentButtons(true);

            // ASSERT
            themeToTest.Build().HasTransparentButton.Should().BeTrue();
        }

        // TODO : IsValid Checks
    }
}