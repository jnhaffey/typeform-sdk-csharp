using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Typeform.Sdk.CSharp.ApiClients;
using Typeform.Sdk.CSharp.Exceptions;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class GuardTests
    {
        [Fact]
        public void ForBetweenValues_Above()
        {
            // ARRANGE
            int value = 2;
            int min = -1;
            int max = 1;

            // ACT
            Action actionToTest = () => Guard.ForBetweenValues(value, min, max, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(
                    $"The value '{value}' provided for {TestData.Guards.ParameterName} is out of range.  Valid range is {min} through {max}.*");
        }

        [Fact]
        public void ForBetweenValues_Below()
        {
            // ARRANGE
            int value = -2;
            int min = -1;
            int max = 1;

            // ACT
            Action actionToTest = () => Guard.ForBetweenValues(value, min, max, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<ArgumentOutOfRangeException>()
                .WithMessage(
                    $"The value '{value}' provided for {TestData.Guards.ParameterName} is out of range.  Valid range is {min} through {max}.*");
        }

        [Fact]
        public void ForBetweenValues_Between()
        {
            // ARRANGE
            int value = 0;
            int min = -1;
            int max = 1;

            // ACT
            Action actionToTest = () => Guard.ForBetweenValues(value, min, max, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForBetweenValues_Maximum()
        {
            // ARRANGE
            int value = 1;
            int min = -1;
            int max = 1;

            // ACT
            Action actionToTest = () => Guard.ForBetweenValues(value, min, max, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForBetweenValues_Minimum()
        {
            // ARRANGE
            int value = -1;
            int min = -1;
            int max = 1;

            // ACT
            Action actionToTest = () => Guard.ForBetweenValues(value, min, max, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForDuplicateItemsInList_With_Duplicate()
        {
            // ARRANGE
            List<string> listToUse = new List<string> { "FIRST", "SECOND", "THIRD" };
            string wordToUse = "FIRST";

            // ACT
            Action actionToTest = () => Guard.ForDuplicateItemsInList(wordToUse, TestData.Guards.ParameterName,
                listToUse, nameof(listToUse));

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage(
                    $"List {nameof(listToUse)} already contains the value '{wordToUse}' provided in {TestData.Guards.ParameterName}.");
        }

        [Fact]
        public void ForDuplicateItemsInList_With_Out_Duplicate()
        {
            // ARRANGE
            List<string> listToUse = new List<string> { "FIRST", "SECOND", "THIRD" };
            string wordToUse = "FORTH";

            // ACT
            Action actionToTest = () => Guard.ForDuplicateItemsInList(wordToUse, TestData.Guards.ParameterName,
                listToUse, nameof(listToUse));

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForHexColorValue_with_Empty()
        {
            // ARRANGE
            string hexValue = string.Empty;

            // ACT
            Action actionToTest = () => Guard.ForHexColorValue(hexValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage($"{TestData.Guards.ParameterName} cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ForHexColorValue_with_Invalid_Hex1()
        {
            // ARRANGE
            string hexValue = "000";

            // ACT
            Action actionToTest = () => Guard.ForHexColorValue(hexValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<InvalidHexColorException>()
                .WithMessage(
                    $"The value '{hexValue}' provided for {TestData.Guards.ParameterName} is not a valid Hex Color.  Format should be '#000' or '#000000'.");
        }

        [Fact]
        public void ForHexColorValue_with_Invalid_Hex2()
        {
            // ARRANGE
            string hexValue = "#00";

            // ACT
            Action actionToTest = () => Guard.ForHexColorValue(hexValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<InvalidHexColorException>()
                .WithMessage(
                    $"The value '{hexValue}' provided for {TestData.Guards.ParameterName} is not a valid Hex Color.  Format should be '#000' or '#000000'.");
        }

        [Fact]
        public void ForHexColorValue_with_Invalid_Hex3()
        {
            // ARRANGE
            string hexValue = "#0000";

            // ACT
            Action actionToTest = () => Guard.ForHexColorValue(hexValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<InvalidHexColorException>()
                .WithMessage(
                    $"The value '{hexValue}' provided for {TestData.Guards.ParameterName} is not a valid Hex Color.  Format should be '#000' or '#000000'.");
        }

        [Fact]
        public void ForHexColorValue_with_Invalid_Hex4()
        {
            // ARRANGE
            string hexValue = "#0000000";

            // ACT
            Action actionToTest = () => Guard.ForHexColorValue(hexValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<InvalidHexColorException>()
                .WithMessage(
                    $"The value '{hexValue}' provided for {TestData.Guards.ParameterName} is not a valid Hex Color.  Format should be '#000' or '#000000'.");
        }

        [Fact]
        public void ForHexColorValue_with_Invalid_Hex5()
        {
            // ARRANGE
            string hexValue = "#Z00000";

            // ACT
            Action actionToTest = () => Guard.ForHexColorValue(hexValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<InvalidHexColorException>()
                .WithMessage(
                    $"The value '{hexValue}' provided for {TestData.Guards.ParameterName} is not a valid Hex Color.  Format should be '#000' or '#000000'.");
        }

        [Fact]
        public void ForHexColorValue_with_Null()
        {
            // ARRANGE
            string hexValue = null;

            // ACT
            Action actionToTest = () => Guard.ForHexColorValue(hexValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage($"{TestData.Guards.ParameterName} cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ForHexColorValue_with_Valid_Six_Char_Hex()
        {
            // ARRANGE
            // ACT
            Action actionToTest = () =>
                Guard.ForHexColorValue(TestData.Themes.SixCharHexColor, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForHexColorValue_with_Valid_Three_Char_Hex()
        {
            // ARRANGE
            // ACT
            Action actionToTest = () =>
                Guard.ForHexColorValue(TestData.Themes.ThreeCharHexColor, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForHexColorValue_with_Whitespace()
        {
            // ARRANGE
            string hexValue = " ";

            // ACT
            Action actionToTest = () => Guard.ForHexColorValue(hexValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<ArgumentNullException>()
                .WithMessage($"{TestData.Guards.ParameterName} cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ForInitializedClient_Initialized()
        {
            // ARRANGE
            CreateApiClient createApiClient = new CreateApiClient(TestData.BogusRandomizer.AlphaNumeric(5));

            // ACT
            Action actionToTest = () => Guard.ForInitializedClient(createApiClient);

            // ASSERT
            actionToTest.Should().NotThrow<UninitializedClientException>();
        }

        [Fact]
        public void ForInitializedClient_Uninitialized()
        {
            // ARRANGE
            string clientName = nameof(CreateApiClient);
            CreateApiClient createApiClient = new CreateApiClient("");

            // ACT
            Action actionToTest = () => Guard.ForInitializedClient(createApiClient);

            // ASSERT
            actionToTest.Should().Throw<UninitializedClientException>()
                .WithMessage($"The '{clientName}' does not contain an API Key.");
        }

        [Fact]
        public void ForMaxValue_Above()
        {
            // ARRANGE
            int valueToUse = 1;
            int maxValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMaxValue(valueToUse, maxValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage(
                    $"The value provided ({valueToUse}) for '{TestData.Guards.ParameterName}' is above the maximum value of {maxValue}.");
        }

        [Fact]
        public void ForMaxValue_Below()
        {
            // ARRANGE
            int valueToUse = -1;
            int maxValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMaxValue(valueToUse, maxValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForMaxValue_Exact()
        {
            // ARRANGE
            int valueToUse = 0;
            int minValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMaxValue(valueToUse, minValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForMinValue_Above()
        {
            // ARRANGE
            int valueToUse = 1;
            int minValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMinValue(valueToUse, minValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForMinValue_Below()
        {
            // ARRANGE
            int valueToUse = -1;
            int minValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMinValue(valueToUse, minValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage(
                    $"The value provided ({valueToUse}) for '{TestData.Guards.ParameterName}' is below the minimum value of {minValue}.");
        }

        [Fact]
        public void ForMinValue_Exact()
        {
            // ARRANGE
            int valueToUse = 0;
            int minValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMinValue(valueToUse, minValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Empty()
        {
            // ARRANGE
            string valueToUse = string.Empty;

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage($"{TestData.Guards.ParameterName} cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Null()
        {
            // ARRANGE
            string valueToUse = null;

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage($"{TestData.Guards.ParameterName} cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Value()
        {
            // ARRANGE
            string valueToUse = TestData.BogusRandomizer.AlphaNumeric(10);

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Whitespace()
        {
            // ARRANGE
            string valueToUse = " ";

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage($"{TestData.Guards.ParameterName} cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ForValidUrl_With_Valid_Url()
        {
            // ARRANGE
            string url = TestData.BogusFaker.Internet.Url();

            // ACT
            Action actionToTest = () => Guard.ForInvalidUrl(url, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForValidUrl_With_Invalid_Url()
        {
            // ARRANGE
            string url = TestData.BogusRandomizer.AlphaNumeric(15);

            // ACT
            Action actionToTest = () => Guard.ForInvalidUrl(url, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<UriFormatException>()
                .WithMessage($"The URL '{url}' provided for {TestData.Guards.ParameterName} is not valid.");
        }

        [Fact]
        public void ForInvalidOperations_With_Valid_Object()
        {
            // ARRANGE
            string errorMessage = "OBJECT IS NULL";
            object testObject = new object();

            // ACT
            Action actionToTest = () => Guard.ForInvalidOperations(testObject, errorMessage);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForInvalidOperations_With_Invalid_Object()
        {
            // ARRANGE
            string errorMessage = "OBJECT IS NULL";
            object testObject = null;

            // ACT
            Action actionToTest = () => Guard.ForInvalidOperations(testObject, errorMessage);

            // ASSERT
            actionToTest.Should().Throw<InvalidOperationException>()
                .WithMessage(errorMessage);
        }

        [Fact]
        public void ForAllowedOptions_With_Found_Allowed_Option()
        {
            // ARRANGE
            // ACT
            Action actionToTest = () => Guard.ForAllowedOptions(TestEnum.Test0, TestData.Guards.ParameterName, TestEnum.Test0, TestEnum.Test2);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForAllowedOptions_With_Found_Not_Allowed_Option()
        {
            // ARRANGE
            // ACT
            Action actionToTest = () => Guard.ForAllowedOptions(TestEnum.Test1, TestData.Guards.ParameterName, TestEnum.Test0, TestEnum.Test2);

            // ASSERT
            actionToTest.Should().Throw<ArgumentOutOfRangeException>();
            //.WithMessage("");
        }
    }
}