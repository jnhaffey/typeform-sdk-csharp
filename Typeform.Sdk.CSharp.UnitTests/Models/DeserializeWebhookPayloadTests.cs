using System.Collections.Generic;
using FluentAssertions;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Webhook;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Models
{
    public class DeserializeWebhookPayloadTests
    {
        [Fact]
        public void WebhookParse_Parse_HiddenField00_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 0;

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.HiddenFields.Should()
                .ContainKey(TestData.Webhook.ResponseRoot.FormResponse.Hidden.HiddenFieldKey1);
            result.FormResponse.HiddenFields.Should()
                .ContainValue(TestData.Webhook.ResponseRoot.FormResponse.Hidden.HiddenFieldValue1);
        }

        [Fact]
        public void WebhookParse_Parse_HiddenField01_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 1;

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.HiddenFields.Should()
                .ContainKey(TestData.Webhook.ResponseRoot.FormResponse.Hidden.HiddenFieldKey2);
            result.FormResponse.HiddenFields.Should()
                .ContainValue(TestData.Webhook.ResponseRoot.FormResponse.Hidden.HiddenFieldValue2);
        }

        [Fact]
        public void WebhookParse_Parse_HiddenFields_To_Type_Dictionary()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.HiddenFields.Should().BeOfType<Dictionary<string, string>>();
        }

        [Fact]
        public void WebhookParser_Parse_Answers_To_Type_List_Of_FormAnswer()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.FormAnswers.Should().BeOfType<List<FormAnswer>>();
        }

        [Fact]
        public void WebhookParser_Parse_Calculated_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.Calculated.Score.Should()
                .Be(TestData.Webhook.ResponseRoot.FormResponse.Calculated.Score);
        }

        [Fact]
        public void WebhookParser_Parse_Calculated_To_Type_Calculated()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.Calculated.Should().BeOfType<Calculated>();
        }

        [Fact]
        public void WebhookParser_Parse_Definition_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.FormDefinition.Id.Should().Be(TestData.Webhook.ResponseRoot.FormResponse.Definition.Id);
            result.FormResponse.FormDefinition.Title.Should()
                .Be(TestData.Webhook.ResponseRoot.FormResponse.Definition.Title);
        }

        [Fact]
        public void WebhookParser_Parse_Definition_Fields_Count_Should_Be_13()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.FormDefinition.Fields.Should().HaveCount(22);
        }

        [Fact]
        public void WebhookParser_Parse_Definition_Fields_To_Type_List_Of_Fields()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.FormDefinition.Fields.Should().BeOfType<List<Field>>();
        }

        [Fact]
        public void WebhookParser_Parse_Definition_To_Type_FormDefinition()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.FormDefinition.Should().BeOfType<FormDefinition>();
        }

        [Fact]
        public void WebhookParser_Parse_Form_Response_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.FormId.Should().Be(TestData.Webhook.ResponseRoot.FormResponse.FormId);
            result.FormResponse.Token.Should().Be(TestData.Webhook.ResponseRoot.FormResponse.Token);
            result.FormResponse.SubmittedAt.Should().Be(TestData.Webhook.ResponseRoot.FormResponse.SubmittedAt);
            result.FormResponse.LandedAt.Should().Be(TestData.Webhook.ResponseRoot.FormResponse.LandedAt);
        }

        [Fact]
        public void WebhookParser_Parse_Form_Response_To_Type_FormResponse()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.Should().BeOfType<FormResponse>();
        }

        [Fact]
        public void WebhookParser_Parse_HiddenFields_Count_Should_Be_2()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.FormResponse.HiddenFields.Should().HaveCount(2);
        }

        [Fact]
        public void WebhookParser_Parse_Root_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.EventId.Should().Be(TestData.Webhook.ResponseRoot.EventId);
            result.EventType.Should().Be(EventType.FormResponse);
        }

        [Fact]
        public void WebhookParser_Parse_Root_To_Type_Response()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(TestData.Webhook.JsonResponse1);

            // ASSERT
            result.Should().BeOfType<Response>();
        }
    }
}