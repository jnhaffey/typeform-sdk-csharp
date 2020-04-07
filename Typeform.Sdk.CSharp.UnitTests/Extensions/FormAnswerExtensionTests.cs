using System;
using System.Diagnostics;
using FluentAssertions;
using Typeform.Sdk.CSharp.Extensions;
using Typeform.Sdk.CSharp.Models.Webhook;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Extensions
{
    public class FormAnswerExtensionTests
    {
        public FormAnswerExtensionTests()
        {
            var tfWebhookParser = new WebhookParser();
            _parsedResponse1 = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);
            _parsedResponse2 = tfWebhookParser.Parse(TestData.Webhook.JsonResponse2);
        }

        private readonly Response _parsedResponse1;
        private readonly Response _parsedResponse2;

        [Fact]
        public void GetBooleanAnswer_From_LegalQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.Legal.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Legal.Boolean;

            // ACT
            var results = _parsedResponse1.GetBooleanAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetBooleanAnswer_From_YesNoQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.YesNo.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.YesNo.Boolean;

            // ACT
            var results = _parsedResponse1.GetBooleanAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetChoiceAnswer_From_DropdownQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.Dropdown.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Dropdown.Choice.Label;

            // ACT
            var results = _parsedResponse1.GetChoiceAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetChoiceAnswer_From_SingleChoice_With_Other_Option1()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .MultipleChoice_Single_With_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.MultipleChoice_Single_With_Other
                .Choice.Label;

            // ACT
            var results = _parsedResponse1.GetChoiceAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetChoiceAnswer_From_SingleChoice_With_Other_Option2()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .MultipleChoice_Single_With_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.MultipleChoice_Single_With_Other
                .Choice.Other;

            // ACT
            var results = _parsedResponse2.GetChoiceAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }


        [Fact]
        public void GetChoiceAnswer_From_SingleChoice_Without_Other_Option()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .MultipleChoice_Single_Without_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.MultipleChoice_Single_Without_Other
                .Choice.Label;

            // ACT
            var results = _parsedResponse1.GetChoiceAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetChoiceAnswer_From_SinglePictureChoice_With_Other_Option1()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .PictureChoice_Single_With_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.PictureChoice_Single_With_Other
                .Choice.Label;

            // ACT
            var results = _parsedResponse1.GetChoiceAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetChoiceAnswer_From_SinglePictureChoice_With_Other_Option2()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .PictureChoice_Single_With_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.PictureChoice_Single_With_Other
                .Choice.Other;

            // ACT
            var results = _parsedResponse2.GetChoiceAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }


        [Fact]
        public void GetChoiceAnswer_From_SinglePictureChoice_Without_Other_Option()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .PictureChoice_Single_Without_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.PictureChoice_Single_Without_Other
                .Choice.Label;

            // ACT
            var results = _parsedResponse1.GetChoiceAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetChoicesAnswer_From_MultiChoice_With_Other_Option1()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .MultipleChoice_Multiple_With_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.MultipleChoice_Multiple_With_Other
                .Choices.Labels;
            var expectedMissing = TestData.Webhook.ResponseRoot.FormResponse.Answers.MultipleChoice_Multiple_With_Other
                .Choices.Other;

            // ACT
            var results = _parsedResponse1.GetChoicesAnswer(questionId);

            // ASSERT
            results.Should().HaveSameCount(expectedResult);
            results.Should().Contain(expectedResult);
            results.Should().NotContain(expectedMissing);
        }

        [Fact]
        public void GetChoicesAnswer_From_MultiChoice_With_Other_Option2()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .MultipleChoice_Multiple_With_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.MultipleChoice_Multiple_With_Other
                .Choices.Labels;
            expectedResult.Add(TestData.Webhook.ResponseRoot.FormResponse.Answers.MultipleChoice_Multiple_With_Other
                .Choices.Other);

            // ACT
            var results = _parsedResponse2.GetChoicesAnswer(questionId);

            // ASSERT
            results.Should().HaveSameCount(expectedResult);
            results.Should().Contain(expectedResult);
        }

        [Fact]
        public void GetChoicesAnswer_From_MultiChoice_Without_Other_Option()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .MultipleChoice_Multiple_Without_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers
                .MultipleChoice_Multiple_Without_Other.Choices.Labels;

            // ACT
            var results = _parsedResponse1.GetChoicesAnswer(questionId);

            // ASSERT
            results.Should().HaveSameCount(expectedResult);
            results.Should().Contain(expectedResult);
        }

        [Fact]
        public void GetChoicesAnswer_From_MultiPictureChoice_With_Other_Option1()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .PictureChoice_Multiple_With_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.PictureChoice_Multiple_With_Other
                .Choices.Labels;
            var expectedMissing = TestData.Webhook.ResponseRoot.FormResponse.Answers.PictureChoice_Multiple_With_Other
                .Choices.Other;

            // ACT
            var results = _parsedResponse1.GetChoicesAnswer(questionId);

            // ASSERT
            results.Should().HaveSameCount(expectedResult, $"ExpectedResult: {expectedResult.Count}");
            results.Should().Contain(expectedResult, $"ExpectedResult: {expectedResult}");
            results.Should().NotContain(expectedMissing, $"ExpectedMissing: {expectedMissing}");
        }

        [Fact]
        public void GetChoicesAnswer_From_MultiPictureChoice_With_Other_Option2()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .PictureChoice_Multiple_With_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.PictureChoice_Multiple_With_Other
                .Choices.Labels;
            var expectedOtherResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.PictureChoice_Multiple_With_Other
                .Choices.Other;

            // ACT
            var results = _parsedResponse2.GetChoicesAnswer(questionId);

            // ASSERT
            results.Should().HaveCount(expectedResult.Count + 1);
            results.Should().Contain(expectedResult);
            results.Should().Contain(expectedOtherResult);
        }

        [Fact]
        public void GetChoicesAnswer_From_MultiPictureChoice_Without_Other_Option()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields
                .PictureChoice_Multiple_Without_Other.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.PictureChoice_Multiple_Without_Other
                .Choices.Labels;

            // ACT
            var results = _parsedResponse1.GetChoicesAnswer(questionId);

            // ASSERT
            results.Should().HaveSameCount(expectedResult);
            results.Should().Contain(expectedResult);
        }

        [Fact]
        public void GetDateAnswer_From_DateQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.Date.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Date.DateValue;

            // ACT
            var results = _parsedResponse1.GetDateAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetEmailAnswer_From_EmailQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.Email.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Email.EmailValue;

            // ACT
            var results = _parsedResponse1.GetEmailAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetFileUrlAnswer_From_FileUploadQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.FileUpload.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.FileUpload.FileUrl;

            // ACT
            var results = _parsedResponse1.GetFileUrlAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetNumberAnswer_From_NumberQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.Number.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Number.NumberValue;

            // ACT
            var results = _parsedResponse1.GetNumberAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetNumberAnswer_From_OpinionScaleQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.OpinionScale.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.OpinionScale.Number;

            // ACT
            var results = _parsedResponse1.GetNumberAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetNumberAnswer_From_RatingQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.Rating.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Rating.Number;

            // ACT
            var results = _parsedResponse1.GetNumberAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetPaymentAnswer_From_PaymentQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.Payment.Id;
            var expectedAmountResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Payment.PaymentValue.Amount;
            var expectedLast4Result = TestData.Webhook.ResponseRoot.FormResponse.Answers.Payment.PaymentValue.Last4;
            var expectedNameResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Payment.PaymentValue.Name;
            var expectedSuccessResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Payment.PaymentValue.Success;

            // ACT
            var results = _parsedResponse1.GetPaymentAnswer(questionId);

            // ASSERT
            results.Amount.Should().Be(expectedAmountResult);
            results.Last4.Should().Be(expectedLast4Result);
            results.Name.Should().Be(expectedNameResult);
            results.Success.Should().Be(expectedSuccessResult);
        }

        [Fact]
        public void GetPhoneNumberAnswer_From_PhoneNumberQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.PhoneNumber.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.PhoneNumber.Phone_Number;

            // ACT
            var results = _parsedResponse1.GetPhoneNumberAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetTextAnswer_From_LongTextQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.LongText.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.LongText.Text;

            // ACT
            var results = _parsedResponse1.GetTextAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetTextAnswer_From_ShortTextQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.ShortText.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.ShortText.Text;

            // ACT
            var results = _parsedResponse1.GetTextAnswer(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }

        [Fact]
        public void GetWebsiteAnswer_From_WebsiteQuestion()
        {
            // ARRANGE
            var questionId = TestData.Webhook.ResponseRoot.FormResponse.Definition.Fields.Website.Id;
            var expectedResult = TestData.Webhook.ResponseRoot.FormResponse.Answers.Website.Url;

            // ACT
            var results = _parsedResponse1.GetWebsite(questionId);

            // ASSERT
            results.Should().Be(expectedResult);
        }
    }
}