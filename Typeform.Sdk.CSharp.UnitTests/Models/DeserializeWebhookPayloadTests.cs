using System;
using System.Collections.Generic;
using FluentAssertions;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Models.Webhook;
using Xunit;

namespace Typeform.Sdk.CSharp.UnitTests.Models
{
    public class DeserializeWebhookPayloadTests
    {
        private readonly string jsonPayload = "{\"event_id\":\"LtWXD3crgy\",\"event_type\":\"form_response\"," +
                                              "\"form_response\":{\"form_id\":\"lT4Z3j\",\"token\":\"a3a12ec67a1365927098a606107fac15\",\"submitted_at\":\"2018-01-18T18:17:02Z\",\"landed_at\":\"2018-01-18T18:07:02Z\"," +
                                              "\"calculated\":{\"score\":9}," +
                                              "\"definition\":{\"id\":\"lT4Z3j\",\"title\":\"Webhooks example\"," +
                                              "\"fields\":[{\"id\":\"DlXFaesGBpoF\",\"title\":\"Thanks, {{answer_60906475}}! What's it like where you live? Tell us in a few sentences.\",\"type\":\"long_text\",\"ref\":\"readable_ref_long_text\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"SMEUb7VJz92Q\",\"title\":\"If you're OK with our city management following up if they have further questions, please give us your email address.\",\"type\":\"email\",\"ref\":\"readable_ref_email\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"Nie87vP4ORlG\",\"title\":\"Please enter your mobile number so we can follow up.\",\"type\":\"phone_number\",\"ref\":\"readable_ref_phone\",\"properties\":{}},{\"id\":\"JwWggjAKtOkA\",\"title\":\"What is your first name?\",\"type\":\"short_text\",\"ref\":\"readable_ref_short_text\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"KoJxDM3c6x8h\",\"title\":\"When did you move to the place where you live?\",\"type\":\"date\",\"ref\":\"readable_ref_date\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"PNe8ZKBK8C2Q\",\"title\":\"Which pictures do you like? You can choose as many as you like.\",\"type\":\"picture_choice\",\"ref\":\"readable_ref_picture_choice\",\"allow_multiple_selections\":true,\"allow_other_choice\":false},{\"id\":\"Q7M2XAwY04dW\",\"title\":\"On a scale of 1 to 5, what rating would you give the weather in Sydney? 1 is poor weather, 5 is excellent weather\",\"type\":\"number\",\"ref\":\"readable_ref_number1\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"gFFf3xAkJKsr\",\"title\":\"By submitting this form, you understand and accept that we will share your answers with city management. Your answers will be anonymous will not be shared.\",\"type\":\"legal\",\"ref\":\"readable_ref_legal\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"k6TP9oLGgHjl\",\"title\":\"Which of these cities is your favorite?\",\"type\":\"multiple_choice\",\"ref\":\"readable_ref_multiple_choice\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"RUqkXSeXBXSd\",\"title\":\"Do you have a favorite city we haven't listed?\",\"type\":\"yes_no\",\"ref\":\"readable_ref_yes_no\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"NRsxU591jIW9\",\"title\":\"How important is the weather to your opinion about a city? 1 is not important, 5 is very important.\",\"type\":\"opinion_scale\",\"ref\":\"readable_ref_opinion_scale\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"WOTdC00F8A3h\",\"title\":\"How would you rate the weather where you currently live? 1 is poor weather, 5 is excellent weather.\",\"type\":\"rating\",\"ref\":\"readable_ref_rating\",\"allow_multiple_selections\":false,\"allow_other_choice\":false},{\"id\":\"pn48RmPazVdM\",\"title\":\"On a scale of 1 to 5, what rating would you give the general quality of life in Sydney? 1 is poor, 5 is excellent\",\"type\":\"number\",\"ref\":\"readable_ref_number2\",\"allow_multiple_selections\":false,\"allow_other_choice\":false}]}," +
                                              "\"answers\":[{\"type\":\"text\",\"text\":\"It's cold right now! I live in an older medium-sized city with a university. Geographically, the area is hilly.\",\"field\":{\"id\":\"DlXFaesGBpoF\",\"type\":\"long_text\"}},{\"type\":\"email\",\"email\":\"laura@example.com\",\"field\":{\"id\":\"SMEUb7VJz92Q\",\"type\":\"email\"}},{\"type\":\"phone_number\",\"phone_number\":\"+34123456789\",\"field\":{\"id\":\"Nie87vP4ORlG\",\"type\":\"phone_number\"}},{\"type\":\"text\",\"text\":\"Laura\",\"field\":{\"id\":\"JwWggjAKtOkA\",\"type\":\"short_text\"}},{\"type\":\"date\",\"date\":\"2005-10-15\",\"field\":{\"id\":\"KoJxDM3c6x8h\",\"type\":\"date\"}},{\"type\":\"choices\",\"choices\":{\"labels\":[\"London\",\"Sydney\"]},\"field\":{\"id\":\"PNe8ZKBK8C2Q\",\"type\":\"picture_choice\"}},{\"type\":\"number\",\"number\":5,\"field\":{\"id\":\"Q7M2XAwY04dW\",\"type\":\"number\"}},{\"type\":\"boolean\",\"boolean\":true,\"field\":{\"id\":\"gFFf3xAkJKsr\",\"type\":\"legal\"}},{\"type\":\"choice\",\"choice\":{\"label\":\"London\"},\"field\":{\"id\":\"k6TP9oLGgHjl\",\"type\":\"multiple_choice\"}},{\"type\":\"boolean\",\"boolean\":true,\"field\":{\"id\":\"RUqkXSeXBXSd\",\"type\":\"yes_no\"}},{\"type\":\"number\",\"number\":2,\"field\":{\"id\":\"NRsxU591jIW9\",\"type\":\"opinion_scale\"}},{\"type\":\"number\",\"number\":3,\"field\":{\"id\":\"WOTdC00F8A3h\",\"type\":\"rating\"}},{\"type\":\"number\",\"number\":4,\"field\":{\"id\":\"pn48RmPazVdM\",\"type\":\"number\"}}]}}";

