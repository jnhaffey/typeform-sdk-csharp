using System;
using System.Collections.Generic;
using Bogus;
using FluentAssertions;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests
{
    public class GuardTests
    {
        private const string ParameterName = "UNIT_TEST_PARAMETER_NAME";
        private readonly Randomizer bogusRandomizer = new Randomizer(DateTime.UtcNow.Millisecond);

        [Fact]
        public void ForDuplicateItemsInList_With_Duplicate()
        {
            // ARRANGE
            var listToUse = new List<string> {"FIRST", "SECOND", "THIRD"};
            var wordToUse = "FIRST";

            // ACT
            Action actionToTest = () => Guard.ForDuplicateItemsInList(wordToUse, ParameterName,
                listToUse, nameof(listToUse));

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage(
                    $"List {nameof(listToUse)} already contains the value '{wordToUse}' provided in {ParameterName}.");
        }

        [Fact]
        public void ForDuplicateItemsInList_With_Out_Duplicate()
        {
            // ARRANGE
            var listToUse = new List<string> {"FIRST", "SECOND", "THIRD"};
            var wordToUse = "FORTH";

            // ACT
            Action actionToTest = () => Guard.ForDuplicateItemsInList(wordToUse, ParameterName,
                listToUse, nameof(listToUse));

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForMaxValue_Above()
        {
            // ARRANGE
            var valueToUse = 1;
            var maxValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMaxValue(valueToUse, maxValue, ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage(
                    $"The value provided ({valueToUse}) for '{ParameterName}' is above the maximum value of {maxValue}.");
        }

        [Fact]
        public void ForMaxValue_Below()
        {
            // ARRANGE
            var valueToUse = -1;
            var maxValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMaxValue(valueToUse, maxValue, ParameterName);

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
            Action actionToTest = () => Guard.ForMaxValue(valueToUse, minValue, ParameterName);

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
            Action actionToTest = () => Guard.ForMinValue(valueToUse, minValue, ParameterName);

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
            Action actionToTest = () => Guard.ForMinValue(valueToUse, minValue, ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage(
                    $"The value provided ({valueToUse}) for '{ParameterName}' is below the minimum value of {minValue}.");
        }

        [Fact]
        public void ForMinValue_Exact()
        {
            // ARRANGE
            var valueToUse = 0;
            var minValue = 0;

            // ACT
            Action actionToTest = () => Guard.ForMinValue(valueToUse, minValue, ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Empty()
        {
            // ARRANGE
            var valueToUse = string.Empty;

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage($"{ParameterName} cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Null()
        {
            // ARRANGE
            string valueToUse = null;

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage($"{ParameterName} cannot be null, empty, or whitespace.*");
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Value()
        {
            // ARRANGE
            var valueToUse = bogusRandomizer.AlphaNumeric(10);

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, ParameterName);

            // ASSERT
            actionToTest.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void ForNullOrEmptyOrWhitespace_With_Whitespace()
        {
            // ARRANGE
            var valueToUse = " ";

            // ACT
            Action actionToTest = () => Guard.ForNullOrEmptyOrWhitespace(valueToUse, ParameterName);

            // ASSERT
            actionToTest.Should()
                .Throw<ArgumentException>()
                .WithMessage($"{ParameterName} cannot be null, empty, or whitespace.*");
        }
    }
}