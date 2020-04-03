using System;
using System.Collections.Generic;
using FluentAssertions;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Extensions;
using Typeform.Sdk.CSharp.Models.Webhook;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Extensions
{
    public class FormAnswerExtensionTests
    {
        private const string _textValue = "TEST123";
        private const string _otherValue = "OTHER123";
        private const int _numberValue = 123;
        private const string _phoneNumberValue = "+123456789";
        private const string _emailValue = "TEXT@EXAMPLE.COM";
        private readonly DateTime _dateValue = new DateTime(2000, 1, 1, 0, 0, 0);

        private readonly Payment _payment = new Payment
        {
            Name = _textValue,
            Amount = _otherValue,
            Last4 = _numberValue.ToString(),
            Success = true
        };

        [Fact]
        public void GetBooleanAnswer_With_False_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Boolean, Boolean = false};

            // ACT
            var result = answerToTest.GetBooleanAnswer();

            // ASSERT
            result.Should().BeFalse();
        }

        [Fact]
        public void GetBooleanAnswer_With_NonBoolean_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Text};

            // ACT
            Action action = () => answerToTest.GetBooleanAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Text} and not {FormAnswerType.Boolean}.");
        }

        [Fact]
        public void GetBooleanAnswer_With_True_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Boolean, Boolean = true};

            // ACT
            var result = answerToTest.GetBooleanAnswer();

            // ASSERT
            result.Should().BeTrue();
        }

        [Fact]
        public void GetChoiceAnswer_With_Label_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Choice, Choice = new Choice {Label = _textValue}};

            // ACT
            var result = answerToTest.GetChoiceAnswer();

            // ASSERT
            result.Should().Be(_textValue);
        }

        [Fact]
        public void GetChoiceAnswer_With_NonChoice_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Text};

            // ACT
            Action action = () => answerToTest.GetChoiceAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Text} and not {FormAnswerType.Choice}.");
        }

        [Fact]
        public void GetChoiceAnswer_With_Other_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Choice, Choice = new Choice {Other = _textValue}};

            // ACT
            var result = answerToTest.GetChoiceAnswer();

            // ASSERT
            result.Should().Be(_textValue);
        }

        [Fact]
        public void GetChoicesAnswer_With_LabelAndOther_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer
            {
                Type = FormAnswerType.Choices,
                Choices = new Choices {Labels = new List<string> {_textValue}, Other = _otherValue}
            };

            // ACT
            var result = answerToTest.GetChoicesAnswer();

            // ASSERT
            result.Should().Contain(_textValue);
            result.Should().Contain(_otherValue);
        }

        [Fact]
        public void GetChoicesAnswer_With_MultipleLabel_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer
            {
                Type = FormAnswerType.Choices,
                Choices = new Choices {Labels = new List<string> {_textValue, _otherValue}}
            };

            // ACT
            var result = answerToTest.GetChoicesAnswer();

            // ASSERT
            result.Should().Contain(_textValue);
            result.Should().Contain(_otherValue);
        }

        [Fact]
        public void GetChoicesAnswer_With_NonChoices_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Text};

            // ACT
            Action action = () => answerToTest.GetChoicesAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Text} and not {FormAnswerType.Choices}.");
        }

        [Fact]
        public void GetChoicesAnswer_With_SingleLabel_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer
                {Type = FormAnswerType.Choices, Choices = new Choices {Labels = new List<string> {_textValue}}};

            // ACT
            var result = answerToTest.GetChoicesAnswer();

            // ASSERT
            result.Should().Contain(_textValue);
        }

        [Fact]
        public void GetDateAnswer_With_Date_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Date, Date = _dateValue};

            // ACT
            var result = answerToTest.GetDateAnswer();

            // ASSERT
            result.Should().Be(_dateValue);
        }

        [Fact]
        public void GetDateAnswer_With_NonDate_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Text};

            // ACT
            Action action = () => answerToTest.GetDateAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Text} and not {FormAnswerType.Date}.");
        }

        [Fact]
        public void GetDateAnswer_Without_Date_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Date};

            // ACT
            var result = answerToTest.GetDateAnswer();

            // ASSERT
            result.Should().BeNull();
        }

        [Fact]
        public void GetEmailAnswer_With_Email_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Email, Email = _emailValue};

            // ACT
            var result = answerToTest.GetEmailAnswer();

            // ASSERT
            result.Should().Be(_emailValue);
        }

        [Fact]
        public void GetEmailAnswer_With_NonEmail_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Text};

            // ACT
            Action action = () => answerToTest.GetEmailAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Text} and not {FormAnswerType.Email}.");
        }

        [Fact]
        public void GetEmailAnswer_Without_Email_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Email};

            // ACT
            var result = answerToTest.GetEmailAnswer();

            // ASSERT
            result.Should().BeNull();
        }

        [Fact]
        public void GetFileUrlAnswer_With_FileUrl_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.FileUrl, FileUrl = _textValue};

            // ACT
            var result = answerToTest.GetFileUrlAnswer();

            // ASSERT
            result.Should().Be(_textValue);
        }

        [Fact]
        public void GetFileUrlAnswer_With_NonFileUrl_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Number};

            // ACT
            Action action = () => answerToTest.GetFileUrlAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Number} and not {FormAnswerType.FileUrl}.");
        }

        [Fact]
        public void GetFileUrlAnswer_Without_FileUrl_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.FileUrl};

            // ACT
            var result = answerToTest.GetFileUrlAnswer();

            // ASSERT
            result.Should().BeNull();
        }

        [Fact]
        public void GetNumberAnswer_With_NonNumber_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Text};

            // ACT
            Action action = () => answerToTest.GetNumberAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Text} and not {FormAnswerType.Number}.");
        }

        [Fact]
        public void GetNumberAnswer_With_Number_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Number, Number = _numberValue};

            // ACT
            var result = answerToTest.GetNumberAnswer();

            // ASSERT
            result.Should().Be(_numberValue);
        }

        [Fact]
        public void GetNumberAnswer_Without_Number_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Number};

            // ACT
            var result = answerToTest.GetNumberAnswer();

            // ASSERT
            result.Should().Be(0);
        }

        [Fact]
        public void GetPaymentAnswer_With_NonPayment_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Text};

            // ACT
            Action action = () => answerToTest.GetPaymentAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Text} and not {FormAnswerType.Payment}.");
        }

        [Fact]
        public void GetPaymentAnswer_With_Payment_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Payment, Payment = _payment};

            // ACT
            var result = answerToTest.GetPaymentAnswer();

            // ASSERT
            result.Should().BeOfType<Payment>();
            result.Name.Should().Be(_payment.Name);
            result.Amount.Should().Be(_payment.Amount);
            result.Last4.Should().Be(_payment.Last4);
            result.Success.Should().Be(_payment.Success);
        }

        [Fact]
        public void GetPaymentAnswer_Without_Payment_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Payment};

            // ACT
            var result = answerToTest.GetPaymentAnswer();

            // ASSERT
            result.Should().BeNull();
        }

        [Fact]
        public void GetPhoneNumberAnswer_With_NonPhoneNumber_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Number};

            // ACT
            Action action = () => answerToTest.GetPhoneNumberAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Number} and not {FormAnswerType.PhoneNumber}.");
        }

        [Fact]
        public void GetPhoneNumberAnswer_With_PhoneNumber_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.PhoneNumber, PhoneNumber = _phoneNumberValue};

            // ACT
            var result = answerToTest.GetPhoneNumberAnswer();

            // ASSERT
            result.Should().Be(_phoneNumberValue);
        }

        [Fact]
        public void GetPhoneNumberAnswer_Without_PhoneNumber_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.PhoneNumber};

            // ACT
            var result = answerToTest.GetPhoneNumberAnswer();

            // ASSERT
            result.Should().BeNull();
        }

        [Fact]
        public void GetTextAnswer_With_NonText_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Number};

            // ACT
            Action action = () => answerToTest.GetTextAnswer();

            // ASSERT
            action.Should().ThrowExactly<InvalidAnswerTypeException>()
                .WithMessage($"Answer is of type {FormAnswerType.Number} and not {FormAnswerType.Text}.");
        }

        [Fact]
        public void GetTextAnswer_With_Text_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Text, Text = _textValue};

            // ACT
            var result = answerToTest.GetTextAnswer();

            // ASSERT
            result.Should().Be(_textValue);
        }

        [Fact]
        public void GetTextAnswer_Without_Text_Answer()
        {
            // ARRANGE
            var answerToTest = new FormAnswer {Type = FormAnswerType.Text};

            // ACT
            var result = answerToTest.GetTextAnswer();

            // ASSERT
            result.Should().BeNull();
        }
    }
}