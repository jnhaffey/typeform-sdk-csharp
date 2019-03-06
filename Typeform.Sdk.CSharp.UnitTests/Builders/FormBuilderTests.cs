using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using FluentValidation;
using Typeform.Sdk.CSharp.Builders;
using Typeform.Sdk.CSharp.Extensions;
using Typeform.Sdk.CSharp.Models;
using Typeform.Sdk.CSharp.Resources;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Builders
{
    public class FormBuilderTests
    {
        [Fact]
        public async Task Add_Duplicate_Hidden_Property()
        {
            // ARRANGE
            var builder = new FormBuilder(TestData.FormTitle);
            var propertyName = "hiddenProperties";

            // ACT
            builder.AddHiddenProperties(TestData.HiddenProperties.Property1);
            Func<FormBuilder> actionToTest = () => builder.AddHiddenProperties(TestData.HiddenProperties.Property1);

            // ASSERT
            actionToTest.Should().Throw<ArgumentException>().WithMessage(string.Format(
                ErrorMessages.Guard_ForDuplicateItemsInList, propertyName, TestData.HiddenProperties.Property1,
                nameof(Form.Hidden)));
        }

        [Fact]
        public async Task Add_Empty_Hidden_Property()
        {
            // ARRANGE
            var builder = new FormBuilder(TestData.FormTitle);
            var propertyName = "hiddenProperties";

            // ACT
            Func<FormBuilder> actionToTest = () => builder.AddHiddenProperties(TestData.EmptyValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentException>()
                .WithMessage($"{string.Format(ErrorMessages.Guard_ForNullOrEmptyOrWhitespace, propertyName)}*");
        }

        [Fact]
        public async Task Add_Multiple_Hidden_Property()
        {
            // ARRANGE
            var builder = new FormBuilder(TestData.FormTitle);

            // ACT
            builder.AddHiddenProperties(TestData.HiddenProperties.Property1);
            builder.AddHiddenProperties(TestData.HiddenProperties.Property2);
            var formToTest = await builder.Build();

            // ASSERT
            formToTest.Should().BeOfType<Form>();
            formToTest.Hidden.Should().HaveCount(2);
            formToTest.Hidden.Should().Contain(TestData.HiddenProperties.Property1);
            formToTest.Hidden.Should().Contain(TestData.HiddenProperties.Property2);
        }

        [Fact]
        public async Task Add_Single_Hidden_Property()
        {
            // ARRANGE
            var builder = new FormBuilder(TestData.FormTitle);

            // ACT
            builder.AddHiddenProperties(TestData.HiddenProperties.Property1);
            var formToTest = await builder.Build();

            // ASSERT
            formToTest.Should().BeOfType<Form>();
            formToTest.Hidden.Should().HaveCount(1);
            formToTest.Hidden.Should().Contain(TestData.HiddenProperties.Property1);
        }

        [Fact]
        public async Task Add_WhiteSpace_Hidden_Property()
        {
            // ARRANGE
            var builder = new FormBuilder(TestData.FormTitle);
            var propertyName = "hiddenProperties";

            // ACT
            Func<FormBuilder> actionToTest = () => builder.AddHiddenProperties(TestData.WhiteSpaceValue);

            // ASSERT
            actionToTest.Should().Throw<ArgumentException>()
                .WithMessage($"{string.Format(ErrorMessages.Guard_ForNullOrEmptyOrWhitespace, propertyName)}*");
        }

        [Fact]
        public async Task Basic_Create()
        {
            // ARRANGE
            var builder = new FormBuilder(TestData.FormTitle);

            // ACT
            var formToTest = await builder.Build();

            // ASSERT
            builder.Should().BeOfType<FormBuilder>();
            formToTest.Should().BeOfType<Form>();
            formToTest.Title.Should().Be(TestData.FormTitle);
            formToTest.Settings.Should().BeNull();
            formToTest.Theme.Should().BeNullOrEmpty();
            formToTest.Workspace.Should().BeNull();
            formToTest.Hidden.Should().HaveCount(0);
            formToTest.Variables.Should().BeNull();
            formToTest.WelcomeScreens.Should().HaveCount(0);
            formToTest.ThankYouScreens.Should().HaveCount(0);
            formToTest.Fields.Should().HaveCount(0);
            formToTest.Logic.Should().HaveCount(0);
        }

        [Fact]
        public async Task Basic_Create_Title_EmptyValue()
        {
            // ARRANGE
            var builder = new FormBuilder(TestData.EmptyValue);

            // ACT
            Func<Task> actionToTest = async () => await builder.Build();

            // ASSERT
            actionToTest.Should().Throw<ValidationException>()
                .WithMessage(ErrorMessages.Validation_FormCreationException);
            actionToTest.Should().Throw<ValidationException>().And.Errors.Should().HaveCount(1);
            actionToTest.Should().Throw<ValidationException>().And.Errors.FirstOrDefault().PropertyName.Should()
                .Be(nameof(Form.Title));
            actionToTest.Should().Throw<ValidationException>().And.Errors.FirstOrDefault().ErrorMessage.Should()
                .Be(ErrorMessages.Validation_RequiredProperty
                    .ReplaceValidationPlaceHolders(nameof(Form.Title), TestData.EmptyValue));
        }

        [Fact]
        public async Task Basic_Create_Title_WhiteSpaceValue()
        {
            // ARRANGE
            var builder = new FormBuilder(TestData.WhiteSpaceValue);

            // ACT
            Func<Task> actionToTest = async () => await builder.Build();

            // ASSERT
            actionToTest.Should().Throw<ValidationException>()
                .WithMessage(ErrorMessages.Validation_FormCreationException);
            actionToTest.Should().Throw<ValidationException>().And.Errors.Should().HaveCount(1);
            actionToTest.Should().Throw<ValidationException>().And.Errors.FirstOrDefault().PropertyName.Should()
                .Be(nameof(Form.Title));
            actionToTest.Should().Throw<ValidationException>().And.Errors.FirstOrDefault().ErrorMessage.Should()
                .Be(ErrorMessages.Validation_RequiredProperty
                    .ReplaceValidationPlaceHolders(nameof(Form.Title), TestData.WhiteSpaceValue));
        }
    }
}