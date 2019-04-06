using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Typeform.Sdk.CSharp.ApiClients;
using Typeform.Sdk.CSharp.Exceptions;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests
{
    [ExcludeFromCodeCoverage]
    public class GuardTests
    {
        [Fact]
        public void ForAllowedOptions_With_Found_Allowed_Option()
        {
            // ARRANGE
            // ACT
            Action actionToTest = () =>
                Guard.ForAllowedOptions(TestEnum.Test0, TestData.Guards.ParameterName, TestEnum.Test0, TestEnum.Test2);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForAllowedOptions_With_Found_Not_Allowed_Option()
        {
            // ARRANGE
            // ACT
            Action actionToTest = () =>
                Guard.ForAllowedOptions(TestEnum.Test1, TestData.Guards.ParameterName, TestEnum.Test0, TestEnum.Test2);

            // ASSERT
            actionToTest.Should().Throw<ArgumentOutOfRangeException>();
            //.WithMessage("");
        }

        [Fact]
        public void ForBetweenValues_Above()
        {
            // ARRANGE
            var value = 2;
            var min = -1;
            var max = 1;

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
            var value = -2;
            var min = -1;
            var max = 1;

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
            var value = 0;
            var min = -1;
            var max = 1;

            // ACT
            Action actionToTest = () => Guard.ForBetweenValues(value, min, max, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForBetweenValues_Maximum()
        {
            // ARRANGE
            var value = 1;
            var min = -1;
            var max = 1;

            // ACT
            Action actionToTest = () => Guard.ForBetweenValues(value, min, max, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForBetweenValues_Minimum()
        {
            // ARRANGE
            var value = -1;
            var min = -1;
            var max = 1;

            // ACT
            Action actionToTest = () => Guard.ForBetweenValues(value, min, max, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForDuplicateItemsInList_With_Duplicate()
        {
            // ARRANGE
            var listToUse = new List<string> {"FIRST", "SECOND", "THIRD"};
            var wordToUse = "FIRST";

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
            var listToUse = new List<string> {"FIRST", "SECOND", "THIRD"};
            var wordToUse = "FORTH";

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
            var hexValue = string.Empty;

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
            var hexValue = "000";

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
            var hexValue = "#00";

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
            var hexValue = "#0000";

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
            var hexValue = "#0000000";

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
            var hexValue = "#Z00000";

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
            var hexValue = " ";

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
            var createApiClient = new CreateApiClient(TestData.BogusRandomizer.AlphaNumeric(5));

            // ACT
            Action actionToTest = () => Guard.ForInitializedClient(createApiClient);

            // ASSERT
            actionToTest.Should().NotThrow<UninitializedClientException>();
        }

        [Fact]
        public void ForInitializedClient_Uninitialized()
        {
            // ARRANGE
            var clientName = nameof(CreateApiClient);
            var createApiClient = new CreateApiClient("");

            // ACT
            Action actionToTest = () => Guard.ForInitializedClient(createApiClient);

            // ASSERT
            actionToTest.Should().Throw<UninitializedClientException>()
                .WithMessage($"The '{clientName}' does not contain an API Key.");
        }

        [Fact]
        public void ForInvalidOperations_With_Invalid_Object()
        {
            // ARRANGE
            var errorMessage = "OBJECT IS NULL";
            object testObject = null;

            // ACT
            Action actionToTest = () => Guard.ForInvalidOperations(testObject, errorMessage);

            // ASSERT
            actionToTest.Should().Throw<InvalidOperationException>()
                .WithMessage(errorMessage);
        }

        [Fact]
        public void ForInvalidOperations_With_Valid_Object()
        {
            // ARRANGE
            var errorMessage = "OBJECT IS NULL";
            var testObject = new object();

            // ACT
            Action actionToTest = () => Guard.ForInvalidOperations(testObject, errorMessage);

            // ASSERT
            actionToTest.Should().NotThrow();
        }

        [Fact]
        public void ForMaxValue_Above()
        {
            // ARRANGE
            var valueToUse = 1;
            var maxValue = 0;

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
            var valueToUse = -1;
            var maxValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMaxValue(valueToUse, maxValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForMaxValue_Exact()
        {
            // ARRANGE
            var valueToUse = 0;
            var minValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMaxValue(valueToUse, minValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForMinValue_Above()
        {
            // ARRANGE
            var valueToUse = 1;
            var minValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMinValue(valueToUse, minValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForMinValue_Below()
        {
            // ARRANGE
            var valueToUse = -1;
            var minValue = 0;

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
            var valueToUse = 0;
            var minValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMinValue(valueToUse, minValue, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Empty()
        {
            // ARRANGE
            var valueToUse = string.Empty;

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
            var valueToUse = TestData.BogusRandomizer.AlphaNumeric(10);

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Whitespace()
        {
            // ARRANGE
            var valueToUse = " ";

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage($"{TestData.Guards.ParameterName} cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ForValidUrl_With_Invalid_Url()
        {
            // ARRANGE
            var url = TestData.BogusRandomizer.AlphaNumeric(15);

            // ACT
            Action actionToTest = () => Guard.ForInvalidUrl(url, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().Throw<UriFormatException>()
                .WithMessage($"The URL '{url}' provided for {TestData.Guards.ParameterName} is not valid.");
        }

        [Fact]
        public void ForValidUrl_With_Valid_Url()
        {
            // ARRANGE
            var url = TestData.BogusFaker.Internet.Url();

            // ACT
            Action actionToTest = () => Guard.ForInvalidUrl(url, TestData.Guards.ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow();
        }
    }
}