        [Fact]
        public void WebhookParse_Parse_Answers00_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 0;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Text);

            result.FormResponse.FormAnswers[field].Text.Should().Be(
                "It's cold right now! I live in an older medium-sized city with a university. Geographically, the area is hilly.");
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(0);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("DlXFaesGBpoF");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.LongText);
        }

        [Fact]
        public void WebhookParse_Parse_Answers01_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 1;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Email);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().Be("laura@example.com");
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(0);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("SMEUb7VJz92Q");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.Email);
        }

        [Fact]
        public void WebhookParse_Parse_Answers02_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 2;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.PhoneNumber);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().Be("+34123456789");
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(0);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("Nie87vP4ORlG");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.PhoneNumber);
        }

        [Fact]
        public void WebhookParse_Parse_Answers03_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 3;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Text);

            result.FormResponse.FormAnswers[field].Text.Should().Be("Laura");
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(0);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("JwWggjAKtOkA");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.ShortText);
        }

        [Fact]
        public void WebhookParse_Parse_Answers04_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 4;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Date);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().Be(DateTime.Parse("2005-10-15"));
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(0);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("KoJxDM3c6x8h");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.Date);
        }

        [Fact]
        public void WebhookParse_Parse_Answers05_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 5;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Choices);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(0);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();

            result.FormResponse.FormAnswers[field].Choices.Should().BeOfType<Choices>();
            result.FormResponse.FormAnswers[field].Choices.Labels.Should().BeOfType<List<string>>();
            result.FormResponse.FormAnswers[field].Choices.Labels.Should().HaveCount(2);
            result.FormResponse.FormAnswers[field].Choices.Labels[0].Should().Be("London");
            result.FormResponse.FormAnswers[field].Choices.Labels[1].Should().Be("Sydney");
            result.FormResponse.FormAnswers[field].Choices.Other.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("PNe8ZKBK8C2Q");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.PictureChoice);
        }

        [Fact]
        public void WebhookParse_Parse_Answers06_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 6;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Number);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(5);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("Q7M2XAwY04dW");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.Number);
        }

        [Fact]
        public void WebhookParse_Parse_Answers07_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 7;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Boolean);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeTrue();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(0);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("gFFf3xAkJKsr");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.Legal);
        }

        [Fact]
        public void WebhookParse_Parse_Answers08_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 8;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Choice);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(0);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();

            result.FormResponse.FormAnswers[field].Choice.Should().BeOfType<Choice>();
            result.FormResponse.FormAnswers[field].Choice.Label.Should().Be("London");
            result.FormResponse.FormAnswers[field].Choice.Other.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("k6TP9oLGgHjl");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.MultipleChoice);
        }

        [Fact]
        public void WebhookParse_Parse_Answers09_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 9;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Boolean);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeTrue();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(0);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("RUqkXSeXBXSd");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.YesNo);
        }

        [Fact]
        public void WebhookParse_Parse_Answers10_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 10;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Number);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(2);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("NRsxU591jIW9");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.OpinionScale);
        }

        [Fact]
        public void WebhookParse_Parse_Answers11_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 11;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Number);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(3);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("WOTdC00F8A3h");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.Rating);
        }

        [Fact]
        public void WebhookParse_Parse_Answers12_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 12;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers[field].Type.Should().Be(FormAnswerType.Number);

            result.FormResponse.FormAnswers[field].Text.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Email.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].PhoneNumber.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Date.Should().BeNull();
            result.FormResponse.FormAnswers[field].Boolean.Should().BeFalse();
            result.FormResponse.FormAnswers[field].Url.Should().BeNullOrEmpty();
            result.FormResponse.FormAnswers[field].Number.Should().Be(4);
            result.FormResponse.FormAnswers[field].FileUrl.Should().BeNullOrEmpty();

            result.FormResponse.FormAnswers[field].Payment.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choice.Should().BeNull();
            result.FormResponse.FormAnswers[field].Choices.Should().BeNull();

            result.FormResponse.FormAnswers[field].Field.Should().BeOfType<Field>();
            result.FormResponse.FormAnswers[field].Field.Id.Should().Be("pn48RmPazVdM");
            result.FormResponse.FormAnswers[field].Field.Type.Should().Be(FieldType.Number);
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field00_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 0;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("DlXFaesGBpoF");
            result.FormResponse.FormDefinition.Fields[field].Title.Should().Be(
                "Thanks, {{answer_60906475}}! What's it like where you live? Tell us in a few sentences.");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.LongText);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_long_text");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field01_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 1;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("SMEUb7VJz92Q");
            result.FormResponse.FormDefinition.Fields[field].Title.Should().Be(
                "If you're OK with our city management following up if they have further questions, please give us your email address.");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.Email);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_email");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field02_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 2;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("Nie87vP4ORlG");
            result.FormResponse.FormDefinition.Fields[field].Title.Should()
                .Be("Please enter your mobile number so we can follow up.");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.PhoneNumber);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_phone");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field03_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 3;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("JwWggjAKtOkA");
            result.FormResponse.FormDefinition.Fields[field].Title.Should().Be("What is your first name?");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.ShortText);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_short_text");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field04_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 4;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("KoJxDM3c6x8h");
            result.FormResponse.FormDefinition.Fields[field].Title.Should()
                .Be("When did you move to the place where you live?");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.Date);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_date");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field05_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 5;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("PNe8ZKBK8C2Q");
            result.FormResponse.FormDefinition.Fields[field].Title.Should()
                .Be("Which pictures do you like? You can choose as many as you like.");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.PictureChoice);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_picture_choice");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeTrue();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field06_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 6;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("Q7M2XAwY04dW");
            result.FormResponse.FormDefinition.Fields[field].Title.Should().Be(
                "On a scale of 1 to 5, what rating would you give the weather in Sydney? 1 is poor weather, 5 is excellent weather");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.Number);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_number1");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field07_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 7;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("gFFf3xAkJKsr");
            result.FormResponse.FormDefinition.Fields[field].Title.Should().Be(
                "By submitting this form, you understand and accept that we will share your answers with city management. Your answers will be anonymous will not be shared.");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.Legal);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_legal");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field08_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 8;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("k6TP9oLGgHjl");
            result.FormResponse.FormDefinition.Fields[field].Title.Should()
                .Be("Which of these cities is your favorite?");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.MultipleChoice);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_multiple_choice");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field09_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 9;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("RUqkXSeXBXSd");
            result.FormResponse.FormDefinition.Fields[field].Title.Should()
                .Be("Do you have a favorite city we haven't listed?");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.YesNo);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_yes_no");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field10_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 10;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("NRsxU591jIW9");
            result.FormResponse.FormDefinition.Fields[field].Title.Should().Be(
                "How important is the weather to your opinion about a city? 1 is not important, 5 is very important.");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.OpinionScale);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_opinion_scale");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field11_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 11;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("WOTdC00F8A3h");
            result.FormResponse.FormDefinition.Fields[field].Title.Should().Be(
                "How would you rate the weather where you currently live? 1 is poor weather, 5 is excellent weather.");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.Rating);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_rating");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParse_Parse_Definition_Field12_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();
            var field = 12;

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields[field].Id.Should().Be("pn48RmPazVdM");
            result.FormResponse.FormDefinition.Fields[field].Title.Should().Be(
                "On a scale of 1 to 5, what rating would you give the general quality of life in Sydney? 1 is poor, 5 is excellent");
            result.FormResponse.FormDefinition.Fields[field].Type.Should().Be(FieldType.Number);
            result.FormResponse.FormDefinition.Fields[field].Ref.Should().Be("readable_ref_number2");
            result.FormResponse.FormDefinition.Fields[field].AllowsMultipleSelections.Should().BeFalse();
            result.FormResponse.FormDefinition.Fields[field].AllowsOtherChoice.Should().BeFalse();
        }

        [Fact]
        public void WebhookParser_Parse_Answers_To_Type_List_Of_FormAnswer()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormAnswers.Should().BeOfType<List<FormAnswer>>();
        }

        [Fact]
        public void WebhookParser_Parse_Base_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.EventId.Should().Be("LtWXD3crgy");
            result.EventType.Should().Be(EventType.FormResponse);
        }

        [Fact]
        public void WebhookParser_Parse_Base_To_Type_Response()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.Should().BeOfType<Response>();
        }

        [Fact]
        public void WebhookParser_Parse_Calculated_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.Calculated.Score.Should().Be(9);
        }

        [Fact]
        public void WebhookParser_Parse_Calculated_To_Type_Calculated()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.Calculated.Should().BeOfType<Calculated>();
        }

        [Fact]
        public void WebhookParser_Parse_Definition_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Id.Should().Be("lT4Z3j");
            result.FormResponse.FormDefinition.Title.Should().Be("Webhooks example");
        }

        [Fact]
        public void WebhookParser_Parse_Definition_Fields_Count_Should_Be_13()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields.Should().HaveCount(13);
        }

        [Fact]
        public void WebhookParser_Parse_Definition_Fields_To_Type_List_Of_Fields()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Fields.Should().BeOfType<List<Field>>();
        }

        [Fact]
        public void WebhookParser_Parse_Definition_To_Type_FormDefinition()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormDefinition.Should().BeOfType<FormDefinition>();
        }

        [Fact]
        public void WebhookParser_Parse_Form_Response_Correct_Properties()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.FormId.Should().Be("lT4Z3j");
            result.FormResponse.Token.Should().Be("a3a12ec67a1365927098a606107fac15");
            result.FormResponse.SubmittedAt.Should().Be(DateTime.Parse("2018-01-18T18:17:02Z"));
            result.FormResponse.LandedAt.Should().Be(DateTime.Parse("2018-01-18T18:07:02Z"));
        }

        [Fact]
        public void WebhookParser_Parse_Form_Response_To_Type_FormResponse()
        {
            // ARRANGE
            var tfWebhookParser = new WebhookParser();

            // ACT
            var result = tfWebhookParser.Parse(jsonPayload);

            // ASSERT
            result.FormResponse.Should().BeOfType<FormResponse>();
        }
    }
}