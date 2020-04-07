using System;
using System.Collections.Generic;
using System.Linq;
using Typeform.Sdk.CSharp.Enums;
using Typeform.Sdk.CSharp.Exceptions;
using Typeform.Sdk.CSharp.Models.Webhook;

namespace Typeform.Sdk.CSharp.Extensions
{
    public static class ResponseExtensions
    {
        /// <summary>
        ///     Use for Legal and Yes/No Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>bool value</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static bool GetBooleanAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.Boolean);
            return answer.Boolean;
        }

        /// <summary>
        ///     Use for Dropdown, Single Choice and Single Picture Choice Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>string value</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static string GetChoiceAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.Choice);
            return string.IsNullOrWhiteSpace(answer.Choice.Label) ? answer.Choice.Other : answer.Choice.Label;
        }

        /// <summary>
        ///     Use for Multiple Choice and Multiple Picture Choice Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>list of string values</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static List<string> GetChoicesAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.Choices);

            var combinedList = new List<string>();
            if (answer.Choices.Labels.Any()) combinedList.AddRange(answer.Choices.Labels);
            if (!string.IsNullOrWhiteSpace(answer.Choices.Other)) combinedList.Add(answer.Choices.Other);
            return combinedList;
        }

        /// <summary>
        ///     Use for Date Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>nullable date value</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static DateTime? GetDateAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.Date);
            return answer.Date;
        }

        /// <summary>
        ///     Use for Email Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>string value</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static string GetEmailAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.Email);
            return answer.Email;
        }

        /// <summary>
        ///     Use for Number, Opinion Scale and Rating Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>integer value</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static int GetNumberAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.Number);
            return answer.Number;
        }

        /// <summary>
        ///     Use for Short and Long Text Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>string value</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static string GetTextAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.Text);
            return answer.Text;
        }

        /// <summary>
        ///     Use for File Upload Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>string (URL) value</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static string GetFileUrlAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.FileUrl);
            return answer.FileUrl;
        }

        /// <summary>
        ///     Use for Phone Number Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>string value</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static string GetPhoneNumberAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.PhoneNumber);
            return answer.PhoneNumber;
        }

        /// <summary>
        ///     Use for Website Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>string (URL) value</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static string GetWebsite(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.Url);
            return answer.Url;
        }

        /// <summary>
        ///     Use for Payment Questions.
        /// </summary>
        /// <param name="questionId">The Id of the question.</param>
        /// <returns>payment object</returns>
        /// <exception cref="QuestionAnswerNotFoundException">Throws exception if question id is not found in response.</exception>
        /// <exception cref="InvalidAnswerTypeException">Throws exception if question type does match expected type.</exception>
        public static Payment GetPaymentAnswer(this Response source, string questionId)
        {
            var answer = TryGetAnswerById(source, questionId);
            VerifyAnswerType(answer, FormAnswerType.Payment);
            return answer.Payment;
        }

        private static FormAnswer TryGetAnswerById(Response source, string questionId)
        {
            var answer = source.FormResponse.FormAnswers.FirstOrDefault(fa => fa.Field.Id.Equals(questionId));
            if (answer == null) throw new QuestionAnswerNotFoundException(questionId);
            return answer;
        }

        private static void VerifyAnswerType(FormAnswer answer, FormAnswerType expectedType)
        {
            if (answer.Type != expectedType)
                throw new InvalidAnswerTypeException(
                    $"Answer expected to be of type '{expectedType}' but was found to be of type '{answer.Type}'.");
        }
    }
}